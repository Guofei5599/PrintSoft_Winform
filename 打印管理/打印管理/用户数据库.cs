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
using System.Data.SQLite;

namespace 打印管理
{
    public partial class 用户数据库 : Form
    {
        public 用户数据库()
        {
            InitializeComponent();
        }
        int rowCount = 0;
        bool initFlag = false;
        private void 用户数据库_Load(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dataGridView1.Rows.Clear();
            SQLiteDataReader msdr = SqlModlus.GetAllUserMsg();
            while (msdr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[rowCount].Cells["用户名"].Value = msdr["UserName"];
                dataGridView1.Rows[rowCount].Cells["上次地点"].Value = msdr["LastAddr"];
                dataGridView1.Rows[rowCount].Cells["电话"].Value = msdr["Phone"];
                dataGridView1.Rows[rowCount].Cells["消费总金额"].Value = SqlModlus.GetPriceSum(new UserDB() { userName = msdr["UserName"].ToString() }) ;
                dataGridView1.Rows[rowCount].Cells["上次下单时间"].Value = msdr["LastTime"];
                dataGridView1.Rows[rowCount].Cells["用户属性备注"].Value = msdr["Note"];
                rowCount++;
            }
            msdr.Close();
        }
        private void Btn_New_Click(object sender, EventArgs e)
        {
            if (txt_User.Text.Length == 0)
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["用户名"].Value.ToString() == txt_User.Text)
                {
                    MessageBox.Show("用户名重复!");
                    return;
                }
            }
            UserDB user = new UserDB();
            user.userName = txt_User.Text;
            user.phone = txt_Phone.Text; ;
            user.note = txt_Note.Text;
            InsertOrUpdateUser(user);
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["用户名"].Value = user.userName;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["电话"].Value = user.phone;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["用户属性备注"].Value = user.note;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ( dataGridView1.Columns[e.ColumnIndex].Name != "用户属性备注")
            {
                e.Cancel = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            SqlModlus.DeleteUserMsg(new UserDB() { userName = dataGridView1.SelectedRows[0].Cells["用户名"].Value.ToString() });
            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
        }
        public bool InsertOrUpdateUser(UserDB user)
        {
            bool b = SqlModlus.ChecUserExist(user);
            if (b)
            {
                return SqlModlus.UpdateUserMsg(user);
            }
            else
            {
                return SqlModlus.InsertUserMsg(user);
            }
        }

        private void 用户数据库_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "用户属性备注")
            {
                string userName = dataGridView1.Rows[e.RowIndex].Cells["用户名"].Value.ToString();
                string note = dataGridView1.Rows[e.RowIndex].Cells["用户属性备注"].Value != null ? dataGridView1.Rows[e.RowIndex].Cells["用户属性备注"].Value.ToString() : "";
                SQLiteHelper.ExecuteNonQuery(string.Format(" UPDATE UserTable SET Note = '{0}' where UserName = '{1}' ", note, userName));
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExportExcelFile(GetDT(dataGridView1),"用户数据");
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
    }
}
