using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class PriceClass
    {
        public string PaperType { set; get;  }
        public string ColorVerForm { set; get; }
        public string price { set; get; }
    }
    public class GetPaperPrice
    {
        public static List<PriceClass> PriceList = new List<PriceClass>();
        public static void getPrice()
        {
            lock (PriceList)
            {
                PriceList.Clear();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string sql = string.Format(@" SELECT 纸张类型, 黑白双面打印, 黑白单面打印,彩色打印  FROM 价格管理 ");
                SQLiteDataReader msdr1 = SQLiteHelper.ExecuteDataReader(sql);
                while (msdr1.Read())
                {
                    PriceList.Add(new PriceClass() { ColorVerForm = "黑白正反", PaperType = msdr1[0].ToString(), price = msdr1[1].ToString() });
                    PriceList.Add(new PriceClass() { ColorVerForm = "黑白单面", PaperType = msdr1[0].ToString(), price = msdr1[2].ToString() });
                    PriceList.Add(new PriceClass() { ColorVerForm = "彩色单面", PaperType = msdr1[0].ToString(), price = msdr1[3].ToString() });
                }
                msdr1.Close();
            }
        }
    }
}
