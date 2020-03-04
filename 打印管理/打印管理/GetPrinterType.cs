using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public static class GetPrinterType
    {
        public static string[] ColorPrinterList = null;
        public static string[] BWPrinterList = null;
        public static string defaultColorPrinter = null;
        public static string defaultBWPrinter = null;
        public static List<string> GetPrinterList(string paperColor)
        {
            string sql4 = string.Format(@" SELECT * FROM 机器管理 where {0}可用 = 1 ", paperColor);
            SQLiteDataReader msdr4 = SQLiteHelper.ExecuteDataReader(sql4);
            List<string> printerList = new List<string>() ;
            while (msdr4.Read())
            {
                printerList.Add(msdr4[1].ToString());
            }
            msdr4.Close();
            return printerList;
        }

        public static void UpdatePrinterList()
        {
            ColorPrinterList = GetPrinterList("彩色").ToArray();
            BWPrinterList = GetPrinterList("黑白").ToArray();
            defaultBWPrinter = GetPrinter("黑白");
            defaultColorPrinter = GetPrinter("彩色");
        }

        public static string GetPrinter(string paperColor)
        {
            string sql4 = string.Format(@" SELECT * FROM 机器管理 where {0}默认 = 1 ", paperColor);
            SQLiteDataReader msdr4 = SQLiteHelper.ExecuteDataReader(sql4);
            string printer = "----";
            while (msdr4.Read())
            {
                printer = msdr4[1].ToString();
            }
            msdr4.Close();
            return printer;
        }
    }
}
