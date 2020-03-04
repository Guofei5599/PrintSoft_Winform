using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public partial class 价格管理 : Form
    {
        public 价格管理()
        {
            InitializeComponent();
        }

        private void 价格管理_Load(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            flag = false;
            dataGridView1.Rows.Clear();
            string sql = @"select a.纸张类型 ,a.`彩色打印`,a.`黑白单面打印`,a.`黑白双面打印`,b.`黑白可用`,b.`彩色可用`,b.纸张名称 from 价格管理 a left join 纸张管理 b on a.纸张类型 = b.纸张类型";
            SQLiteDataReader msdr = SQLiteHelper.ExecuteDataReader(sql);
            while (msdr.Read())
            {
                string Name = msdr[0].ToString();
                string disName = msdr[6] == DBNull.Value?"":msdr[6].ToString();
                string 彩色打印 = @"\";
                string 黑白单面打印 = @"\";
                string 黑白双面打印 = @"\";
                int 黑白可用 = Convert.ToInt32(msdr[4].ToString());
                int 彩色可用 = Convert.ToInt32(msdr[5].ToString());
                if (彩色可用 == 1)
                {
                    彩色打印 = Convert.ToSingle(msdr[1]).ToString("F2") ;
                }
                if (黑白可用 == 1)
                {
                    黑白单面打印 = Convert.ToSingle(msdr[2]).ToString("F2");
                    黑白双面打印 = Convert.ToSingle(msdr[3]).ToString("F2");
                }
                dataGridView1.Rows.Add(Name, disName, 彩色打印, 黑白单面打印, 黑白双面打印);
            }
            msdr.Close();

            string sql1 = "select * from 附加项表";
            SQLiteDataReader msdr1 = SQLiteHelper.ExecuteDataReader(sql1);
            while (msdr1.Read())
            {
                switch (msdr1[1].ToString())
                {
                    case "活动折扣":
                        txt_活动折扣.Text = msdr1[2].ToString();
                        break;
                    case "附加费用":
                        txt_附加费用.Text = msdr1[2].ToString();
                        break;
                    case "起步价":
                        txt_起步价.Text = msdr1[2].ToString();
                        break;
                    case "配送费":
                        txt_配送费.Text = msdr1[2].ToString();
                        break;
                }
            }
            flag = true;
        }

        //private void addSub(string)
        //{

        //}

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == @"\")
            {
                e.Cancel = true;
            }
        }

        bool flag = false;
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex <1)
                return;
            if (e.RowIndex == -1)
                return;
            if (!flag)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == @"\")
                return;
            if (e.ColumnIndex <= 1)
                return;
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                float tmpValue = Convert.ToSingle(e.FormattedValue);
                string paperType = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql = string.Format("update 价格管理 set {0} = {1} where 纸张类型 = '{2}'",colName,tmpValue, paperType);
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入内容必须为数值！");
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = Convert.ToSingle( dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString("F2");
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
        }

        private void txt_活动折扣_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float f = Convert.ToSingle(txt_活动折扣.Text);
                if (f < 0 || f > 1)
                    throw new Exception();
                string sql = string.Format(" update 附加项表 set 数值 = {0} where 项目 = '{1}' ", f.ToString(), "活动折扣");
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入必须为数值且范围在 0-1之间");
                e.Cancel = true;
            }
           
        }

        private void txt_附加费用_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float f = Convert.ToSingle(txt_附加费用.Text);
                string sql = string.Format(" update 附加项表 set 数值 = {0} where 项目 = '{1}' ", f.ToString(), "附加费用");
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入必须为数值");
                e.Cancel = true;
            }
        }

        private void txt_起步价_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float f = Convert.ToSingle(txt_起步价.Text);
                string sql = string.Format(" update 附加项表 set 数值 = {0} where 项目 = '{1}' ", f.ToString(), "起步价");
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入必须为数值");
                e.Cancel = true;
            }
        }

        private void txt_配送费_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float f = Convert.ToSingle(txt_配送费.Text);
                string sql = string.Format(" update 附加项表 set 数值 = {0} where 项目 = '{1}' ", f.ToString(), "配送费");
                SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入必须为数值");
                e.Cancel = true;
            }
        }

        private void 价格管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.Select();
        }
    }
}
