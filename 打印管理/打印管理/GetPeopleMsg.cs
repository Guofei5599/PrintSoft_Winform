using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class GetPeopleMsg
    {
        public static List<DateTime> GetTimeList()
        {
            string sql2 = string.Format(@" SELECT * FROM 配送管理表 ");
            SQLiteDataReader msdr2 = SQLiteHelper.ExecuteDataReader(sql2);
            List<DateTime> timelist = new List<DateTime>();
            while (msdr2.Read())
            {
                if (msdr2[1].ToString().Contains("时间"))
                {
                    DateTime tmpDate = DateTime.Parse(frm_Main.CurrentDate);
                    if (msdr2[2] != null && msdr2[2].ToString() != "")
                    {
                        DateTime d1 = DateTime.Parse(tmpDate.Date.ToString().Split(' ')[0] + " " + msdr2[2].ToString());
                        timelist.Add(d1);
                    }
                    if (msdr2[3] != null && msdr2[3].ToString() != "")
                    {
                        DateTime d1 = DateTime.Parse(tmpDate.Date.ToString().Split(' ')[0] + " " + msdr2[3].ToString());
                        timelist.Add(d1);
                    }
                    if (msdr2[4] != null && msdr2[4].ToString() != "")
                    {
                        DateTime d1 = DateTime.Parse(tmpDate.Date.ToString().Split(' ')[0] + " " + msdr2[4].ToString());
                        timelist.Add(d1);
                    }
                    if (msdr2[5] != null && msdr2[5].ToString() != "")
                    {
                        DateTime d1 = DateTime.Parse(tmpDate.Date.ToString().Split(' ')[0] + " " + msdr2[5].ToString());
                        timelist.Add(d1);
                    }
                }
            }
            msdr2.Close();
            timelist.Sort();
            return timelist;
        }
        public static List<string> GetAddrList()
        {
            string sql2 = string.Format(@" SELECT * FROM 配送管理表 ");
            SQLiteDataReader msdr2 = SQLiteHelper.ExecuteDataReader(sql2);
            List<string> timelist = new List<string>();
            while (msdr2.Read())
            {
                if (msdr2[1].ToString().Contains("地址"))
                {
                    if (msdr2[2] != null && msdr2[2].ToString() != "")
                        timelist.Add(msdr2[2].ToString());
                    if (msdr2[3] != null && msdr2[3].ToString() != "")
                        timelist.Add(msdr2[3].ToString());
                    if (msdr2[4] != null && msdr2[4].ToString() != "")
                        timelist.Add(msdr2[4].ToString());
                    if (msdr2[5] != null && msdr2[5].ToString() != "")
                        timelist.Add(msdr2[5].ToString());
                }
            }
            msdr2.Close();
            return timelist;
        }
    }
}
