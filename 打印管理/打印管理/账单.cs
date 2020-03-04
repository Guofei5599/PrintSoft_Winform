using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace 打印管理
{
    public partial class 账单 : Form
    {
        public 账单()
        {
            InitializeComponent();
        }
        private void 账单_Load(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dataGridView1.Rows.Clear();
            SQLiteDataReader msdr = SqlModlus.getUserAllMsg(dateTimePicker1.Value.Date.ToString(), dateTimePicker2.Value.AddDays(1).Date.ToString());
            int i = 0;
            double tmpPrice = 0;
            while (msdr.Read())
            {
                string pay = "";
                switch (msdr["PayType"].ToString())
                {
                    case "0":
                        pay = "支付宝";
                        break;
                    case "1":
                        pay = "微信";
                        break;
                    case "2":
                        pay = "QQ";
                        break;
                    case "3":
                        pay = "VIP";
                        break;
                    case "4":
                        pay = "未付款";
                        break;
                }
                double p = 0;
                string price = msdr["Price"] == DBNull.Value ? "0" : msdr["Price"].ToString();
                if (!double.TryParse(msdr["Price"].ToString(), out p))
                    p = 0;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["用户ID"].Value = msdr["UserID"];
                dataGridView1.Rows[i].Cells["用户名"].Value = msdr["UserName"];
                dataGridView1.Rows[i].Cells["录单时间"].Value = msdr["LoadTime"];
                dataGridView1.Rows[i].Cells["出货时间"].Value = msdr["FinishTime"];
                dataGridView1.Rows[i].Cells["配送时间"].Value = msdr["Time"];
                dataGridView1.Rows[i].Cells["消费金额"].Value = p;
                dataGridView1.Rows[i].Cells["支付方式"].Value = pay;
                dataGridView1.Rows[i].Cells["小票预览"].Value = "小票预览";
                tmpPrice += p;
                i++;
            }
            msdr.Close();
            tmpPrice = tmpPrice + 0.35;
            当日总金额.Text = Math.Round( tmpPrice,1, MidpointRounding.AwayFromZero).ToString() + " 元";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                MessageBox.Show("启始日期不能大于截止日期");
                dateTimePicker1.Value = dt1;
                return;
            }
            RefreshDgv();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                MessageBox.Show("截止日期不能大于启始日期");
                dateTimePicker2.Value = dt2;
                return;
            }
            if (dateTimePicker2.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("不能选择未来日期！");
                dateTimePicker2.Value = dt2;
                return;
            }
            RefreshDgv();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "小票预览")
            {
                GroupMsg groupMsg = SqlModlus.GetGroupMsg(dataGridView1.Rows[e.RowIndex].Cells["用户ID"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["用户名"].Value.ToString());
                if (groupMsg == null)
                {
                    MessageBox.Show("获取小票失败！");
                    return;
                }
                int h = 0;
                Image img = ImageHelper.CreateImage(groupMsg,out h);
                pictureBox1.Height = h;
                pictureBox1.Image = img;
            }
        }

        private DataTable GetDT(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                dt.Columns.Add(c.Name);
            }
            foreach (DataGridViewRow r in dgv.Rows)
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    row[dgv.Columns[i].Name] = (r.Cells[i].Value == null || r.Cells[i].Value == DBNull.Value) ? "" : r.Cells[i].Value.ToString();
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public void ExportExcelFile(DataTable dt, string filrname)
        {
            if (dt != null)
            {
                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = filrname;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return;      //被点了取消
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];      //取得sheet1

                int rowCount = dt.Rows.Count;           //行数
                int columnCount = dt.Columns.Count;     //列数
                                                        //写入标题
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }

                //写入数值
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i];
                    }
                    Application.DoEvents();
                }
                worksheet.Columns.AutoFit();
                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁
                MessageBox.Show("文件： " + filrname + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportExcelFile(GetDT(dataGridView1),"账单");
        }

        private DateTime dt1, dt2;
        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            dt1 = dateTimePicker1.Value;
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            dt2 = dateTimePicker2.Value;
        }
    }
}
