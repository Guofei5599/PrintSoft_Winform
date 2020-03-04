using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire;
using Spire.Pdf;
using System.Windows.Forms;
using Spire.Pdf.Print;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using O2S.Components.PDFRender4NET;
using System.IO;

namespace 打印管理
{
    /// <summary>
    /// 打印参数类
    /// </summary>
    public class printerParam
    {
        public string UserID { set; get; }

        public string oldFile { set; get; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string printerName { set; get; }
        /// <summary>
        /// 份数
        /// </summary>
        public short Sum { set; get; }
        /// <summary>
        /// 是否为彩色
        /// </summary>
        public bool isColor { set; get; }
        /// <summary>
        /// 双面
        /// </summary>
        public bool DoubleForm { set; get; }
        /// <summary>
        /// 纸盒
        /// </summary>
        public int PaperSource { set; get; }
    }
    public class FilePrinter
    {
        public delegate void deleshowTip(GroupMsg tmpmsg);
        public deleshowTip deleshowTipfunc;
        public static ConcurrentDictionary<string, bool> usingPrinter = new ConcurrentDictionary<string, bool>();
        IAsyncResult iar = null;
        public void AsyncPrinter(FilePrinter filePrintermsg,GroupMsg msg,bool isFast)
        {
            bool istmpFast = isFast;
            bool isIdel = true;
            foreach (var v in msg.FileMsgList)
            {
                if (usingPrinter.ContainsKey(v.Printer) && usingPrinter[v.Printer])
                {
                    isIdel = false;
                    break;
                }
            }
            if (!isIdel)
            {
                MessageBox.Show("打印机有订单占用，请重新选择!");
                return;
            }
            msg.isPrint = true;
            msg.isAbort = false;
            msg.isCanceling = false;
            foreach (var v in msg.FileMsgList)
            {
                if (usingPrinter.ContainsKey(v.Printer))
                {
                    usingPrinter[v.Printer] = true;
                }
                else
                    usingPrinter.TryAdd(v.Printer, true);
            }
            ExcelHelper.AddMs(msg);
            iar = func.BeginInvoke(filePrintermsg, msg, istmpFast, callBack, msg);
        }

        private void callBack(IAsyncResult ar)
        {
            bool b = func.EndInvoke(ar);
            GroupMsg tmpmsg = ar.AsyncState as GroupMsg;
            if (b)
            {
                UserDB udb = new UserDB() { userName = tmpmsg.GroupName, lastAddr = tmpmsg.Area, lastTime = DateTime.Parse(tmpmsg.LoadTime), phone = tmpmsg.Phone };
                if (tmpmsg.FileMsgList.Count(t => int.Parse(t.state) < 3) == 0)
                {
                    OutUser(tmpmsg, udb);
                    //ExcelHelper.AddMs(tmpmsg);
                }
                SqlModlus.SaveGroupMsg(tmpmsg);
                if (str.Length > 0)
                {
                    MessageBox.Show("打印异常：" + str);
                    str = "";
                }
                foreach (var v in tmpmsg.FileMsgList)
                {
                    if (usingPrinter.ContainsKey(v.Printer))
                        usingPrinter[v.Printer] = false;
                }
                tmpmsg.isPrint = false;
            }
            else
            {
                if(tmpmsg.isAbort)
                    tmpmsg.FileMsgList.ForEach(t => t.state = "0");
                foreach (var v in tmpmsg.FileMsgList)
                {
                    if (usingPrinter.ContainsKey(v.Printer))
                        usingPrinter[v.Printer] = false;
                }
            }
            tmpmsg.isPrint = false;
            tmpmsg.isAbort = false;
            tmpmsg.isCanceling = false;
        }

        public void OutUser(GroupMsg tmpmsg, UserDB udb)
        {
            tmpmsg.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tmpmsg.state = "3";
            if (tmpmsg.FileDirectory == null)
                tmpmsg.FileDirectory = frm_Main.CurrentPath;
            SqlModlus.InsertUserMsg(tmpmsg);
            main.InsertOrUpdateUser(udb);
            if (null != tmpmsg.FileMsgList)
            {
                foreach (FileMsg fmsg in tmpmsg.FileMsgList)
                {
                    SqlModlus.InsertFileMsg(fmsg, tmpmsg.GroupName);
                    fmsg.state = "3";
                }
            }
            tmpmsg.isShow = true;
        }

