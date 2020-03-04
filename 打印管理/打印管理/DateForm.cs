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
    public partial class DateForm : Form
    {
        public string tDateTime
        {
            set;get;
        }

        public Point pos
        {
            set; get;
        }

        public DateForm()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string tDate = this.monthCalendar1.SelectionStart.ToLongDateString();
            this.tDateTime = tDate;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public string GetNewWindowDateTime()
        {
            //Show();
            //return this.tDateTime;
            switch (ShowDialog())
            {
                case DialogResult.OK:
                    return this.tDateTime;
                    break;
                default:
                    break;
            }
            return null;
        }

        private void monthCalendar1_MouseMove(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        public bool flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                Point p =  Control.MousePosition;
                Point p1 = PointToClient(p);
                if (p.X > ClientSize.Width + this.Location.X || p.X < this.Location.X || p.Y > Location.Y + ClientSize.Height || p.Y < Location.Y)
                {
                    tDateTime = null;
                    this.Close();
                }
                else
                {
                    
                }
            }
        }

        private void DateForm_Load(object sender, EventArgs e)
        {
            this.Location = pos;
        }
    }
}
