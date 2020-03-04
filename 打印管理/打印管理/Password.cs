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
    public partial class Password : Form
    {
        public string path = "";
        public string password = "";
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            password = txt_password.Text;
        }

        private void Password_Load(object sender, EventArgs e)
        {
            txt_Path.Text = path;
        }
    }
}
