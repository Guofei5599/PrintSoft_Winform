using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            //如果该数组长度大于1，说明多次运行
            if (processes.Length > 1)
            {
                MessageBox.Show("程序已运行，不能再次打开！");
                Environment.Exit(1);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_Main());
            }
        }
    }
}
