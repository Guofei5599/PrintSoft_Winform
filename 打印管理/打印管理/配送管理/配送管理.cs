using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace 打印管理
{
    public partial class 配送管理 : Form
    {
        public 配送管理()
        {
            InitializeComponent();
        }
        private void 配送管理_Load(object sender, EventArgs e)
        {
            string sql = " select * from 配送管理表 ";
            SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql);
            while (msdr.Read())
            {
                if (msdr[1].ToString().Contains("时间"))
                {
                    dgv_time.Rows.Add(msdr[2] == null ? "" : msdr[2].ToString(), msdr[3] == null ? "" : msdr[3].ToString()
                        , msdr[4] == null ? "" : msdr[4].ToString(), msdr[5] == null ? "" : msdr[5].ToString());
                }
                else if (msdr[1].ToString().Contains("地址"))
                {
                    dgv_addr.Rows.Add(msdr[2] == null ? "" : msdr[2].ToString(), msdr[3] == null ? "" : msdr[3].ToString()
                        , msdr[4] == null ? "" : msdr[4].ToString(), msdr[5] == null ? "" : msdr[5].ToString());
                }
            }
            flag = true;
        }

        private void dgv_time_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        bool flag = false;
        private void dgv_time_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null || e.FormattedValue.ToString() == "" || !flag)
            {
            }
            else
            {
                try
                {
                    DateTime dt = DateTime.Parse(e.FormattedValue.ToString());
                }
                catch
                {
                    MessageBox.Show("输入格式必须为：HH:MM");
                    e.Cancel = true;
                    return;
                }
            }
            string sql = string.Format("update 配送管理表 set {0} = '{1}' where 类型 = '{2}'",dgv_time.Columns[e.ColumnIndex].Name, e.FormattedValue == null?"":e.FormattedValue.ToString(),"时间" + (e.RowIndex + 1).ToString());
            if (SQLiteHelper.ExecuteNonQuery(sql) == 0)
                e.Cancel = true;
        }

        private void dgv_addr_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string sql = string.Format("update 配送管理表 set {0} = '{1}' where 类型 = '{2}'", dgv_time.Columns[e.ColumnIndex].Name, e.FormattedValue == null?"":e.FormattedValue.ToString(), "地址" + (e.RowIndex + 1).ToString());
            if (SQLiteHelper.ExecuteNonQuery(sql) == 0)
                e.Cancel = true;
        }
    }
}
