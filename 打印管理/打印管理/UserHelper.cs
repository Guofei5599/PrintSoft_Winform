using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace 打印管理
{
    public class UserHelper
    {
        private static bool RunFlag = false;
        private static IAsyncResult Iar;

        public static List<FileMsg> GetAllFile(DirectoryInfo root, string userName, string userID,string newPath,string oldPath)
        {
            List<FileMsg> tmpList = new List<FileMsg>();
            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] info = root.GetDirectories();
            foreach (var v in files)
            {
                if ((v.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                if (v.Extension.ToUpper() == "")
                    continue;
                if (v.Extension.ToUpper() == ".RAR")
                    continue;
                if (v.Extension.ToUpper() == ".ZIP")
                    continue;
                double filesize = System.Math.Ceiling(v.Length / 1024.0);
                //string strSize = "";
                //if (filesize > 1024)
                //    strSize = Math.Round((filesize / 1024.0), 2).ToString() + "M";
                //else
                //    strSize = filesize.ToString() + "K";
                if (v.Extension.ToUpper() == ".PDF")
                {
                    if (v.Name.IndexOf("W2P_tmp~W2P_tmp~") == 0)
                        continue;
                    string tmpPageCount = FileHelper.GetPDFofPageCount(v.FullName).ToString();
                    if (tmpPageCount == "-1")
                    {
                        tmpList.Add(new FileMsg()
                        {
                            FileSize = filesize,
                            UserID = userID,
                            FullName = newPath + "\\" + v.FullName.Replace(oldPath, "").Trim('\\'),
                            FileName = v.Name,
                            PageCount = "----",
                            Count = "1",
                            PrintColor = "黑白",
                            VerForm = "正反",
                            LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            state = "0",
                            isNew = true,
                            isInit = true,
                            isNormalFile = true
                        });
                    }
                    else
                    {
                        tmpList.Add(new FileMsg()
                        {
                            FileSize = filesize,
                            UserID = userID,
                            FullName = newPath + "\\" + v.FullName.Replace(oldPath, "").Trim('\\'),
                            FileName = v.Name,
                            PageCount = tmpPageCount,
                            Count = "1",
                            PrintColor = "黑白",
                            VerForm = (tmpPageCount == "1" ? "单面" : "正反"),
                            LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            state = "0",
                            isNew = true,
                            isInit = true
                        });
                    }
                    
                }
                else if (v.Extension.ToUpper() == ".DOC" || v.Extension.ToUpper() == ".DOCX")
                {
                    string newFileName1 = WordToPdf.GetPdfName(v.FullName);
                    string newFileName = WordToPdf.GetPdfPath(v.FullName);
                   
                    if (File.Exists(newFileName))
                    {
                        string tmpPageCount = FileHelper.GetPDFofPageCount(newFileName).ToString();
                        tmpList.Add(new FileMsg()
                        {
                            FileSize = filesize,
                            UserID = userID,
                            FullName = newPath + "\\" + newFileName.Replace(oldPath, "").Trim('\\'),
                            FileName = v.Name,
                            PageCount = tmpPageCount,
                            Count = "1",
                            PrintColor = "黑白",
                            VerForm = tmpPageCount == "1"?"单面": "正反",
                            LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            state = "0",
                            isNew = true,
                            isInit = true
                        });
                    }
                    else
                    {
                        WTPMsg wTPMsg = new WTPMsg();
                        string[] tmpStr = v.FullName.Split('\\');
                        wTPMsg.FileName = tmpStr[tmpStr.Count() - 1];
                        wTPMsg.FullFileName = v.FullName;
                        wTPMsg.UserName = userName;
                        LogOperate.Add("刷新检测Word没有转化,当前路径：" + newFileName + "," + userName);
                        WordToPdf.AddMsg(wTPMsg);
                        return null;
                    }
                }
                else
                {
                    tmpList.Add(new FileMsg()
                    {
                        FileSize = filesize,
                        UserID = userID,
                        FullName = newPath +"\\" + v.FullName.Replace(oldPath, "").Trim('\\'),
                        FileName = v.Name,
                        PageCount = "----",
                        Count = "1",
                        PrintColor = "黑白",
                        VerForm = "正反",
                        LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        state = "0",
                        isNew = true,
                        isInit = true,
                        isNormalFile = true
                    });
                }
            }
            foreach (DirectoryInfo dir in info)
            {
                tmpList.AddRange(GetAllFile(dir, userName, userID, newPath, oldPath));
            }
            return tmpList;
        }

        public static void GetUserMsg(string root)
        {
            string destPath = System.Windows.Forms.Application.StartupPath + @"\tmpCaeaload";
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);
            int i = 0;
            DirectoryInfo tmpRootInfo = new DirectoryInfo(root);
            List<GroupMsg> tmpList = new List<GroupMsg>();

            DirectoryInfo[] tmpInfoArray = tmpRootInfo.GetDirectories();
            foreach (var tmpInfo in tmpInfoArray)
            {
                if (frm_Main.bExit)
                    break;
                if (FileHelper.GetFileCount(tmpInfo) == 0)
                {
                    //tmpInfo.Delete();
                    //MessageBox.Show("文件夹：" + tmpInfo.Name + " 异常！");
                    LogOperate.Add("文件夹：" + tmpInfo.Name + "为空");
                    //tmpInfoArray = tmpRootInfo.GetDirectories();
                    continue;
                }
                List<FileMsg> tmpFileMsg = new List<FileMsg>();
                string tmps = destPath + "\\" + tmpInfo.Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "(_caeaload)";
                string newName = tmps.Replace(destPath + "\\", "");
                if ((tmpFileMsg = GetAllFile(tmpInfo, tmpInfo.Name, newName, tmps, tmpInfo.FullName)) != null && tmpFileMsg.Count != 0)
                {
                    try
                    {
                        newName = tmpInfo.Name;
                        LogOperate.Add("开始移动订单：" + tmpInfo.Name);
                        tmpInfo.MoveTo(tmps);
                    }
                    catch (Exception ex)
                    {
                        LogOperate.Add("移动订单失败：" + tmpInfo.Name + "," + ex.Message);
                        //MessageBox.Show("移动订单失败：" + tmpInfo.Name + "," + ex.Message);
                        Thread.Sleep(100);
                        tmpInfoArray = tmpRootInfo.GetDirectories();
                        continue;
                    }

                    GroupMsg groupmsg = new GroupMsg()
                    {
                        UserID = tmpInfo.Name,
                        CreateTime = tmpInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        FileMsgList = tmpFileMsg,
                        LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        FileDirectory = frm_Main.CurrentPath,
                        state = "0",
                        GroupName = newName,
                        Count = "1",
                        PageCount = tmpFileMsg.Sum(t => t.PageCount == "----" ? 0 : int.Parse(t.PageCount)).ToString(),
                        //initPageCount = tmpFileMsg.Sum(t => t.PageCount == -1 ? 0 : t.PageCount),
                        VerForm = "正反",
                        PrintColor = "黑白",
                        PaperType = GetPaperType.defaultBWPaper,
                        Printer = GetPrinterType.defaultBWPrinter,
                        PayType = "4",
                        SetTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        FullName = tmpInfo.FullName.Trim('\\'),
                        isInit = true
                    };
                    groupmsg.FileName = groupmsg.GetDisplayFileName();
                    groupmsg.InitPageCount = groupmsg.PageCount;
                    groupmsg.InitPrice = "-2";
                    tmpList.Add(groupmsg);
                    Thread.Sleep(10);
                }
                else
                    Thread.Sleep(100);
            }
            #region
            //while (tmpInfoArray.Count() > 0)
            //{
            //    if (frm_Main.bExit)
            //        break;
            //    DirectoryInfo tmpInfo = tmpInfoArray[0];
            //    if (FileHelper.GetFileCount(tmpInfo) == 0)
            //    {
            //        //tmpInfo.Delete();
            //        MessageBox.Show("文件夹：" + tmpInfo.Name + " 异常！");
            //        tmpInfoArray = tmpRootInfo.GetDirectories();
            //        continue ;
            //    }
            //    List<FileMsg> tmpFileMsg = new List<FileMsg>(); 
            //    string tmps = destPath + "\\" + tmpInfo.Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "(_caeaload)";
            //    string newName = tmps.Replace(destPath + "\\","");
            //    if ((tmpFileMsg = GetAllFile(tmpInfo, tmpInfo.Name, newName, tmps, tmpInfo.FullName)) != null && tmpFileMsg.Count != 0)
            //    {
            //        try
            //        {
            //            newName = tmpInfo.Name;
            //            LogOperate.Add("开始移动订单：" + tmpInfo.Name);
            //            tmpInfo.MoveTo(tmps);
                        
            //        }
            //        catch (Exception ex)
            //        {
            //            LogOperate.Add("移动订单失败：" + tmpInfo.Name + "," + ex.Message);
            //            MessageBox.Show("移动订单失败：" + tmpInfo.Name + "," + ex.Message);
            //            Thread.Sleep(100);
            //            tmpInfoArray = tmpRootInfo.GetDirectories();
            //            continue;
            //        }
                   
            //        GroupMsg groupmsg = new GroupMsg()
            //        {
            //            UserID = tmpInfo.Name,
            //            CreateTime = tmpInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
            //            FileMsgList = tmpFileMsg,
            //            LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //            FileDirectory = frm_Main.CurrentPath,
            //            state = "0",
            //            GroupName = newName,
            //            Count = "1",
            //            PageCount = tmpFileMsg.Sum(t => t.PageCount == "----" ? 0: int.Parse( t.PageCount)).ToString(),
            //            //initPageCount = tmpFileMsg.Sum(t => t.PageCount == -1 ? 0 : t.PageCount),
            //            VerForm = "正反",
            //            PrintColor = "黑白",
            //            PaperType = GetPaperType.defaultBWPaper,
            //            Printer = GetPrinterType.defaultBWPrinter,
            //            PayType = "4",
            //            SetTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //            FullName = tmpInfo.FullName.Trim('\\'),
            //            isInit = true
            //        };
            //        groupmsg.FileName = groupmsg.GetDisplayFileName();
            //        groupmsg.InitPageCount = groupmsg.PageCount;
            //        groupmsg.InitPrice = "-2";
            //        tmpList.Add(groupmsg);
            //        Thread.Sleep(10);
            //    }
            //    else
            //        Thread.Sleep(100);
            //    tmpInfoArray = tmpRootInfo.GetDirectories();
            //}
            #endregion
            foreach (var v in tmpList)
            {
                UserDB userDB = SqlModlus.selectUserMsg(v.GroupName);
                v.Printer = v.FileMsgList.Count() == v.FileMsgList.Count(t => t.isNormalFile) ? "----" : GetPrinterType.defaultBWPrinter;
                v.PaperType = GetPaperType.defaultBWPaper;
                v.Area = FileHelper.addrList.Contains(userDB.lastAddr) ? userDB.lastAddr : null;
                v.Phone = userDB.phone;
                foreach (var subv in v.FileMsgList)
                {
                    subv.Printer = subv.isNormalFile ? "----" : GetPrinterType.defaultBWPrinter;
                    subv.PaperType = GetPaperType.defaultBWPaper;
                    subv.Price = subv.GetPrice();
                    subv.InitPrice = "-2";
                }
                v.Price = v.GetPrice() ;
                v.GetDisplayVerForm();
            }

            foreach (var v in tmpList)
            {
                if (v.FileMsgList.Count == 0)
                {
                    MessageBox.Show("订单有效文件为空！");
                    continue;
                }
                if(!SqlModlus.InsertTmpUserMsg(v))
                {
                    MessageBox.Show("订单保存异常！");
                }
                Thread.Sleep(1);
                foreach (var v1 in v.FileMsgList)
                {
                    if (!SqlModlus.InsertTmpFileMsg(v1))
                    {
                        MessageBox.Show("文件保存异常！");
                    }
                    Thread.Sleep(1);
                }
            }
            if (main.groupList == null)
                main.groupList = new List<GroupMsg>();
            foreach (var v in main.groupList)
            {
                if (v.isRemove)
                    continue;
                if (v.isManual)
                {
                    v.isInit = true;
                    continue;
                }
            }
            main.groupList.AddRange(tmpList);
            main.groupList.ForEach(t => t.isPrint = false);
            //main.groupList.RemoveAll(t => t.isRemove == true);
        }

        public void dealMsg()
        {
            List<string> paperList1 = GetPaperType.GetPaperList("黑白");
            List<string> printerList1 = GetPrinterType.GetPrinterList("黑白");
            foreach (var v in main.groupList)
            {

            }
        }

        public static bool isRefresh = false;
        public static void RefreshUser(string root)
        {
            isRefresh = true;
            act.BeginInvoke(root,callback,null);
        }

        private static void callback(IAsyncResult ar)
        {
            act.EndInvoke(ar);
            main.doRefresh = true;
            isRefresh = false;
        }

        public static Action<string> act = (string root) =>
         {
             try
             {
                 GetUserMsg(root);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {

                 //ConfigClass.SaveCookie_List(main.groupList, "cookie.dat");
             }
         };
    }
}
