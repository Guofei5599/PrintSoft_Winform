using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.SQLite;

namespace 打印管理
{
    public partial class 机器管理 : Form
    {
        private int mLastTime;
        private Thread msclickThread;
        public 机器管理()
        {
            InitializeComponent();
        }

        private void RefreshDgv()
        {
            dataGridView1.Rows.Clear();
            string sql = " select * from 机器管理 ";
            SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql);
            bool flag1 = false;
            bool flag2 = false;
            while (msdr.Read())
            {
                string printerName = msdr[1].ToString();
                int 黑白可用 = Convert.ToInt32(msdr[2].ToString());
                int 彩色可用 = Convert.ToInt32(msdr[3].ToString());
                int defaulltSelect = Convert.ToInt32(msdr[4].ToString());
                int defaulltSelect2 = Convert.ToInt32(msdr[5].ToString());
                dataGridView1.Rows.Add(printerName, 黑白可用 == 1?"可用":"不可用", 彩色可用 == 1 ? "可用" : "不可用");
                if (defaulltSelect == 1)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["黑白可用"].Style.BackColor = Color.Green;
                    flag1 = true;
                }
                if (defaulltSelect2 == 1)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["彩色可用"].Style.BackColor = Color.Green;
                    flag2 = true;
                }
            }
            if (!flag1)
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    string[] columnName = new string[] { "黑白默认", "彩色默认" };
                    string printer = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    string sql1 = string.Format(" update 机器管理 set {0} = {1} where 打印机名称 = '{2}'", columnName[0], "1", printer);
                    SQLiteHelper.ExecuteNonQuery(sql1);
                    dataGridView1.Rows[0].Cells["黑白可用"].Style.BackColor = Color.Green;
                }
            }
            if (!flag2)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string[] columnName = new string[] { "黑白默认", "彩色默认" };
                    string printer = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    string sql1 = string.Format(" update 机器管理 set {0} = {1} where 打印机名称 = '{2}'", columnName[1], "1", printer);
                    SQLiteHelper.ExecuteNonQuery(sql1);
                    dataGridView1.Rows[0].Cells["彩色可用"].Style.BackColor = Color.Green;
                }
            }
        }

        private void btn_添加_Click(object sender, EventArgs e)
        {
            打印机界面 frm_打印机界面 = new 打印机界面();
            frm_打印机界面.ShowDialog();
            RefreshDgv();
        }

        private void 机器管理_Load(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (msclickThread == null)
                return;
            msclickThread.Abort();
            Thread dClickThread = new Thread(() =>
            {
                dgvdoubleClick(e.RowIndex, e.ColumnIndex);
            });
            dClickThread.IsBackground = true;
            dClickThread.Priority = ThreadPriority.Highest;
            dClickThread.Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (current[0] != e.RowIndex || e.ColumnIndex != current[1])
            {
                current[0] = e.RowIndex;
                current[1] = e.ColumnIndex;
                return;
            }
            this.msclickThread = new Thread(() => {
                Thread.Sleep(200);
                dgvClick(dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex);
            });
            msclickThread.IsBackground = true;
            msclickThread.Start();
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells == null || dataGridView1.SelectedCells.Count  == 0)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Style.BackColor == Color.Green ||
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Style.BackColor == Color.Green)
            {
                MessageBox.Show("默认项不允许删除！");
                return;
            }
            string printer = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            string sql = string.Format(@" delete from 机器管理 where 打印机名称 = '{0}' ",printer);
            SQLiteHelper.ExecuteNonQuery(sql);
            RefreshDgv();
        }

        int[] current = new int[] { 0, 0 };

        private void dgvClick(int rowIndex, int columnIndex)
        {
            if (rowIndex == -1)
                return;
            if (columnIndex == -1)
                return;
            if (columnIndex == 1 || columnIndex == 2)
            {
                if (dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor == Color.Green)
                {
                    MessageBox.Show("默认设备不可设置!");
                    return;
                }
                string printer = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string col = dataGridView1.Columns[columnIndex].Name.ToString();
                string currentValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                string sql = string.Format(" update 机器管理 set {0} = {1} where 打印机名称 = '{2}'", col, currentValue == "可用" ? 0 : 1, printer);
                int j = SQLiteHelper.ExecuteNonQuery(sql);
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = (currentValue == "可用" ? "不可用" : "可用");
            }
        }

        private void dgvdoubleClick(int rowIndex, int columnIndex)
        {
            if (rowIndex == -1)
                return;
            if (columnIndex == -1)
                return;
            if (columnIndex == 1 || columnIndex == 2)
            {
                if ("不可用" == dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString())
                {
                    MessageBox.Show("不可用设备不能设置为默认设备!");
                    return;
                }
                string[] columnName = new string[] { "黑白默认", "彩色默认" };
                string printer = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string sql = string.Format(" update 机器管理 set {0} = {1} ", columnName[columnIndex - 1], "0");
                int j = SQLiteHelper.ExecuteNonQuery(sql);
                sql = string.Format(" update 机器管理 set {0} = {1} where 打印机名称 = '{2}'", columnName[columnIndex - 1], "1", printer);
                int j1 = SQLiteHelper.ExecuteNonQuery(sql);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[columnIndex].Style.BackColor = Color.White;
                }
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Green;
            }
        }
    }
}
