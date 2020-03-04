using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Spire.Pdf;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace 打印管理
{
    public class lockFile
    {
        public string Name { set; get; }
        public string FullName { set; get; }
        public FileStream fs { set; get; }
        public bool isOpen { set; get; }

        public static lockFile CreateFile(string path,string name)
        {
            if (File.Exists(path + "_.caselock"))
                File.Delete(path + "_.caselock");
            using (File.Create(path + "_.caselock")) { }
            FileAttributes myAttributes = File.GetAttributes(path+"_.caselock");
            File.SetAttributes(path + "_.caselock", myAttributes | FileAttributes.Hidden);
            return new lockFile() { FullName = path + "_.caselock", isOpen = true, Name = name + "_.caselock", fs = File.Open(path + "_.caselock", FileMode.Open) };
        }
    }
    public class FileHelper
    {
        public static List<DateTime> timelist ;
        public static List<string> addrList;
        public static Dictionary<string, string> rowMsg;
        public static List<lockFile> lockFileList = new List<lockFile>();
        public static bool CheckFlag = true;


        /// <summary>
        /// 获取pdf文档的页数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>-1表示文件不存在</returns>
        public static int GetPDFofPageCount(string filePath)
        {
            PdfDocument d;
            try
            {
                d = new PdfDocument(filePath);
            }
            catch (Exception ex)
            {
                return -1;
            }
            int sum = d.Pages.Count;
            return sum;
        }

        //public static string WordToPDF(string sourcePath,string userID)
        //{
        //    try
        //    {
        //        Aspose.Words.Document doc = new Aspose.Words.Document(sourcePath);
        //        FileInfo infp = new FileInfo(sourcePath);
        //        string s = infp.Name;
        //        string ext = infp.Extension;
        //        s = s.Replace(ext, ext + ".pdf");
        //        string FullName = infp.DirectoryName + "\\" + "W2P_tmp~W2P_tmp~" + userID+ s;
        //        if (File.Exists(FullName))
        //            File.Delete(FullName);
        //        doc.Save(FullName, SaveFormat.Pdf);
        //        FileAttributes myFileAttributes = File.GetAttributes(infp.DirectoryName + "\\" + "W2P_tmp~W2P_tmp~" + userID+s);
        //        File.SetAttributes(infp.DirectoryName + "\\" + "W2P_tmp~W2P_tmp~" + userID+ s, myFileAttributes | FileAttributes.Hidden);
        //        return FullName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("word 转 PDF失败： " + ex.Message);
        //    }
        //}
         static bool bSaveSuccess = false;
        public static string WordToPDF(string _lstrInputFile, string userID)
        {
            bSaveSuccess = false;
            FileInfo infp = new FileInfo(_lstrInputFile);
            string s = infp.Name;
            string ext = infp.Extension;
            string _lstrOutFile = infp.DirectoryName + "\\" + "W2P_tmp~W2P_tmp~" + userID + s.Replace(ext, ext + ".pdf");
            Microsoft.Office.Interop.Word.Application lobjWordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document objDoc = null;
            object lobjMissing = System.Reflection.Missing.Value;
            object lobjSaveChanges = null;
            try
            {
                Object lobjFileName = (Object)_lstrInputFile;
                objDoc = lobjWordApp.Documents.Open(ref lobjFileName, ref lobjMissing, ref lobjMissing,
                    ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                    ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing);
                objDoc.Activate();

                Object lobjOutPutFileName = (Object)_lstrOutFile;
                object lobjFileFormat = WdSaveFormat.wdFormatPDF; //保存格式为PDF

                objDoc.SaveAs(ref lobjOutPutFileName, ref lobjFileFormat, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                    ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                    ref lobjMissing, ref lobjMissing, ref lobjMissing);

                lobjSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
                bSaveSuccess = true;
                ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                objDoc = null;
                ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                lobjWordApp = null;
                FileAttributes myFileAttributes = File.GetAttributes(_lstrOutFile);
                File.SetAttributes(_lstrOutFile, myFileAttributes | FileAttributes.Hidden);

            }
            catch (Exception ex)
            {
                //其他日志操作；
                return "";
            }
            finally
            {
                if (objDoc != null)
                {
                    ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                    Marshal.ReleaseComObject(objDoc);
                    objDoc = null;

                }
                if (lobjWordApp != null)
                {
                    ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                    Marshal.ReleaseComObject(lobjWordApp);
                    lobjWordApp = null;
                }

                //主动激活垃圾回收器，主要是避免超大批量转文档时，内存占用过多，而垃圾回收器并不是时刻都在运行！
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return _lstrOutFile;
        }

        public static bool DirectoryDelete(List<GroupMsg> groupList, GroupMsg tmpmsg, string groupName,string localtime)
        {
            try
            {
                //int count = groupList.Count(t => t.GroupName == groupName);
                tmpmsg.isClearFile = true;
                lockFile lockfile = FileHelper.lockFileList.Find(t => t.Name == (groupName + "_.caselock"));
                if (!Directory.Exists(tmpmsg.FullName))
                    return true;
                DirectoryInfo root = new DirectoryInfo(tmpmsg.FullName);
                if (lockfile != null)
                {
                    lockfile.fs.Close();
                    lockfile.fs.Dispose();
                    lockfile.fs = null;
                    lockfile.isOpen = false;
                    FileHelper.lockFileList.Remove(lockfile);
                    File.Delete(tmpmsg.FullName + @"\" + lockfile.Name);
                }
                AsyncGetDeleteFile(root);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private static void deleteConcealFile(DirectoryInfo root)
        {
            var allF = root.GetFiles();
            foreach (var f in allF)
            {
                f.Delete();
            }
            DirectoryInfo[] info = root.GetDirectories();
            foreach (DirectoryInfo dir in info)
            {
                deleteConcealFile(dir);
            }
        }

        public static void AsyncGetDeleteFile(DirectoryInfo root)
        {
            Action<DirectoryInfo> act = (DirectoryInfo tmproot) =>
            {
                GetDeleteFile(tmproot);
            };
            act.BeginInvoke(root,null,null);
        }

        private static void GetDeleteFile(DirectoryInfo root)
        {
            if (!root.Exists)
                return;
            FileInfo[] files = root.GetFiles();
            foreach (var v in files)
            {
                try
                {
                    v.Delete();
                }
                catch (Exception ex)
                {

                }
            }
            DirectoryInfo[] info = root.GetDirectories();
            foreach (DirectoryInfo dir in info)
            {
                GetDeleteFile(dir);
            }
            root.Delete();
        }

        public static int GetFileCount(DirectoryInfo root)
        {
            int i = 0;
            if (!root.Exists)
                return -1;
            FileInfo[] files = root.GetFiles();
            foreach (var v in files)
            {
                if (v.Extension.ToUpper() == ".RAR")
                    continue;
                if (v.Extension.ToUpper() == ".ZIP")
                    continue;
                i++;
            }
            DirectoryInfo[] info = root.GetDirectories();
            foreach (DirectoryInfo dir in info)
            {
                i = i + GetFileCount(dir);
            }
            return i;
        }

        public static void openFile(string path)
        {
            Action<string> act = (string filepath) =>
            {
                try
                {
                    System.Diagnostics.Process.Start(filepath);
                    //File.Open(filepath, FileMode.Open);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            act.BeginInvoke(path,null,null);
        }
        public static void openDirectory(string path)
        {
            Action<string> act = (string filepath) =>
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", filepath);
                    //File.Open(filepath, FileMode.Open);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            act.BeginInvoke(path, null, null);
        }
        public static string SubStringByByte(string sourceStr,int length)
        {
            byte[] b = Encoding.Default.GetBytes(sourceStr);
            if (b.Length <= length)
                return sourceStr;
            string s1 = Encoding.Default.GetString(b, 0, length);
            if(s1.Contains("?"))
                s1 = Encoding.Default.GetString(b, 0, length+1);
            return s1;
        }
        public static string SubStringByByte2(string sourceStr, int length)
        {
            byte[] b = Encoding.Default.GetBytes(sourceStr);
            if (b.Length <= length)
                return sourceStr;
            string s1 = Encoding.Default.GetString(b, 0, length);
            if (s1.Contains("?"))
                s1 = Encoding.Default.GetString(b, 0, length + 1);
            s1 += "...";
            return s1;
        }

        public static void deleteImg(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] finfo = info.GetFiles();
            foreach (var v in finfo)
            {
                try
                {
                    File.Delete(v.FullName);
                }
                catch (Exception ex)
                {

                }
            }  
        }

        public static void CopyDirectory(string srcPath, string desPath)
        {
            string folderName = srcPath.Substring(srcPath.LastIndexOf("\\") + 1);
            string desfolderdir = desPath + "\\" + folderName;
            if (srcPath.LastIndexOf("\\") == (desPath.Length - 1))
            {
                desfolderdir = desPath + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcPath);
            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }
                    CopyDirectory(file, desfolderdir);
                }
                else
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = desfolderdir + "\\" + srcfileName;
                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }
                    File.Copy(file, srcfileName);
                }
            }
        }
    }
}
