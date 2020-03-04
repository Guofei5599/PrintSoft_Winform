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
    public partial class 系统设置 : Form
    {
        public 系统设置()
        {
            InitializeComponent();
        }

        private void 系统设置_Load(object sender, EventArgs e)
        {
            List<string> tmp = LocalPrinter.GetLocalPrinters();
            foreach (var v in tmp)
            {
                comb_Printer.Items.Add(v);
            }
            string defaultstr = tmp.Count > 0 ? tmp[0] : "";
            comb_Printer.Text = ConfigClass.GetConfigString("sys","小票打印机", defaultstr);
            txt_ShopName.Text = ConfigClass.GetConfigString("sys", "店铺名称", "");
            txt_Barcode.Text = ConfigClass.GetConfigString("sys", "二维码路径", "");
            cb_Log.Checked = Convert.ToBoolean( ConfigClass.GetConfigString("sys", "log", "true"));
            cb_timerConvert.Checked = Convert.ToBoolean(ConfigClass.GetConfigString("sys", "Convert", "false"));
            numericUpDown1.Value = decimal.Parse( ConfigClass.GetConfigString("sys", "二维码宽度", "100"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigClass.SetConfigString("sys", "小票打印机", comb_Printer.Text);
                ConfigClass.SetConfigString("sys", "店铺名称", txt_ShopName.Text);
                ConfigClass.SetConfigString("sys", "二维码路径", txt_Barcode.Text);
                ConfigClass.SetConfigString("sys", "二维码宽度", numericUpDown1.Value.ToString());
                ConfigClass.SetConfigString("sys", "log", cb_Log.Checked.ToString());
                ConfigClass.SetConfigString("sys", "Convert", cb_timerConvert.Checked.ToString());
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图片 (*.png)|*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txt_Barcode.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            纸张管理 frm_纸张管理 = new 纸张管理();
            frm_纸张管理.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            价格管理 frm_价格管理 = new 价格管理();
            frm_价格管理.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            机器管理 frm_机器管理 = new 机器管理();
            frm_机器管理.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            配送管理 frm_配送管理 = new 配送管理();
            frm_配送管理.ShowDialog();
            FileHelper.timelist = GetPeopleMsg.GetTimeList();
            FileHelper.addrList = GetPeopleMsg.GetAddrList();
        }
    }
}
