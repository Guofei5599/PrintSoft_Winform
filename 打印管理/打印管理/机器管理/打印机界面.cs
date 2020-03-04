using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public partial class 打印机界面 : Form
    {
        public 打印机界面()
        {
            InitializeComponent();
        }

        private void 打印机界面_Load(object sender, EventArgs e)
        {
            foreach (var v in LocalPrinter.GetLocalPrinters())
            {
                comboBox1.Items.Add(v);
            }
        }

        public string selectPrinter = "";

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("请先选择打印机！");
                return;
            }
            selectPrinter = comboBox1.Text;
            if (selectPrinter != "")
            {
                string s = " select count(*) from 机器管理";
                string sql = "";
                object obj = SQLiteHelper.ExecuteScalar(s);
                int sum = Convert.ToInt32(obj);
                if (sum == 0)
                    sql = string.Format(@" insert into 机器管理( 打印机名称,黑白可用,彩色可用,黑白默认,彩色默认) values('{0}',0,0,1,1) ", selectPrinter);
                else
                {
                    s = string.Format(" select count(*) from 机器管理 where 打印机名称 = '{0}'", selectPrinter);
                    obj = SQLiteHelper.ExecuteScalar(s);
                    if (Convert.ToInt32(obj) > 0)
                    {
                        MessageBox.Show("该打印机已经添加！");
                        return;
                    }
                    sql = string.Format(@" insert into 机器管理( 打印机名称,黑白可用,彩色可用,黑白默认,彩色默认) values('{0}',0,0,0,0) ", selectPrinter);
                }
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            this.Close();
        }
    }
}
