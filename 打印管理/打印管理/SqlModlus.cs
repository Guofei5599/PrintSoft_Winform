using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public class SqlModlus
    {
        public static SQLiteDataReader getUserMsg(string username,string userid)
        {
            string sql = string.Format(@"select DISTINCT
                                        UserID,
                                        UserName,
                                        PayType,
                                        Price,
                                        FileCount,
                                        活动折扣,
                                        附加费用,
                                        起步价,
                                        配送费,
                                        Time,
                                        Aera,
                                        State,
                                        Directory,
                                        LoadTime,
                                        FinishTime,
                                        Note,
                                        Phone,
                                        FileName,
                                        VerForm,
                                        FileSize,
                                        Count from 订单信息 where UserName = '{0}' and UserID = '{1}' ", username, userid);
            return SQLiteHelper.ExecuteDataReader(sql);
        }
        public static SQLiteDataReader getUserAllMsg(string date1,string date2)
        {
            string sql = string.Format(@"select DISTINCT
                                        UserID,
                                        UserName,
                                        PayType,
                                        Price,
                                        FileCount,
                                        `活动折扣`,
                                        `附加费用`,
                                        `起步价`,
                                        `配送费`,
                                        Time,
                                        Aera,
                                        State,
                                        `Directory`,
                                        LoadTime,
                                        FinishTime,
                                        Note,
                                        Phone,
                                        FileName,
                                        VerForm,
                                        FileSize,
                                        Count from 订单信息 where FinishTime > '{0}' and FinishTime < '{1}' ", date1,date2);
            return SQLiteHelper.ExecuteDataReader(sql);
        }
        public static SQLiteDataReader getFileMsg(string userID)
        {
            string sql = string.Format(@"select DISTINCT
                                        UserID,
                                        UserName,
                                        FileName,
                                        Count,
                                        VerForm,
                                        PrinterColor,
                                        PaperType,
                                        Printer,
                                        PageCount,
                                        PaperPrice,
                                        Price,
                                        State,
                                        LoadTime,
                                        FinishTime,
                                        FileSize,
                                        ModifyTime from 文件信息 where UserID = '{0}' ", userID);
            return SQLiteHelper.ExecuteDataReader(sql);
        }
        public static bool InsertUserMsg(GroupMsg groupMsg)
        {
            try
            {
                string sql1 = string.Format(@"INSERT into 订单信息( userID,UserName,PayType,Price,Time,Aera,State,Directory,LoadTime,FinishTime,Note,Phone,FileName,VerForm,Count,FileSize) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',{15})",
                    groupMsg.UserID.ToString(), groupMsg.GroupName, groupMsg.PayType, groupMsg.Price == "----"?"0": groupMsg.Price, groupMsg.Time, groupMsg.Area, groupMsg.state.ToString(),groupMsg.FileDirectory.ToString(), groupMsg.LoadTime, 
                    groupMsg.FinishTime, groupMsg.Note == null?"":groupMsg.Note.ToString(), groupMsg.Phone == null?"":groupMsg.Phone.ToString(),groupMsg.FileName == null?"": groupMsg.FileName,groupMsg.VerForm,groupMsg.Count.ToString(),groupMsg.fileSize);
                sql1 = sql1.Replace("\\", "\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                return i > 0?true:false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool UpdateUserMsg(GroupMsg groupMsg)
        {
            try
            {
                string sql1 = string.Format(@"update 订单信息 set userID = '{0}',UserName = '{1}',PayType = '{2}',Price = '{3}',Time = '{4}',Aera = '{5}',State = '{6}',Directory = '{7}',LoadTime = '{8}',FinishTime = '{9}',Note = '{10}',Phone = '{11}',FileName = '{12}',VerForm = '{13}',Count = '{14}',FileSize = {15} where userID = '{16}' ",
                    groupMsg.UserID.ToString(), groupMsg.GroupName, groupMsg.PayType, groupMsg.Price == "----" ? "0" : groupMsg.Price, groupMsg.Time, groupMsg.Area, groupMsg.state.ToString(), groupMsg.FileDirectory.ToString(), groupMsg.LoadTime,
                    groupMsg.FinishTime, groupMsg.Note == null ? "" : groupMsg.Note.ToString(), groupMsg.Phone == null ? "" : groupMsg.Phone.ToString(), groupMsg.FileName == null ? "" : groupMsg.FileName, groupMsg.VerForm, groupMsg.Count.ToString(),groupMsg.fileSize.ToString(), groupMsg.UserID.ToString());
                sql1 = sql1.Replace("\\", "\\\\");
                SQLiteHelper.ExecuteNonQuery(sql1);
                //}
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool deleteUserMsg(string UserID)
        {
            try
            {
                string sql = string.Format("delete from 订单信息 where userID = '{0}'", UserID);
                SQLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }

        public static bool InsertFileMsg(FileMsg fileMsg,string username)
        {
            try
            {
                string sql1 = string.Format(@"INSERT INTO 文件信息 (UserID, UserName, FileName, Count, VerForm, PrinterColor, PaperType, Printer, PageCount, Price, State, LoadTime, FinishTime, ModifyTime,FileSize) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}',{14})",
                        fileMsg.UserID.ToString(), username, fileMsg.FileName,fileMsg.Count.ToString(),fileMsg.VerForm.ToString(),fileMsg.PrintColor.ToString(),fileMsg.PaperType.Split(':')[0],fileMsg.Printer,fileMsg.PageCount == "-1"?"0": fileMsg.PageCount.ToString(), (fileMsg.Price== "" || fileMsg.Price == "----") ?"0": fileMsg.Price, fileMsg.state.ToString(),fileMsg.LoadTime,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),"",fileMsg.FileSize.ToString());
                sql1 = sql1.Replace("\\", "\\\\");
                SQLiteHelper.ExecuteNonQuery(sql1);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool deleteFileMsg(string UserID,string filename)
        {
            try
            {
                string sql = string.Format("delete from 文件信息 where userID = '{0}' and FileName = '{1}'", UserID, filename);
                SQLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool deleteAllFileMsg(string UserID)
        {
            try
            {
                string sql = string.Format("delete from 文件信息 where userID = '{0}' ", UserID);
                SQLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool InsertUserMsg(UserDB userdb)
        {
            try
            {
                string sql1 = string.Format(@"INSERT INTO `UserTable` (`UserName`, `LastAddr`, `Phone`, `LastTime`, `Note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                        userdb.userName, userdb.lastAddr, userdb.phone, userdb.lastTime.ToString("yyyy-MM-dd HH:mm:ss"), userdb.note);
                sql1 = sql1.Replace("\\", "\\\\");
                SQLiteHelper.ExecuteNonQuery(sql1);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static UserDB selectUserMsg(string UserName)
        {
            try
            {
                UserDB userDB = new UserDB();
                string sql1 = string.Format(@"select * from usertable where UserName = '{0}' ORDER BY usertable.LastTime DESC ", UserName);
                SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql1);
                while (msdr.Read())
                {
                    userDB.userName = (msdr["UserName"] == DBNull.Value|| msdr["UserName"] == null)?"": msdr["UserName"].ToString();
                    userDB.phone = (msdr["Phone"] == DBNull.Value || msdr["Phone"] == null) ? "" : msdr["Phone"].ToString();
                    userDB.lastAddr = (msdr["LastAddr"] == DBNull.Value || msdr["LastAddr"] == null) ? "" : msdr["LastAddr"].ToString();
                    break;
                }
                msdr.Close();
                return userDB;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new UserDB();
            }
        }
        public static bool UpdateUserMsg(UserDB userdb)
        {
            try
            {
                string sql1 = string.Format(@"Update `UserTable` set `LastAddr` =  '{0}' , `Phone` = '{1}', `LastTime` = '{2}', `Note` = '{3}' where UserName = '{4}' ",
                         userdb.lastAddr, userdb.phone, userdb.lastTime.ToString("yyyy-MM-dd HH:mm:ss"), userdb.note, userdb.userName);
                SQLiteHelper.ExecuteNonQuery(sql1);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool DeleteUserMsg(UserDB userdb)
        {
            try
            {
                string sql1 = string.Format(@"DELETE FROM UserTable WHERE UserName = '{0}' ", userdb.userName);
                SQLiteHelper.ExecuteNonQuery(sql1);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //public static MySqlDataReader GetUserMsg(UserDB userdb)
        //{
        //    try
        //    {
        //        string sql1 = string.Format(@"SELECT SUM(a.Price) 'Price',b.* FROM 订单信息 a LEFT JOIN UserTable b on a.UserName = b.UserName WHERE a.UserName = '{0}' ", userdb.userName);
        //        return SqlHelper.GetMsdr(sql1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}
        public static bool ChecUserExist(UserDB userdb)
        {
            try
            {
                string sql1 = string.Format(@" select count(*) from UserTable WHERE UserName = '{0}' ", userdb.userName);
                object obj = SQLiteHelper.ExecuteScalar(sql1);
                if (Convert.ToInt32(obj) != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static SQLiteDataReader GetAllUserMsg()
        {
            try
            {
                string sql1 = string.Format(@"SELECT DISTINCT
                                            UserName,
                                            LastAddr,
                                            Phone,
                                            LastTime,
                                            Note FROM  UserTable  ");
                return SQLiteHelper.ExecuteDataReader(sql1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static float GetPriceSum(UserDB userdb)
        {
            SQLiteDataReader msdr = null;
            try
            {
                string sql1 = string.Format(@"SELECT DISTINCT UserID,Price FROM 订单信息 where UserName = '{0}' ", userdb.userName);
                float f = 0;
                msdr = SQLiteHelper.ExecuteDataReader(sql1);
                while (msdr.Read())
                {
                    if (msdr[1] == null || msdr[1] == DBNull.Value || msdr[1].ToString() == "")
                        f += 0;
                    else
                        f += Convert.ToSingle(msdr[1] );
                }
                msdr.Close();
                return f;
            }
            catch (Exception ex)
            {
                if (msdr != null)
                    msdr.Close();
                //object b =msdr[1];
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static GroupMsg GetGroupMsg(string UserID,string UserName)
        {
            GroupMsg groupMsg = new GroupMsg();
            groupMsg.FileMsgList = new List<FileMsg>();
            SQLiteDataReader msdr = getUserMsg(UserName,UserID);
            while (msdr.Read())
            {
                groupMsg.GroupName = msdr["UserName"].ToString();
                groupMsg.Note = msdr["Note"].ToString() == ""?"  ": msdr["Note"].ToString();
                groupMsg.Area = msdr["Aera"].ToString();
                groupMsg.Time = msdr["Time"].ToString();
                groupMsg.Price = msdr["Price"].ToString();
                groupMsg.FileName = msdr["FileName"].ToString();
                groupMsg.VerForm = msdr["VerForm"].ToString();
                groupMsg.Count = msdr["Count"].ToString();
                groupMsg.Phone = msdr["Phone"].ToString();
            }
            msdr.Close();
            msdr = null;
            msdr = getFileMsg(UserID);
            while (msdr.Read())
            {
                FileMsg fileMsg = new FileMsg();
                fileMsg.Printer = msdr["Printer"].ToString();
                fileMsg.FileName = msdr["FileName"].ToString();
                fileMsg.Count = msdr["Count"].ToString();
                fileMsg.VerForm = msdr["VerForm"].ToString() ;
                fileMsg.FileSize = (double)msdr["FileSize"];
                groupMsg.FileMsgList.Add(fileMsg);
            }
            if (groupMsg.FileMsgList == null || groupMsg.FileMsgList.Count == 0)
                groupMsg.isManual = true;
            msdr.Close();
            return groupMsg;
        }

        public static void SaveGroupMsg(GroupMsg msg)
        {
            UpdateTmpUserMsg(msg);
            if (int.Parse(msg.state) >= 3)
            {
                UpdateUserMsg(msg);
                if (!msg.isManual)
                {
                    UserDB udb = new UserDB() { userName = msg.GroupName, lastAddr = msg.Area, lastTime = DateTime.Parse(msg.LoadTime), phone = msg.Phone };
                    main.InsertOrUpdateUser(udb);
                }
            }
            if (msg.FileMsgList != null)
            {
                foreach(var v in msg.FileMsgList)
                    UpdateTmpFileMsg(v);
            }
        }

        public static bool DeleteGroupMsg(GroupMsg msg)
        {
           return deleteAllFileMsg(msg.UserID) && deleteUserMsg(msg.UserID) && deleteAllTmpFileMsg(msg.UserID) && deleteTmpUserMsg(msg);
        }

        public static bool DeleteFileMsg(string userID, string fileName,string fullName)
        {
           return deleteFileMsg(userID,fileName) && deleteTmpFileMsg(userID, fileName,fullName);
        }

        public static List<GroupMsg> selectTmpUserMsg()
        {
            try
            {
                List<GroupMsg> GroupMsgList = new List<GroupMsg>();
                string s1 = DateTime.Now.ToString("yyyy-MM-dd");
                string s2 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                string s3 = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
                string s4 = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
                string s5 = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd");
                string sql1 = string.Format(@" select DISTINCT
                                                UserID,
                                                FileName,
                                                FullName,
                                                GroupName,
                                                FileDirectory,
                                                Count,
                                                VerForm,
                                                PrintColor,
                                                PaperType,
                                                Printer,
                                                PageCount,
                                                InitPageCount,
                                                Price,
                                                InitPrice,
                                                Time,
                                                Area,
                                                Phone,
                                                SetTime,
                                                LoadTime,
                                                FinishTime,
                                                DeleteTime,
                                                CreateTime,
                                                PayType,
                                                State,
                                                isRemove,
                                                isManual,
                                                Note,
                                                FileSize from tmpusermsg where LoadTime like '{0}%' or LoadTime like '{1}%' or LoadTime like '{2}%' or LoadTime like '{3}%' or LoadTime like '{4}%' ", s1,s2,s3,s4,s5);
                SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql1);
                while (msdr.Read())
                {
                    GroupMsg groupMsg = new GroupMsg();
                    groupMsg.UserID = msdr["UserID"] == DBNull.Value ? "" : msdr["UserID"].ToString();
                    groupMsg.FileName = msdr["FileName"] == DBNull.Value ? "" : msdr["FileName"].ToString();
                    groupMsg.FullName = msdr["FullName"] == DBNull.Value ? "" : msdr["FullName"].ToString();
                    groupMsg.GroupName = msdr["GroupName"] == DBNull.Value ? "" : msdr["GroupName"].ToString();
                    groupMsg.FileDirectory = msdr["FileDirectory"] == DBNull.Value ? "" : msdr["FileDirectory"].ToString();
                    groupMsg.Count = msdr["Count"] == DBNull.Value ? "" : msdr["Count"].ToString();
                    groupMsg.VerForm = msdr["VerForm"] == DBNull.Value ? "" : msdr["VerForm"].ToString();
                    groupMsg.PrintColor = msdr["PrintColor"] == DBNull.Value ? "" : msdr["PrintColor"].ToString();
                    groupMsg.PaperType = msdr["PaperType"] == DBNull.Value ? "" : msdr["PaperType"].ToString();
                    groupMsg.Printer = msdr["Printer"] == DBNull.Value ? "" : msdr["Printer"].ToString();
                    groupMsg.PageCount = msdr["PageCount"] == DBNull.Value ? "" : msdr["PageCount"].ToString();
                    groupMsg.InitPageCount = msdr["InitPageCount"] == DBNull.Value ? "" : msdr["InitPageCount"].ToString();
                    groupMsg.Price = msdr["Price"] == DBNull.Value ? "" : msdr["Price"].ToString();
                    groupMsg.InitPrice = msdr["InitPrice"] == DBNull.Value ? "" : msdr["InitPrice"].ToString();
                    groupMsg.Time = msdr["Time"] == DBNull.Value ? "" : msdr["Time"].ToString();
                    groupMsg.Area = msdr["Area"] == DBNull.Value ? "" : msdr["Area"].ToString();
                    groupMsg.Phone = msdr["Phone"] == DBNull.Value ? "" : msdr["Phone"].ToString();
                    groupMsg.SetTime = msdr["SetTime"] == DBNull.Value ? "" : msdr["SetTime"].ToString();
                    groupMsg.LoadTime = msdr["LoadTime"] == DBNull.Value ? "" : msdr["LoadTime"].ToString();
                    groupMsg.FinishTime = msdr["FinishTime"] == DBNull.Value ? "" : msdr["FinishTime"].ToString();
                    groupMsg.DeleteTime = msdr["DeleteTime"] == DBNull.Value ? "" : msdr["DeleteTime"].ToString();
                    groupMsg.CreateTime = msdr["CreateTime"] == DBNull.Value ? "" : msdr["CreateTime"].ToString();
                    groupMsg.PayType = msdr["PayType"] == DBNull.Value ? "" : msdr["PayType"].ToString();
                    groupMsg.state = msdr["State"] == DBNull.Value ? "" : msdr["State"].ToString();
                    string s = msdr["isRemove"] == DBNull.Value ? "0": msdr["isRemove"].ToString();
                    groupMsg.isRemove = (s ==  "0" ? false: true);
                    s = msdr["isManual"] == DBNull.Value ? "0" : msdr["isManual"].ToString();
                    groupMsg.isManual = (s == "0" ? false : true);
                    groupMsg.Note = msdr["Note"] == DBNull.Value ? "" : msdr["Note"].ToString();
                    GroupMsgList.Add(groupMsg);
                }
                msdr.Close();
                return GroupMsgList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static bool InsertTmpUserMsg(GroupMsg groupMsg)
        {
            try
            {
                string sql1 = string.Format(@"INSERT into tmpusermsg( UserID,FileName,FullName,GroupName,FileDirectory,Count,VerForm,PrintColor,PaperType,Printer,PageCount,InitPageCount,Price,InitPrice,Time,Area,Phone,SetTime,LoadTime,FinishTime,DeleteTime,CreateTime,PayType,State,isRemove,isManual,Note,FileSize) 
                                            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}')",
                                            groupMsg.UserID, groupMsg.FileName, groupMsg.FullName,groupMsg.GroupName, groupMsg.FileDirectory, groupMsg.Count, groupMsg.VerForm, groupMsg.PrintColor, groupMsg.PaperType, groupMsg.Printer,groupMsg.PageCount, groupMsg.InitPageCount, groupMsg.Price, groupMsg.InitPrice, groupMsg.Time, groupMsg.Area,
                
                                            groupMsg.Phone, groupMsg.SetTime, groupMsg.LoadTime, groupMsg.FinishTime, groupMsg.DeleteTime, groupMsg.CreateTime, groupMsg.PayType, groupMsg.state, groupMsg.isRemove?"1":"0",groupMsg.isManual?"1":"0",groupMsg.Note, groupMsg.fileSize);
                sql1 = sql1.Replace("\\","\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("插入订单：" + groupMsg.UserID + " " + s);
                if (i == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool UpdateTmpUserMsg(GroupMsg groupMsg)
        {
            try
            {
                string sql1 = string.Format(@"update tmpusermsg set UserID = '{0}',FileName = '{1}',FullName = '{2}',GroupName = '{3}',FileDirectory = '{4}',Count = '{5}',VerForm = '{6}',PrintColor = '{7}',PaperType = '{8}',Printer = '{9}',PageCount = '{10}',InitPageCount = '{11}',Price = '{12}',InitPrice = '{13}',Time = '{14}',Area = '{15}',Phone = '{16}',SetTime = '{17}',LoadTime = '{18}',FinishTime = '{19}',DeleteTime = '{20}',CreateTime = '{21}',PayType = '{22}',State  = '{23}',isRemove = '{24}',isManual  = '{25}',Note = '{26}',FileSize = '{27}' where UserID = '{28}'",
                                           groupMsg.UserID, groupMsg.FileName, groupMsg.FullName, groupMsg.GroupName, groupMsg.FileDirectory, groupMsg.Count, groupMsg.VerForm, groupMsg.PrintColor, groupMsg.PaperType, groupMsg.Printer, groupMsg.PageCount, groupMsg.InitPageCount, groupMsg.Price, groupMsg.InitPrice, groupMsg.Time, groupMsg.Area,
                                           groupMsg.Phone, groupMsg.SetTime, groupMsg.LoadTime, groupMsg.FinishTime, groupMsg.DeleteTime, groupMsg.CreateTime, groupMsg.PayType, groupMsg.state, groupMsg.isRemove ? "1" : "0", groupMsg.isManual ? "1" : "0", groupMsg.Note,groupMsg.fileSize, groupMsg.UserID);
                sql1 = sql1.Replace("\\", "\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("更新订单：" + groupMsg.UserID + " " + s);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool deleteTmpUserMsg(GroupMsg groupMsg)
        {
            try
            {
                string sql1 = string.Format(@"delete FROM tmpusermsg where UserID = '{0}' ", groupMsg.UserID);
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("删除订单：" + groupMsg.UserID + " " + s);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static List<FileMsg> selectTmpFileMsg(string userid)
        {
            try
            {
                List<FileMsg> FileMsgList = new List<FileMsg>();
                string sql1 = string.Format(@" select DISTINCT
                                                UserID,
                                                FullName,
                                                FileName,
                                                Count,
                                                state,
                                                LoadTime,
                                                FinishTime,
                                                DeleteTime,
                                                VerForm,
                                                PrintColor,
                                                PaperType,
                                                Printer,
                                                PageCount,
                                                Price,
                                                isNormalFile,
                                                isRemove,
                                                InitPrice,
                                                FileSize from tmpfilemsg  where UserID = '{0}' ", userid);
                SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql1);
                while (msdr.Read())
                {
                    FileMsg fileMsg = new FileMsg();
                    fileMsg.UserID = msdr["UserID"] == DBNull.Value ? "" : msdr["UserID"].ToString();
                    fileMsg.FileName = msdr["FileName"] == DBNull.Value ? "" : msdr["FileName"].ToString();
                    fileMsg.FullName = msdr["FullName"] == DBNull.Value ? "" : msdr["FullName"].ToString();
                    fileMsg.Count = msdr["Count"] == DBNull.Value ? "" : msdr["Count"].ToString();
                    fileMsg.VerForm = msdr["VerForm"] == DBNull.Value ? "" : msdr["VerForm"].ToString();
                    fileMsg.PrintColor = msdr["PrintColor"] == DBNull.Value ? "" : msdr["PrintColor"].ToString();
                    fileMsg.PaperType = msdr["PaperType"] == DBNull.Value ? "" : msdr["PaperType"].ToString();
                    fileMsg.Printer = msdr["Printer"] == DBNull.Value ? "" : msdr["Printer"].ToString();
                    fileMsg.PageCount = msdr["PageCount"] == DBNull.Value ? "" : msdr["PageCount"].ToString();
                    fileMsg.Price = msdr["Price"] == DBNull.Value ? "" : msdr["Price"].ToString();
                    fileMsg.InitPrice = msdr["InitPrice"] == DBNull.Value ? "" : msdr["InitPrice"].ToString();
                    fileMsg.LoadTime = msdr["LoadTime"] == DBNull.Value ? "" : msdr["LoadTime"].ToString();
                    fileMsg.FinishTime = msdr["FinishTime"] == DBNull.Value ? "" : msdr["FinishTime"].ToString();
                    fileMsg.DeleteTime = msdr["DeleteTime"] == DBNull.Value ? "" : msdr["DeleteTime"].ToString();
                    fileMsg.state = msdr["State"] == DBNull.Value ? "" : msdr["State"].ToString();
                    string s = msdr["isRemove"] == DBNull.Value ? "0" : msdr["isRemove"].ToString();
                    fileMsg.isRemove = (s == "0" ? false : true);
                    s = msdr["isNormalFile"] == DBNull.Value ? "0" : msdr["isNormalFile"].ToString();
                    fileMsg.isNormalFile = (s == "0" ? false : true);
                    fileMsg.FileSize = (double)msdr["FileSize"];
                    FileMsgList.Add(fileMsg);
                }
                msdr.Close();
                return FileMsgList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static bool InsertTmpFileMsg(FileMsg fileMsg)
        {
            try
            {
                string sql1 = string.Format(@"INSERT into tmpfilemsg( UserID,FileName,FullName,Count,VerForm,PrintColor,PaperType,Printer,PageCount,Price,LoadTime,FinishTime,DeleteTime,State,isRemove,isNormalFile,InitPrice,FileSize) 
                                            VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                                            fileMsg.UserID, fileMsg.FileName, fileMsg.FullName, fileMsg.Count, fileMsg.VerForm, fileMsg.PrintColor, fileMsg.PaperType, fileMsg.Printer, fileMsg.PageCount, fileMsg.Price,
                                            fileMsg.LoadTime, fileMsg.FinishTime, fileMsg.DeleteTime,fileMsg.state, fileMsg.isRemove ? "1" : "0", fileMsg.isNormalFile ? "1" : "0",fileMsg.InitPrice,fileMsg.FileSize);
                sql1 = sql1.Replace("\\", "\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("插入订单：" + fileMsg.UserID + " " + fileMsg.FileName + " " + s);
                if (i == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool UpdateTmpFileMsg(FileMsg fileMsg)
        {
            try
            {
                string sql1 = string.Format(@"update tmpfilemsg set UserID = '{0}',FileName = '{1}',FullName = '{2}',Count = '{3}',VerForm = '{4}',PrintColor = '{5}',PaperType = '{6}',Printer = '{7}',PageCount = '{8}',Price = '{9}',LoadTime = '{10}',FinishTime = '{11}',DeleteTime = '{12}',State  = '{13}',isRemove = '{14}',isNormalFile  = '{15}',InitPrice = '{16}' where UserID = '{17}' and FileName ='{18}' and FullName = '{19}' ",
                                            fileMsg.UserID, fileMsg.FileName, fileMsg.FullName, fileMsg.Count, fileMsg.VerForm, fileMsg.PrintColor, fileMsg.PaperType, fileMsg.Printer, fileMsg.PageCount, fileMsg.Price,
                                             fileMsg.LoadTime, fileMsg.FinishTime, fileMsg.DeleteTime, fileMsg.state, fileMsg.isRemove ? "1" : "0", fileMsg.isNormalFile ? "1" : "0", fileMsg.InitPrice, fileMsg.UserID, fileMsg.FileName, fileMsg.FullName);
                sql1 = sql1.Replace("\\", "\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("更新文件：" + fileMsg.UserID + " " + fileMsg.FileName + " " + s);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool deleteTmpFileMsg(string userID,string fileName,string fulllName)
        {
            try
            {
                string sql1 = string.Format(@"delete FROM tmpfilemsg where UserID = '{0}' and FileName ='{1}' and FullName = '{2}' ", userID, fileName,fulllName);
                sql1 = sql1.Replace("\\", "\\\\");
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("删除文件：" + userID + " " + fileName + " " + s);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool deleteAllTmpFileMsg(string userID)
        {
            try
            {
                string sql1 = string.Format(@"delete FROM tmpfilemsg where UserID = '{0}' ", userID);
                int i = SQLiteHelper.ExecuteNonQuery(sql1);
                string s = i > 0 ? "成功" : "失败";
                LogOperate.Add("删除所有文件：" + userID + " " + s);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
