using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace 打印管理
{
    public class ExcelHelper
    {
        public static ConcurrentQueue<GroupMsg> PrintList = new ConcurrentQueue<GroupMsg>();
        public static bool RunFlag = false;
        public static void Start()
        {
            string Printer = frm_Main.sysConfigData.printerName;
            RunFlag = true;
            IAR = act.BeginInvoke(Printer,null,null);
        }

        public static void AddMs(GroupMsg msg)
        {
            if(!PrintList.Contains(msg))
                PrintList.Enqueue(msg);
        }

        public static void Stop()
        {
            RunFlag = false;
            act.EndInvoke(IAR);
        }
        static IAsyncResult IAR = null;
        public static Func<string,int> act = (printer) => 
        {
            while (RunFlag)
            {
                if (PrintList.Count > 0)
                {
                    GroupMsg msg;
                    if(PrintList.TryDequeue(out msg))
                            ExportExcel(msg, printer,false);
                }
                Thread.Sleep(100);
            }
            return 0;
        };
        public static void ExportExcel(GroupMsg msg,string printer,bool isPreView)
        {
            if (!File.Exists(frm_Main.sysConfigData.BarcodePath))
            {
                MessageBox.Show("获取二维码失败，请重新设置！");
                return;
            }
            int rowCount = 1;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbks = app.Workbooks.Add(true);
            Worksheet ws = (Worksheet)wbks.Worksheets[1];
            try
            {
                ws.Rows.AutoFit();
                ws.Columns[1].ColumnWidth = 20;
                ws.Columns[2].ColumnWidth = 3;
                ws.Columns[3].ColumnWidth = 5;
                int sum = 0;
                app.Rows.AutoFit();
                AddMergeText(rowCount++, ws,msg.GroupName,true,24,30,true,true,0);
                AddMergeText(rowCount++, ws,msg.Area, true, 24, 25, true, false, 0);
                if (msg.FileMsgList != null && msg.FileMsgList.Count != 0)
                {
                    var tmpVar = msg.FileMsgList.GroupBy(t => t.Printer).ToList();
                    foreach (var v in tmpVar)
                    {
                        AddMergeText(rowCount++, ws, FileHelper.SubStringByByte(v.Key, 16) + "输出", false, 10, 18, true, true, 2);
                        var Enum = v.GetEnumerator();
                        Enum.MoveNext();
                        while (true)
                        {
                            var flist = Enum.Current;
                            sum += int.Parse(flist.Count);
                            string fileName = flist.FileName;
                            string count = flist.Count.ToString();
                            string verForm = flist.VerForm.ToString();

                            if (!Enum.MoveNext() || Enum == null)
                            {
                                AddText(rowCount++, ws, new string[] { FileHelper.SubStringByByte2(fileName, 16), count, verForm }, true, 10, 18, false, 2);
                                break;
                            }
                            else
                            {
                                AddText(rowCount++, ws, new string[] { FileHelper.SubStringByByte2(fileName, 16), count, verForm }, true, 10, 18, false, 0);
                            }
                        }
                    }
                    AddMergeText(rowCount++, ws, string.Format(@"文件总数：{0}", sum.ToString()), true, 10, 18, true, false, 0);
                    AddMergeText(rowCount++, ws, "", true, 10, 10, true, false, 0);
                }
                else
                {
                    AddMergeText(rowCount++, ws, "手动输出", false, 10, 18, true, true, 2);
                    AddText(rowCount++, ws, new string[] { FileHelper.SubStringByByte2(msg.FileName, 16), msg.Count.ToString(), msg.VerForm.ToString() }, true, 10, 18, false, 0);
                    AddMergeText(rowCount++, ws, "", true, 10, 10, true, false, 1);
                }
                if (msg.Note != null && msg.Note != "")
                {
                    AddNote(rowCount++, ws, msg.Note, true, 10, 3, 0x0f);
                    rowCount = rowCount + 3;
                } 
                AddPic(rowCount++, ws,4, frm_Main.sysConfigData.BarcodePath);
                rowCount = rowCount + 4;
                AddMergeText(rowCount++, ws, msg.Price.ToString() + "元", true, 16, 25,false,false,0);
                string shopName = frm_Main.sysConfigData.ShopName;
                AddMergeText(rowCount++, ws, shopName, true, 12, 20, false, false,0);
                AddMergeText(rowCount++, ws, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), true, 12, 16, false, false, 0);
                AddMergeText(rowCount++, ws, string.Format(@"{0}/{1}", msg.Area, msg.Time), true, 18, 25, false, false, 0);
                AddMergeText(rowCount++, ws, msg.Phone==null?"":msg.Phone, true, 18, 25, false, false, 0);
                ws.PageSetup.Zoom = false;
                ws.PageSetup.FitToPagesTall = 1;
                ws.PageSetup.FitToPagesWide = 1;
                ws.PageSetup.TopMargin = 0.5 / 0.035; //上边距为2cm（转换为in）
                ws.PageSetup.BottomMargin = 0.5 / 0.035; //下边距为1.5cm
                ws.PageSetup.LeftMargin = 0.001 / 0.035; //左边距为2cm
                ws.PageSetup.RightMargin = 0.001 / 0.035; //右边距为2cm   
                ws.PageSetup.CenterHorizontally = true;
                ws.Visible =  XlSheetVisibility.xlSheetVisible;
                app.Visible = false;
                //ws.PrintPreview(true);
                if (isPreView)
                    ws.PrintPreview(true);
                else
                    ws.PrintOutEx(Missing.Value, Missing.Value, Missing.Value, Missing.Value, printer, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbks.Saved = true;
                wbks.SaveCopyAs(Environment.CurrentDirectory + @"\123.XLSX");
                app.Quit();
                app = null;
                GC.Collect();
            }
        }

        public static void AddMergeText(int rows, Worksheet ws,string value,bool isBold,int size,int height,bool isLeft,bool isBottom,int border)
        {
            Range range = ws.Range["A" + rows.ToString(), "C" + rows.ToString()];
            range.Merge();
            if (isLeft)
                range.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignLeft;
            else
                range.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignCenter;
            if (isBottom)
                range.VerticalAlignment = Microsoft.Office.Core.XlVAlign.xlVAlignBottom;
            else
                range.VerticalAlignment = Microsoft.Office.Core.XlVAlign.xlVAlignCenter;
            range.Font.Size = size;
            range.Font.Name = "等线";
            range.Font.Bold = isBold;
            range.RowHeight = height;
            ws.Cells[rows, 1] = value;
            if ((border & 0x01) == 0x01)
            {
                range.Borders.Item[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Item[XlBordersIndex.xlEdgeRight].Weight = 2;
            }
            if (((border >> 1) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 2) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 3) & 0x01) == 0x01)
            {
                range.Borders.Item[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Item[XlBordersIndex.xlEdgeRight].Weight = 2;
            }
        }
        public static void AddText(int rows, Worksheet ws, string[] value, bool isBold, int size, int height, bool isLeft,int border)
        {
            Range range = ws.Range["A" + rows.ToString(), "C" + rows.ToString()];
            Range range1 = ws.Range["A" + rows.ToString()];
            range.WrapText = true;
            range.EntireRow.AutoFit();
            range1.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignLeft;
            //if (isLeft)
            //    range.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignLeft;
            //else
            //    range.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignCenter;
            range.Font.Size = size;
            range.Font.Bold = isBold;
            
            ws.Cells[rows, 1] = value[0];
            ws.Cells[rows, 2] = value[1];
            ws.Cells[rows, 3] = value[2];
            if((border & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            if (((border>>1) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 2) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 3) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }

        public static void AddNote(int rows, Worksheet ws, string value, bool isBold, int size, int count,int border)
        {
            Range range = ws.Range["A" + rows.ToString(), "C" + (rows + count).ToString()];
            range.WrapText = true;
            range.EntireRow.AutoFit();
            range.Merge();
            range.HorizontalAlignment = Microsoft.Office.Core.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Core.XlVAlign.xlVAlignCenter;
            range.Font.Size = size;
            range.Font.Bold = isBold;
            range.RowHeight = 13.5;
            ws.Cells[rows, 1] = value;
            if ((border & 0x01) == 0x01)
            {
                range.Borders.Item[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            }
            if (((border >> 1) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 2) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            if (((border >> 3) & 0x01) == 0x01)
                range.Borders.Item[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static void AddPic(int rows, Worksheet ws,int count,string PicturePath)
        {
            int picWidth = int.Parse(ConfigClass.GetConfigString("sys", "二维码宽度", "100"));
            Range range = ws.Range["A" + rows.ToString(), "C" + (rows + count-1).ToString()];
            range.Merge();
            range.Select();
            float PicLeft, PicTop, PicWidth, PicHeight;    //距离左边距离，顶部距离，图片宽度、高度
            using (Image img = Image.FromFile(PicturePath))
            {
                PicWidth = picWidth;
                PicHeight = ((PicWidth / (float)img.Width) * (img.Height))-1;
                range.RowHeight = (int)(PicHeight / 4);
            }
            double l = range.Height;
            PicTop = Convert.ToSingle(range.Top);
            PicLeft = (Convert.ToSingle(range.Width) - PicWidth) / 2;
            ws.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft + 5, PicTop + 5, PicWidth - 10, PicHeight-10);
        }
    }

    public class sysConfig
    {
        public string printerName { set; get; }
        public string ShopName { set; get; }
        public string BarcodePath { set; get; }
    }
}