        public string str;
        Func<FilePrinter,GroupMsg,bool , bool> func = (filePrintermsg,tmpmsg, isFast) =>
        {
            if (!Directory.Exists(tmpmsg.FullName))
            {
                MessageBox.Show("文件已失效，请删除订单后重新录入！");
                return false;
            }
            foreach (FileMsg fmsg in tmpmsg.FileMsgList)
            {
                if (tmpmsg.isAbort)
                    return false;
                if (int.Parse(fmsg.state) >= 3 || fmsg.isNormalFile)
                {
                    continue;
                }
                if (!File.Exists(fmsg.FullName))
                {
                    MessageBox.Show("该文件路径不存在！");
                    fmsg.state = "-1";
                    continue;
                }
                printerParam param = new printerParam();
                param.DoubleForm = fmsg.VerForm == "正反" ? true : false;
                param.FileName = fmsg.FullName;
                param.oldFile = tmpmsg.GroupName + ":"+ fmsg.FileName ;
                param.isColor = fmsg.PrintColor == "彩色" ? true : false;
                param.PaperSource = int.Parse(fmsg.PaperType.Split(':')[0].Replace("纸张类型", "")) - 1;
                param.printerName = fmsg.Printer;
                param.Sum = short.Parse(fmsg.Count);
                if (param.Sum == 0)
                {
                    //MessageBox.Show("文件份数不能为0");
                    fmsg.state = "3";
                    continue;
                }
                bool fail = false;
                if (FileInfoMsg.GetFileKB(param.FileName)/ float.Parse(fmsg.PageCount) > 200)
                {
                    for (int i = 0; i < param.Sum; i++)
                    {
                        if (!filePrintermsg.pdf_Printer(param, out filePrintermsg.str,1, isFast))
                        {
                            fail = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (!filePrintermsg.pdf_Printer(param, out filePrintermsg.str, param.Sum, isFast))
                    {
                        fail = true;
                    }
                }
                if (fail)
                {
                    fmsg.state = "-1";
                    continue;
                }
                fmsg.state = "3";
                fmsg.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //SqlModlus.InsertFileMsg(fmsg,tmpmsg.GroupName);
            }
            return true;
        };

        public bool pdf_Printer(printerParam param, out string resultString, bool isFast)
        {
            if (isFast)
                return pdf_Printer_fast(param,1, out resultString);
            else
                return pdf_PrinterLow(param,1, out resultString);
        }

        public bool pdf_Printer(printerParam param, out string resultString,int copys, bool isFast)
        {
            if (isFast)
                return pdf_Printer_fast(param, copys, out resultString);
            else
                return pdf_PrinterLow(param, copys, out resultString);
        }

        /// <summary>
        /// PDF打印
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool pdf_PrinterLow(printerParam param,int copys,out string resultString)
        {
            resultString = "";
            PdfDocument pdf = new PdfDocument();
            try
            {
                //PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(param.FileName);
                pdf.PrintSettings.PrinterName = param.printerName;
                //pdf.PrintSettings.SelectSplitPageLayout();
                pdf.PrintSettings.DocumentName = param.oldFile;
                pdf.PrintSettings.Collate = true;
                pdf.PrintSettings.Copies = Convert.ToInt16(copys);
                pdf.PrintSettings.PrintController = new StandardPrintController();
                if (param.isColor)
                    pdf.PrintSettings.Color = true;
                pdf.PrintSettings.PaperSettings += delegate (object sender, PdfPaperSettingsEventArgs e)
                {
                    if (!param.isColor)
                    {
                        if (e.PaperSources.Count() <= param.PaperSource)
                        {
                            MessageBox.Show("纸盒参数错误！");
                            throw new Exception();
                        }
                        else
                            e.CurrentPaperSource = e.PaperSources[param.PaperSource];
                    }
                    else
                    {
                        e.CurrentPaperSource = e.PaperSources.ToList().Find(t=>t.SourceName.Contains("纸盘 " + (param.PaperSource + 1).ToString()));
                        if (e.CurrentPaperSource == null)
                            throw new Exception("纸盒参数错误！");
                    }
                };
                pdf.PrintSettings.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    if (pdf.Pages[0].Size.Width > pdf.Pages[0].Size.Height)
                        e.PageSettings.Landscape = true;
                    else
                        e.PageSettings.Landscape = false;
                    //e.PageSettings.Margins.Left = Math.Max(0, (int)(pdf.PrintSettings.PaperSize.Width - pdf.Pages[0].Size.Width) / 2);
                    //e.PageSettings.Margins.Left = Math.Max(0, (int)(pdf.PrintSettings.PaperSize.Height - pdf.Pages[0].Size.Height) / 2);
                };
                //int left = Math.Max(0, (int)(pdf.PrintSettings.PaperSize.Width - pdf.Pages[0].Size.Width) / 2 );
                //int top = Math.Max(0, (int)(pdf.PrintSettings.PaperSize.Height - pdf.Pages[0].Size.Height) / 2);
                //pdf.PrintSettings.SetPaperMargins(top, top,left,left);
                bool isDuplex = pdf.PrintSettings.CanDuplex;
                if (!isDuplex)
                {
                    if (param.DoubleForm)
                    {
                        MessageBox.Show("该打印机不支持双面打印");
                        pdf.Close();
                        return false;
                    }
                    else
                        pdf.PrintSettings.Duplex = System.Drawing.Printing.Duplex.Simplex;
                }
                else
                {
                    if (param.DoubleForm)
                    {
                        if (pdf.Pages[0].Size.Width> pdf.Pages[0].Size.Height)
                            pdf.PrintSettings.Duplex = System.Drawing.Printing.Duplex.Horizontal;
                        else
                            pdf.PrintSettings.Duplex = System.Drawing.Printing.Duplex.Vertical;
                    }    
                    else
                        pdf.PrintSettings.Duplex = System.Drawing.Printing.Duplex.Simplex;
                }
                pdf.Print();
                return true;
            }
            catch (Exception ex)
            {
                resultString += ex.Message + ";";
                pdf.Close();
                return false;
            }
        }

        public bool pdf_Printer_fast(printerParam param,int copys, out string resultString)
        {
            resultString = "";
            PDFFile pdf = PDFFile.Open(param.FileName);
            try
            {
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = param.printerName;
                settings.PrintToFile = false;
                if(!settings.IsValid)
                    throw new Exception("打印机："+ param.printerName + "无效");
                //设置纸张大小（可以不设置，取默认设置）3.90 in,  8.65 in
                PaperSize ps = new PaperSize("test", 4, 9);
                ps.RawKind = 9; //如果是自定义纸张，就要大于118，（A4值为9，详细纸张类型与值的对照请看http://msdn.microsoft.com/zh-tw/library/system.drawing.printing.papersize.rawkind(v=vs.85).aspx）
                O2S.Components.PDFRender4NET.Printing.PDFPrintSettings pdfPrintSettings = new O2S.Components.PDFRender4NET.Printing.PDFPrintSettings(settings);
                pdfPrintSettings.PaperSize = ps;
                pdfPrintSettings.PageScaling = O2S.Components.PDFRender4NET.Printing.PageScaling.FitToPrinterMarginsProportional;
                pdfPrintSettings.PrinterSettings.Collate = true;
                if (pdf.GetPageSize(0).Width > pdf.GetPageSize(0).Height)
                    pdfPrintSettings.PrinterSettings.DefaultPageSettings.Landscape = true;
                else
                    pdfPrintSettings.PrinterSettings.DefaultPageSettings.Landscape = false;
                pdfPrintSettings.PrinterSettings.Copies = Convert.ToInt16(copys);
                if (!param.isColor)
                {
                    if (pdfPrintSettings.PrinterSettings.PaperSources.Count <= param.PaperSource)
                    {
                        //MessageBox.Show("纸盒参数错误！");
                        throw new Exception("纸盒参数错误！");
                    }
                    else
                        pdfPrintSettings.PaperSource = pdfPrintSettings.PrinterSettings.PaperSources[param.PaperSource];
                }
                else
                {
                    for (int i = 0; i < pdfPrintSettings.PrinterSettings.PaperSources.Count; i++)
                    {
                        if (pdfPrintSettings.PrinterSettings.PaperSources[i].SourceName.ToString().Contains("纸盘 " + (param.PaperSource + 1).ToString()))
                            pdfPrintSettings.PaperSource = pdfPrintSettings.PrinterSettings.PaperSources[i];
                    }
                    if (pdfPrintSettings.PaperSource == null)
                        throw new Exception("纸盒参数错误！");
                }
                pdfPrintSettings.PrinterSettings.DefaultPageSettings.Margins.Left = Math.Max(0, (int)(pdfPrintSettings.PrinterSettings.DefaultPageSettings.PaperSize.Width - pdf.GetPageSize(0).Width) / 2);
                pdfPrintSettings.PrinterSettings.DefaultPageSettings.Margins.Top = Math.Max(0, (int)(pdfPrintSettings.PrinterSettings.DefaultPageSettings.PaperSize.Height - pdf.GetPageSize(0).Height) / 2);
                if (param.isColor)
                {
                    pdfPrintSettings.PrinterSettings.DefaultPageSettings.Color = true;
                }
                bool isDuplex = pdfPrintSettings.PrinterSettings.CanDuplex;
                if (!isDuplex)
                {
                    if (param.DoubleForm)
                    {
                        throw new Exception("该打印机不支持双面打印！");
                    }
                    else
                        pdfPrintSettings.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Simplex;
                }
                else
                {
                    if (param.DoubleForm)
                    {
                        if (pdf.GetPageSize(0).Width > pdf.GetPageSize(0).Height)
                            pdfPrintSettings.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Horizontal;
                        else
                            pdfPrintSettings.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Vertical;
                    }
                    else
                        pdfPrintSettings.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Simplex;
                }
                pdf.Print(pdfPrintSettings);
                pdf.Dispose();
                resultString = "";
                return true;
            }
            catch (Exception ex)
            {
                resultString += ex.Message + ";";
                pdf.Dispose();
                return false;
            }
        }
    }
}
