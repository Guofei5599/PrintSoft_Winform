using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class GetPaperType
    {
        public static string[] ColorPaperList = null;
        public static string[] BWPaperList = null;
        public static string defaultColorPaper = null;
        public static string defaultBWPaper = null;
        public static List<string> GetPaperList(string paperColor)
        {
            string sql3 = string.Format(@" SELECT * FROM 纸张管理 where {0}可用 = 1 ", paperColor);
            #region 纸张信息
            SQLiteDataReader msdr3 = SQLiteHelper.ExecuteDataReader(sql3);
            List<string> paperList = new List<string>();
            while (msdr3.Read())
            {
                string s = (msdr3[6] == null || msdr3[6] == DBNull.Value) ? " " : msdr3[6].ToString();
                paperList.Add(msdr3[1].ToString()+ ":" + s);
            }
            msdr3.Close();
            return paperList;
            #endregion
        }

        public static void UpdatePaperList()
        {
            ColorPaperList = GetPaperList("彩色").ToArray();
            BWPaperList = GetPaperList("黑白").ToArray();
            defaultBWPaper = GetDefaultPaper("黑白");
            defaultColorPaper = GetDefaultPaper("彩色");
        }

        public static string GetDefaultPaper(string paperColor)
        {
            string sql3 = string.Format(@" SELECT * FROM 纸张管理 where {0}默认 = 1 ", paperColor);
            #region 纸张信息
            SQLiteDataReader msdr3 = SQLiteHelper.ExecuteDataReader(sql3);
            string paper = "----";
            while (msdr3.Read())
            {
                string s = (msdr3[6] == null || msdr3[6] == DBNull.Value) ? " " : msdr3[6].ToString();
                paper = msdr3[1].ToString() + ":" + s;
            }
            msdr3.Close();
            return paper;
            #endregion
        }

    }
}
