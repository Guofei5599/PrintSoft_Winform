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
    public partial class 数字键盘 : Form
    {
        public delegate void NumFormExect(string txt);
        public NumFormExect DelNumFormExect;
        public 数字键盘()
        {
            InitializeComponent();
        }

        private void 数字键盘_Load(object sender, EventArgs e)
        {
            foreach (var con in this.Controls)
            {
                if (con is Button)
                {
                    (con as Button).Click += btn_Click;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            DelNumFormExect(btn.Text);
        }
    }
}
