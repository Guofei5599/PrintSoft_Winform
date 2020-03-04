using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class GetDefaultAddMsg
    {
        public static Dictionary<string, string> getMsg()
        {
            Dictionary<string, string> rowMsg = new Dictionary<string, string>();
            string sql1 = string.Format(@" SELECT * FROM 附加项表 ");
            SQLiteDataReader msdr1 = SQLiteHelper.ExecuteDataReader(sql1);
            while (msdr1.Read())
            {
                string key = msdr1[1].ToString();
                string value = msdr1[2].ToString();
                if (rowMsg.ContainsKey(key))
                    rowMsg[key] = value;
                else
                    rowMsg.Add(key, value);
            }
            msdr1.Close();
            return rowMsg;
        }
    }
}
