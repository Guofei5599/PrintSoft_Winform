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
    public partial class TipForm : Form
    {
        public TipForm()
        {
            InitializeComponent();
            this.TopMost = true;
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Top + Screen.PrimaryScreen.WorkingArea.Height;
            //计算窗体显示的坐标值，可以根据需要微调几个像素
            int x = ScreenWidth - this.Width - 2;
            int y = ScreenHeight - this.Height - 2;
            this.Location = new Point(x, y);
        }

        public void setFormLable(GroupMsg msg)
        {
            出货时间.Text = DateTime.Now.ToString("HH:mm:ss");
            订单.Text ="【"+ msg.GroupName +"】";
            List<string> s = new List<string>();
            if (msg.FileMsgList == null)
                设备.Text = msg.Printer;
            else
            {
                foreach (var v in msg.FileMsgList)
                    if (!s.Contains("【" + FileHelper.SubStringByByte2(v.Printer, 16) + "】"))
                        s.Add("【" + FileHelper.SubStringByByte2(v.Printer, 16) + "】");
            }
            for (int i = 0; i < s.Count; i++)
            {
                if (i < 2)
                    设备.Text += s[i] +  " ";
                else
                {
                    设备.Text += "...";
                    break;
                }
            }
            文件个数.Text = msg.FileMsgList == null ? "0" : msg.FileMsgList.Count.ToString();
            配送时间.Text = msg.Time == null ? "" : msg.Time.ToString();
            备注.Text = msg.Note == null ? "" : msg.Note.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
