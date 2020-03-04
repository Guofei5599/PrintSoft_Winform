using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 打印管理
{
    public class WTPMsg
    {
        public string FullFileName { set; get; }
        public string FileName { set; get; }
        public string UserName { set; get; }
        public bool pority { set; get; }
    }
    public class WordToPdf
    {
        public static bool RunFlag = false;
        public static List<WTPMsg> WTPFileMsgList = new List<WTPMsg>();
        public static IAsyncResult IAR;
        public static bool DoWTPMsg(WTPMsg wTPMsg)
        {
            if (!File.Exists(wTPMsg.FullFileName))
            {
                WTPFileMsgList.Remove(wTPMsg);
                return false;
            }
            if (WordToPDF(wTPMsg.FullFileName) == "")
                return false;
            WTPFileMsgList.Remove(wTPMsg);
            return true;
        }
        public static Action act = () =>
          {
              int i = 0;
              while (RunFlag)
              {
                  if (WTPFileMsgList.Count <= i)
                      i = 0;
                  if (WTPFileMsgList.Count > 0)
                  {
                      WTPMsg wTPMsg;
                      if((wTPMsg =WTPFileMsgList.Find(t=>t.pority)) == null)
                          wTPMsg = WTPFileMsgList[i];
                      if (DoWTPMsg(wTPMsg) == false)
                          i++;
                  }
                  Thread.Sleep(1);
              }
          };
        public static void AddMsg(WTPMsg wTPMsg)
        {
            if (!File.Exists(wTPMsg.FullFileName))
                return;
            if (wTPMsg.FileName.IndexOf("~$") == 0)
                return;
            if (WTPFileMsgList.FindIndex(t=>t.FullFileName == wTPMsg.FullFileName && t.UserName == wTPMsg.UserName) == -1)
                WTPFileMsgList.Add(wTPMsg);
        }
        public static void Start()
        {
            IAR = null;
            RunFlag = true;
            IAR = act.BeginInvoke(null,null);
        }
        public static void Stop()
        {
            RunFlag = false;
            act.EndInvoke(IAR);
            IAR = null;
        }
        public static string GetPdfName(string _lstrInputFile)
        {
            string[] tmpName = _lstrInputFile.Split('\\');
            string s = tmpName[tmpName.Count()-1];
            string [] tmps = s.Split('.');
            string ext = tmps[tmps.Count()-1];
            tmpName[ tmpName.Count()-1] = "W2P_tmp~W2P_tmp~" + s.Replace(ext, ext + ".pdf");
            string newname = "";
            for (int i = 0; i < tmpName.Count() - 1; i++)
            {
                newname += (tmpName[i] + "\\");
            }
            newname += tmpName[tmpName.Count()-1];
            return tmpName[tmpName.Count() - 1];
        }

        public static string WordToPDF(string _lstrInputFile)
        {
            bool result = false;
            string _lstrOutFile = GetPdfPath(_lstrInputFile);
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = null;
            try
            {
                application.Visible = false;
                try
                {
                    document = application.Documents.Open(_lstrInputFile);
                }
                catch (Exception ex)
                {
                    Password p = new Password();
                    p.path = _lstrInputFile;
                    p.ShowDialog();
                    document = application.Documents.Open(_lstrInputFile,false,true,false,p.password);
                }
                document.ExportAsFixedFormat(_lstrOutFile, WdExportFormat.wdExportFormatPDF);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                _lstrOutFile = "";
            }
            finally
            {
                document.Close();
            }
            return _lstrOutFile;
        }

        public static string GetPdfPath(string _lstrInputFile)
        {
            string[] tmpName = _lstrInputFile.Split('\\');
            string s = tmpName[tmpName.Count() - 1];
            string[] tmps = s.Split('.');
            string ext = tmps[tmps.Count() - 1];
            tmpName[tmpName.Count() - 1] = "W2P_tmp~W2P_tmp~" + s.Replace(ext, ext + ".pdf");
            string newname = "";
            for (int i = 0; i < tmpName.Count() - 1; i++)
            {
                newname += (tmpName[i] + "\\");
            }
            newname += tmpName[tmpName.Count() - 1];
            return newname;
        }

        static bool isSuccess = false;
        //public static string WordToPDF(string _lstrInputFile)
        //{
        //    isSuccess = false;
        //    string _lstrOutFile = GetPdfPath(_lstrInputFile);
        //    Microsoft.Office.Interop.Word.Application lobjWordApp = new Microsoft.Office.Interop.Word.Application();
        //    Microsoft.Office.Interop.Word.Document objDoc = null;
        //    object lobjMissing = System.Reflection.Missing.Value;
        //    object lobjSaveChanges = null;
        //    try
        //    {
        //        Object lobjFileName = (Object)_lstrInputFile;
        //        objDoc = lobjWordApp.Documents.Open(ref lobjFileName, ref lobjMissing, ref lobjMissing,
        //            ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
        //            ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing);
        //        if (objDoc.HasPassword)
        //            throw new Exception(string.Format("文档：{0} 已加密！", objDoc.Name));
        //        objDoc.Activate();
        //        Object lobjOutPutFileName = (Object)_lstrOutFile;
        //        object lobjFileFormat = WdSaveFormat.wdFormatPDF; //保存格式为PDF

        //        objDoc.SaveAs(ref lobjOutPutFileName, ref lobjFileFormat, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
        //            ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
        //            ref lobjMissing, ref lobjMissing, ref lobjMissing);

        //        lobjSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
        //        isSuccess = true;
        //        ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
        //        objDoc = null;
        //        ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
        //        lobjWordApp = null;
        //        FileAttributes myFileAttributes = File.GetAttributes(_lstrOutFile);
        //        File.SetAttributes(_lstrOutFile, myFileAttributes | FileAttributes.Hidden);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (!isSuccess)
        //        {
        //            //其他日志操作；
        //            MessageBox.Show(ex.Message);
        //            //frm_Main.preString = ex.Message;
        //            return "";
        //        }
        //    }
        //    finally
        //    {
        //        if (objDoc != null)
        //        {
        //            ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
        //            Marshal.ReleaseComObject(objDoc);
        //            objDoc = null;

        //        }
        //        if (lobjWordApp != null)
        //        {
        //            ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
        //            Marshal.ReleaseComObject(lobjWordApp);
        //            lobjWordApp = null;
        //        }

        //        //主动激活垃圾回收器，主要是避免超大批量转文档时，内存占用过多，而垃圾回收器并不是时刻都在运行！
        //        GC.Collect();
        //        //GC.WaitForPendingFinalizers();
        //    }
        //    return _lstrOutFile;
        //}
    }
}
