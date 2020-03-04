using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public partial class main : Form
    {
        public static List<GroupMsg> groupList = new List<GroupMsg>();
        List<PayMsg> PayList = new List<PayMsg>();
        public  delegate void DealControlDelegate(int[] state);
        public DealControlDelegate dealControlDelegate;
        public DealControlDelegate dealStatusDelegate;
        public static bool doRefresh = false;
        public main()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            InitializeComponent();
            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);
            TopLevel = false;
        }

        private void 关闭toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //LoadFileMsg(@"C:\Users\95389\Desktop\新建文件夹\打印管理\文件");
           // refreshDgv();
        }

        public void setdgvPos(int w,int h)
        {
            this.Height = h;
            this.Width = w;
            dataGridView1.Width = w;
            dataGridView1.Height = h;
        }

        public void refresh(string condition)
        {
            if (Array.IndexOf(frm_Main.clickArr, 1) == -1)
                condition_refreshDgv(frm_Main.clickArr, condition);
            //refreshDgv(condition);
            else
                condition_refreshDgv(frm_Main.clickArr, condition);
        }

        private int gettoolState(int index)
        {
            switch (index)
            {
                case -2:
                    return 0x0e;
                case -1:
                    return 0x00;
                case 0:
                    return 0x08;
                case 1:
                    return 0x0f;
                case 2:
                    return 0x0f;
                case 3:
                    return 0x0A;
            }
            return 0;
        }

        public void condition_refreshDgv(int[] array,string condition)
        {
            int dateInt = 1;
            timer1.Stop();
            dataGridView1.Rows.Clear();
            //groupList.Sort();
            foreach (var v in groupList)
            {
                if (v.isRemove)
                    continue;
                if (array[0] == 1 && v.isManual != true)
                    continue;
                if (array[1] == 1 && (v.state != "0"))
                    continue;
                if (array[2] == 1 && (v.state != "1"))
                    continue;
                if (array[3] == 1 && (v.state != "2"))
                    continue;
                if (array[4] == 1 && (v.state != "3"))
                    continue;
                if (v.Note == null)
                    v.Note = "";
                if (v.Phone == null)
                    v.Phone = "";
                if (v.isManual == false)
                {
                    if (condition.Trim().Length > 0)
                    {
                        string[] payString = new string[] { "支付宝", "微信", "QQ", "VIP", "未付款" };
                        bool fileNameFlag = v.FileMsgList == null ? false : (v.FileMsgList.FindIndex(t => t.FileName.Contains(condition)) != -1);
                        bool priceFlag = v.Price == null ? false : v.Price.ToString().Contains(condition);
                        bool addrFlag = v.Area == null ? false : v.Area.ToUpper().Contains(condition.ToUpper());
                        bool phoneFlag = v.Phone  == null ? false : v.Phone.Contains(condition);
                        bool noteFlag = v.Note == null? false:v.Note.ToUpper().Contains(condition.ToUpper());
                        bool payFlag = payString[int.Parse(v.PayType)].ToUpper().Contains(condition.ToUpper());
                        if (!(v.GroupName.Contains(condition) || fileNameFlag || priceFlag || addrFlag || phoneFlag || noteFlag || payFlag))
                            continue;
                    }
                    else
                    {
                        if (v.SetTime.Split(' ')[0] != DateTime.Parse(frm_Main.CurrentDate).Date.ToString("yyyy-MM-dd"))
                            continue;
                    }
                    //refreshDgvTimeItem(dataGridView1.Rows.Count - 1);
                    string strfilesize = "0";
                    if (v.fileSize > 1024)
                        strfilesize = Math.Round((v.fileSize / 1024.0), 2).ToString() + "M";
                    else
                        strfilesize = v.fileSize.ToString() + "K";
                    dataGridView1.Rows.Add(false,"main", v.GroupName, v.state, v.isManual ? mStateList.Images[v.state] : StateList.Images[v.state], v.GroupName, v.FileName, strfilesize, v.Count, v.VerForm, v.PrintColor,
                    v.PaperType == "多选"?"多选":v.PaperType.Split(':')[1], FileHelper.SubStringByByte(v.Printer, 16), v.PageCount, v.Price, v.Time, v.Area, v.Phone, v.Note, payList.Images[v.PayType], v.LoadTime,
                    v.UserID, v.CreateTime, v.isManual?0:1, v.FinishTime,v.FullName);
                    if (v.FileMsgList.Count > 1)
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"] as DataGridViewProgressBarCell).currentImg = img.down;
                    else
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"] as DataGridViewProgressBarCell).currentImg = img.none;
                    foreach (var v1 in FileHelper.addrList)
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["地点"] as DataGridViewComboBoxCell).Items.Add(v1);
                    foreach (var v1 in FileHelper.timelist)
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["时间"] as DataGridViewComboBoxCell).Items.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                    (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["时间"] as DataGridViewComboBoxCell).Items.Add("次日");
                    Font f1 = new Font("新宋体", 10, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["用户名"].Style.Font = f1;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["计价"].Style.Font = f1;
                }
                else
                {
                    if (condition.Trim().Length > 0)
                    {
                        string[] payString = new string[] { "支付宝", "微信", "QQ", "VIP", "未付款" };
                        bool fileNameFlag = v.FileMsgList == null ? false : (v.FileMsgList.FindIndex(t => t.FileName.Contains(condition)) != -1);
                        bool priceFlag = v.Price == null ? false : v.Price.ToString().Contains(condition);
                        bool addrFlag = v.Area == null ? false : v.Area.Contains(condition);
                        bool phoneFlag = v.Phone == null ? false : v.Phone.Contains(condition);
                        bool noteFlag = v.Note == null ? false : v.Note.Contains(condition);
                        bool payFlag = payString[int.Parse(v.PayType)].Contains(condition);
                        if (!(v.GroupName.Contains(condition) || fileNameFlag || priceFlag || addrFlag || phoneFlag || noteFlag || payFlag))
                            continue;
                    }
                    else
                    {
                        if (v.SetTime.Split(' ')[0] != DateTime.Parse(frm_Main.CurrentDate).Date.ToString("yyyy-MM-dd"))
                            continue;
                    }
                    string strfilesize = "0";
                    if (v.fileSize > 1024)
                        strfilesize = Math.Round((v.fileSize / 1024.0), 2).ToString() + "M";
                    else
                        strfilesize = v.fileSize.ToString() + "K";
                    dataGridView1.Rows.Add(false, "main", v.GroupName, v.state, v.isManual ? mStateList.Images[v.state] : StateList.Images[v.state], v.GroupName, v.FileName, strfilesize, v.Count, v.VerForm, v.PrintColor,
                   v.PaperType.Split(':')[1], FileHelper.SubStringByByte(v.Printer, 16), v.PageCount, v.Price, v.Time, v.Area, v.Phone, v.Note, payList.Images[v.PayType], v.LoadTime,
                   v.UserID, v.CreateTime, v.isManual?0:1, v.FinishTime,v.FullName);
                    //if (v.FileMsgList.Count > 1)
                    //    (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"] as DataGridViewProgressBarCell).currentImg = img.down;
                    //else
                    //    (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"] as DataGridViewProgressBarCell).currentImg = img.none;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"] = new DataGridViewTextBoxCell();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"].Value = v.FileName.Replace("-1" + ",", "");
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["文件列表"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    foreach (var v1 in FileHelper.addrList)
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["地点"] as DataGridViewComboBoxCell).Items.Add(v1);
                    foreach (var v1 in FileHelper.timelist)
                        (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["时间"] as DataGridViewComboBoxCell).Items.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                    Font f1 = new Font("新宋体", 10, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["用户名"].Style.Font = f1;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["计价"].Style.Font = f1;
                    (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["时间"] as DataGridViewComboBoxCell).Items.Add("次日");
                }
            }
            dataGridView1.Sort(dataGridView1.Columns["State"], ListSortDirection.Ascending);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                int index = int.Parse(dataGridView1.Rows[0].Cells["State"].Value.ToString());
                dealControlDelegate(new int[] { gettoolState(index) ,0, dateInt });
            }
            timer1.Start();
        }

        private List<string> refreshDgvTimeItem(int rowindex)
        {
            DateTime dt = DateTime.Now;
            int i =  (dataGridView1.Rows[rowindex].Cells["时间"] as DataGridViewComboBoxCell).Items.Count;
            dataGridView1.Rows[rowindex].Cells["时间"].Value = null;
           (dataGridView1.Rows[rowindex].Cells["时间"] as DataGridViewComboBoxCell).Items.Clear();
            List<string> tmp = new List<string>();
            foreach (var v1 in FileHelper.timelist)
            {
                if (v1 > dt)
                {
                    tmp.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                    (dataGridView1.Rows[rowindex].Cells["时间"] as DataGridViewComboBoxCell).Items.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                }
            }
            GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[rowindex].Cells["UserID"].Value.ToString());
            if (int.Parse(msg.state) < 3)
                (dataGridView1.Rows[rowindex].Cells["时间"] as DataGridViewComboBoxCell).Items.Add("次日");
            return tmp;
        }

        private List<string> refreshDgvTimeItem()
        {
            DateTime dt = DateTime.Now;
            List<string> tmp = new List<string>();
            foreach (var v1 in FileHelper.timelist)
            {
                if (v1 > dt)
                {
                    tmp.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                }
            }
            return tmp;
        }

        public class PayMsg
        {
            public Color Backcolor { set; get; }
            public string text { set; get; }
        }

        private void OpenFile(GroupMsg msg,string filename)
        {
            if (msg.FileMsgList == null)
                return;
            FileMsg filemsg = msg.FileMsgList.Find(t=>t.FullName == filename);
            if (filemsg == null)
            {
                return;
            }
            if (MessageBox.Show("请问是否打开文件：" + filemsg.FileName, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            string [] ss = filemsg.FullName.Split('\\');
            string tmpPath = "";
            if (ss.Count() > 0)
                ss[ss.Count() - 1] = filemsg.FileName;
            for (int i = 0; i < ss.Length - 1; i++)
            {
                tmpPath += (ss[i] + '\\');
            }
            tmpPath += filemsg.FileName.Contains(',') ? filemsg.FileName.Split(',')[1] : filemsg.FileName ;

            FileHelper.openFile(tmpPath);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
            if (msg == null)
                return;
            if (msg.isManual)
                return;
            string s = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            OpenFile(msg, s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
            if (msg == null)
                return;
            if (msg == null || (int.Parse(msg.state) >= 3 && dataGridView1.Columns[e.ColumnIndex].Name != "支付方式"))
            {
                msg.isChange = true;
                return;
            }
            if (msg.isPrint)
                return;
            if (DateTime.Parse(msg.SetTime).Date < DateTime.Now.Date)
                return;
            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell))
            {
                DataGridViewButtonCell btn_cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
                {
                    switch (dataGridView1.Columns[e.ColumnIndex].Name)
                    {
                        case "版面":
                            #region
                            msg.SetClickVerForm();
                            #endregion
                            break;
                        case "颜色":
                            msg.SetClickColor();
                            msg.SetDefaultPaper();
                            if (!msg.isManual)
                                msg.SetDefaultPrinter();
                            msg.SetDefaultVerForm();
                            break;
                        case "纸张类型":
                            msg.SetClickPaper();
                            break;
                        case "打印机":
                            if (msg.isManual)
                                break;
                            msg.SetClickPrinter();
                            break;
                    }
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "sub")
                {
                    FileMsg msg1 = msg.FileMsgList.Find(t => t.FullName == dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString());
                    switch (dataGridView1.Columns[e.ColumnIndex].Name)
                    {
                        case "版面":
                            msg1.SetClickVerForm();
                            break;
                        case "颜色":
                            msg1.SetClickColor();
                            msg1.SetDefaultPaper();
                            msg1.SetDefaultPrinter();
                            msg1.SetDefaultVerForm();
                            break;
                        case "纸张类型":
                            msg1.SetClickPaper();
                            break;
                        case "打印机":
                            msg1.SetClickPrinter();
                            break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "时间")
            {
                //refreshDgvTimeItem(e.RowIndex);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "支付方式" && dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
            {
                //GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (msg == null)
                    return;
                msg.PayType = (int.Parse(msg.PayType) + 1).ToString();
                if (int.Parse(msg.PayType) >= 5)
                    msg.PayType = "0";
                dataGridView1.Rows[e.RowIndex].Cells["支付方式"].Value = payList.Images[msg.PayType];
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewProgressBarCell))
            {
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (msg.isManual || msg.FileMsgList == null)
                    return;
                string ss = msg.FullName.Trim('\\');
                if (msg.FileMsgList.Count == 1)
                {
                    string s = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                    OpenFile(msg, msg.FileMsgList[0].FullName);
                }
                else
                {
                    if (MessageBox.Show("请问是否打开文件夹", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        FileHelper.openDirectory(ss);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                dataGridView1.EndEdit();
                return;
            }
            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewProgressBarCell))
            {
                if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewProgressBarCell).currentImg == img.up)
                {
                    while ((e.RowIndex + 1) <= (dataGridView1.Rows.Count - 1))
                    {
                        if (dataGridView1.Rows[e.RowIndex + 1].Cells["row_type"].Value.ToString() != "sub")
                            break;
                        dataGridView1.Rows.RemoveAt(e.RowIndex + 1);
                    }
                  (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewProgressBarCell).currentImg = img.down;
                }
                else if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewProgressBarCell).currentImg == img.down)
                {
                    GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                    if (msg == null)
                        return;
                    int i = 1;
                    if (msg.FileMsgList != null)
                        foreach (var v in msg.FileMsgList)
                        {
                            string strfilesize = "0";
                            if (msg.fileSize > 1024)
                                strfilesize = Math.Round((msg.fileSize / 1024.0), 2).ToString() + "M";
                            else
                                strfilesize = msg.fileSize.ToString() + "K";
                            dataGridView1.Rows.Insert(e.RowIndex + i, false, "sub", msg.GroupName, v.state, StateList.Images[4], "", v.FileName, strfilesize, v.Count, v.VerForm.ToString(), v.PrintColor.ToString(), v.PaperType.Split(':')[1], FileHelper.SubStringByByte(v.Printer, 16), v.PageCount.ToString() == "-1" ? "----" : v.PageCount.ToString(), v.Price, "", "", "", "", payList.Images[5], v.LoadTime, v.UserID);
                            dataGridView1.Rows[e.RowIndex + i].Cells["FullName"].Value = v.FullName;
                            dataGridView1.Rows[e.RowIndex + i].Cells["时间"] = new DataGridViewTextBoxCell();
                            dataGridView1.Rows[e.RowIndex + i].Cells["地点"] = new DataGridViewTextBoxCell();
                            dataGridView1.Rows[e.RowIndex + i].Cells["文件列表"] = new DataGridViewTextBoxCell();
                            dataGridView1.Rows[e.RowIndex + i].DefaultCellStyle.BackColor = Color.White;
                            dataGridView1.Rows[e.RowIndex + i].Cells["备注"].Style.BackColor = SystemColors.ControlLight;
                            dataGridView1.Rows[e.RowIndex + i].Cells["文件列表"].Value = v.FileName;
                            //dataGridView1.Rows[e.RowIndex + i].Cells["支付方式"] = new DataGridViewTextBoxCell();
                            dataGridView1.Rows[e.RowIndex + i].Cells["文件列表"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                            i++;
                        }
                   (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewProgressBarCell).currentImg = img.up;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            #region  时间 地点  份数  联系方式 备注
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "时间")
            {
                #region
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (msg == null)
                    return;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    //msg.state = 0;
                    return;
                }
                if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value == "")
                {
                    //msg.state = 0;
                    return;
                }
                if (int.Parse(msg.state) >= 3)
                {
                    msg.Time = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    return;
                }
                switch (value)
                {
                    case "次日":
                        msg.state = "0";
                        msg.Time = string.Empty;
                        int index = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(index);
                        msg.SetTime = DateTime.Parse(frm_Main.CurrentDate).Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                        refresh("");
                        break;
                    default:
                        DateTime dt = DateTime.Now;
                        List<TimeSpan> tmp = new List<TimeSpan>();
                        foreach (var v1 in FileHelper.timelist)
                        {
                            if (v1 > dt)
                            {
                                tmp.Add(v1.TimeOfDay);
                            }
                            else
                            {

                            }
                        }
                        tmp.Sort();
                        if (tmp.Count != 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == tmp[0].ToString().Substring(0, 5))
                        {
                            msg.Time = tmp[0].ToString().Substring(0, 5);
                            msg.state = "1";
                            msg.SetTime = DateTime.Parse(frm_Main.CurrentDate).ToString("yyyy-MM-dd HH:mm:ss");
                            dataGridView1.Rows[e.RowIndex].Cells["icon"].Value = msg.isManual ? mStateList.Images[msg.state] : StateList.Images[msg.state];
                            dataGridView1.Rows[e.RowIndex].Cells["State"].Value = msg.state;
                        }
                        else
                        {
                            List<string> list = new List<string>();
                            foreach (var v in tmp)
                            {
                                list.Add(v.ToString().Substring(0, 5));
                            }
                            if (list.Contains(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                            {
                                msg.Time = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                                msg.state = "2";
                                msg.SetTime = DateTime.Parse(frm_Main.CurrentDate).ToString("yyyy-MM-dd HH:mm:ss");
                                dataGridView1.Rows[e.RowIndex].Cells["icon"].Value = msg.isManual ? mStateList.Images[msg.state] : StateList.Images[msg.state];
                                dataGridView1.Rows[e.RowIndex].Cells["State"].Value = msg.state;
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = msg.Time;
                            }
                        }
                        break;
                }
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "地点")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value == "")
                    return;
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (!FileHelper.addrList.Contains(value))
                {
                    msg.Area = null;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                else
                {
                    msg.Area = value;
                }
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "份数")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                    return;
                }  
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value == "" || value == "多选")
                    return;
                int result;
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (int.TryParse(value, out result))
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
                    {
                        msg.Count = result.ToString();
                        if (msg.FileMsgList != null)
                        {
                            msg.FileMsgList.ForEach(t => t.Count = result.ToString());
                        }
                        msg.InitPrice = "-1";
                        if (msg.FileMsgList != null)
                        {
                            foreach (var v in msg.FileMsgList)
                                v.InitPrice = "-1";
                        }
                    }
                    else if(dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "sub")
                    {
                        FileMsg fmsg = msg.FileMsgList.Find(t => t.FullName == dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString());
                        fmsg.Count = result.ToString();
                        fmsg.InitPrice = "-1";
                    }
                }
                else
                {
                    MessageBox.Show("输入必须为数字！");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = msg.Count;
                }
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "联系方式")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                msg.Phone = value;
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "备注")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                msg.Note = value;
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "页数")
            {
                #region
                if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                    return;
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    msg.PageCount = msg.InitPageCount;
                    return;
                }
                else
                {
                    int tmpValue = 0;
                    string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (int.TryParse(value, out tmpValue))
                    {
                        msg.PageCount = value;
                    }
                    else
                    {
                        MessageBox.Show("输入必须为数字！");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = msg.PageCount;
                        //dataGridView1.EndEdit();
                    } 
                }
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "计价")
            {
                #region
                if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                    return;
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        msg.InitPrice = "-1";
                        return;
                    }
                    else
                    {
                        float tmpValue = 0;
                        string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (float.TryParse(value, out tmpValue))
                        {
                            msg.InitPrice = Math.Round(tmpValue, 1, MidpointRounding.AwayFromZero).ToString();
                        }
                        else
                        {
                            MessageBox.Show("输入必须为数字！");
                            //msg.InitPrice = msg.Price;
                        }
                    }
                }
                else if(dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "sub")
                {
                    FileMsg fmsg = msg.FileMsgList.Find(t=>t.FullName == dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString());
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        fmsg.InitPrice = "-1";
                        msg.InitPrice = "-1";
                        return;
                    }
                    else
                    {
                        float tmpValue = 0;
                        string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (float.TryParse(value, out tmpValue))
                        {
                            msg.InitPrice = "-1";
                            fmsg.InitPrice = Math.Round(tmpValue, 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        else
                        {
                            MessageBox.Show("输入必须为数字！");
                            //msg.InitPrice = msg.Price;
                        }
                    }
                }
                // GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "用户名")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                msg.GroupName = value;
                #endregion
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "文件列表")
            {
                #region
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value));
                if(msg != null)
                    msg.FileName = value;
                #endregion
            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Check")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value));
                if (msg != null)
                    msg.isCheck = (bool)val;
            }
            #endregion
        }

        public bool RefreshFlag = false;

        private bool bDate = true;
        int[] GroupCount = new int[5];
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            dealStatusDelegate(GroupCount);
            var tmpGroupList = main.groupList.FindAll(t=>t.isShow == true);
            if (tmpGroupList != null)
            {
                foreach (var v in tmpGroupList)
                {
                    frm_Main.sound.Play();
                    showTip(v);
                    v.isShow = false;
                }
            }
            RefreshTool(bDate);
            GroupCount = new int[5];
            foreach (var v in main.groupList)
            {
                if (DateTime.Parse(v.SetTime).Date != DateTime.Now.Date)
                    continue;
                if (v.isManual)
                    GroupCount[0]++;
                if (v.state == "0")
                    GroupCount[1]++;
                else if (v.state == "1")
                    GroupCount[2]++;
                else if (v.state == "2")
                    GroupCount[3]++;
                else if (v.state == "3")
                    GroupCount[4]++;
            }
            bDate = true;
            if (true)
            {
                string date = "";
                foreach (DataGridViewRow v in dataGridView1.Rows)
                { 
                    GroupMsg msg = groupList.Find(t=> t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[v.Index].Cells["UserID"].Value.ToString());
                    if (date == "")
                        date = DateTime.Parse(msg.SetTime).Date.ToString("yyyy-MM-dd");
                    else
                    {
                        if (date != DateTime.Parse(msg.SetTime).Date.ToString("yyyy-MM-dd"))
                            bDate = false;
                    }
                    if (v.Cells["row_type"].Value.ToString() == "main")
                    {
                        GroupMsg tmpGroup = groupList.Find(t=> t.isRemove == false && t.UserID.ToString() == v.Cells["UserID"].Value.ToString() && int.Parse(t.state) >= 3 && (DateTime.Now - DateTime.Parse(t.FinishTime)).Hours > 48);//600000
                        if (tmpGroup != null)
                        {
                            if(!tmpGroup.isClearFile)
                                Delete(tmpGroup);
                        }
                        if (true) //if (RefreshFlag == true)
                        {
                            List<string> list = refreshDgvTimeItem();
                            if ((msg.state == "2") && list.IndexOf(msg.Time) <= 0)
                                msg.state = "1";
                            v.Cells["icon"].Value = msg.isManual ? mStateList.Images[msg.state] : StateList.Images[msg.state];
                            v.Cells["State"].Value = msg.state;
                            v.Cells["份数"].Value = msg.GetDisplayCount();
                            v.Cells["版面"].Value = msg.GetDisplayVerForm();
                            v.Cells["颜色"].Value = msg.GetDisplayColor();
                            v.Cells["Size"].Value = msg.fileSize;
                            if (msg.GetDisplayPaper() == "多选")
                                v.Cells["纸张类型"].Value = msg.GetDisplayPaper();
                            else
                                v.Cells["纸张类型"].Value = msg.GetDisplayPaper().Split(':')[1];
                            v.Cells["打印机"].Value = FileHelper.SubStringByByte(msg.GetDisplayPrinter(), 16);
                            v.Cells["页数"].Value = msg.PageCount;
                            if ((v.Cells["支付方式"].Value as Bitmap) != payList.Images[msg.PayType])
                                v.Cells["支付方式"].Value = payList.Images[msg.PayType];
                            v.Cells["文件列表"].Value = msg.GetDisplayFileName();
                            if (msg.InitPrice == "-1")
                            {
                                msg.InitPrice = "-2";
                                msg.Price = msg.GetPrice();
                            }
                            else if (msg.InitPrice == "-2")
                            {
                                if(int.Parse(msg.state) < 3)
                                    msg.Price = msg.GetPrice();
                            }
                            else
                                msg.Price = msg.InitPrice;
                            if (!v.Cells["计价"].IsInEditMode)
                                v.Cells["计价"].Value = msg.Price;
                        }
                    }
                    else
                    {
                        if(true)//if (RefreshFlag == true)
                        {
                            FileMsg msg1 = msg.FileMsgList.Find(t => t.FullName == v.Cells["FullName"].Value.ToString());
                            //Dictionary<string, string> priceMsg = GetPaperPrice.getPrice(msg1.PaperType.Split(':')[0].ToString());
                            v.Cells["份数"].Value = msg1.Count;
                            v.Cells["版面"].Value = msg1.VerForm.ToString();
                            v.Cells["颜色"].Value = msg1.PrintColor.ToString();
                            v.Cells["纸张类型"].Value = msg1.PaperType.ToString().Split(':')[1];
                            v.Cells["文件列表"].Value = msg1.FileName;
                            v.Cells["Size"].Value = msg1.FileSize;
                            //msg.PageCount = msg.ischangePageCount ? msg.ManulPageCount : (msg.isManual ? msg.PageCount : msg.FileMsgList.Sum(t => t.PageCount == -1 ? 0 : t.PageCount));
                            //v.Cells["页数"].Value = (msg.PageCount == -1 ? "----" : msg.PageCount.ToString());
                            v.Cells["打印机"].Value = msg1.PageCount == "----" ? "----" : FileHelper.SubStringByByte(msg1.Printer.ToString(),16);
                            //v.Cells["计价"].Value = msg1.PageCount == -1 ? "----" : (msg1.Count * msg1.PageCount * float.Parse(priceMsg[msg1.PrintColor.ToString() + msg1.VerForm.ToString()])).ToString(); 
                            if (msg1.InitPrice == "-1" || msg1.InitPrice == null)
                            {
                                msg1.InitPrice = "-2";
                                msg1.Price = msg1.GetPrice();
                            }
                            else if (msg1.InitPrice == "-2")
                            {
                                GroupMsg fp = main.groupList.Find(t=>t.UserID == msg1.UserID);
                                if(fp != null && int.Parse(fp.state) < 3)
                                    msg1.Price = msg1.GetPrice();
                            }
                            else
                                msg1.Price = msg1.InitPrice;
                            if(!v.Cells["计价"].IsInEditMode)
                                v.Cells["计价"].Value = msg1.Price;
                        }
                    }
                }
            }
            if (doRefresh)
            {
                refresh("");
                doRefresh = false;
            }
            timer1.Start();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
        }

        object lockobj = new object();
        public void doWork(string cmd)
        {
            string ID = "" ;
            string State = "" ;
            string tmpuserID = "";
            GroupMsg tmpmsg = null;
            string fileName = "";
            UserDB udb = null;
            if (cmd != "Date" && cmd != "用户" && cmd != "账单")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count != 0)
                {
                    ID = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                    State = dataGridView1.SelectedRows[0].Cells["State"].Value.ToString();
                    tmpuserID = dataGridView1.SelectedRows[0].Cells["UserID"].Value.ToString();
                    tmpmsg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == tmpuserID);
                    if (dataGridView1.SelectedRows[0].Cells["row_type"].Value.ToString() == "sub")
                        fileName = dataGridView1.SelectedRows[0].Cells["文件列表"].Value.ToString();
                    udb = new UserDB() { userName = tmpmsg.GroupName, lastAddr = tmpmsg.Area, lastTime =DateTime.Parse(tmpmsg.LoadTime), phone = tmpmsg.Phone };
                }
            }
            switch (cmd)
            {

                case "开始":
                    #region
                    if (tmpmsg == null)
                        break;
                    if (tmpmsg.Area == null || tmpmsg.Area.Length == 0 || tmpmsg.Time == null || tmpmsg.Time.Length == 0)
                    {
                        MessageBox.Show("地区和派送时间不能为空");
                        break;
                    }
                    FilePrinter f = new FilePrinter();
                    f.deleshowTipfunc = showTip;
                    f.AsyncPrinter(f,tmpmsg,frm_Main.nFastPrint);
                    #endregion
                    break;
                case "出票":
                    ExcelHelper.AddMs(tmpmsg);
                    break;
                case "出库":
                    #region
                    if (tmpmsg.Area == null || tmpmsg.Area.Length == 0 || tmpmsg.Time == null || tmpmsg.Time.Length == 0)
                    {
                        MessageBox.Show("地区和派送时间不能为空");
                        break;
                    }
                    OutUser(tmpmsg,udb);
                    SqlModlus.SaveGroupMsg(tmpmsg);
                    //ConfigClass.SaveCookie_List(groupList, "cookie.dat");
                    #endregion
                    break;
                case "删除":
                    string tipMsg = "";
                    if (dataGridView1.SelectedRows[0].Cells["row_type"].Value.ToString() == "sub")
                        tipMsg = "是否删除文件：" + fileName;
                    else
                        tipMsg = "是否删除订单：" + tmpmsg.GroupName;
                    if (MessageBox.Show(tipMsg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    Delete(tmpmsg,fileName);
                    tmpmsg.InitPrice = "-1";
                    if (dataGridView1.SelectedRows[0].Cells["row_type"].Value.ToString() == "main")
                        refresh("");
                    else
                    {
                        if (tmpmsg.FileMsgList.Count == 1)
                            refresh("");
                        else
                            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }  
                    break;
                case "Date":
                    refresh("");
                    break;
                case "刷新":
                    if (!UserHelper.isRefresh)
                    {
                        UserHelper.RefreshUser(frm_Main.CurrentPath);
                    }
                    break;
                case "开单":
                    #region
                    GroupMsg groupMsg = new GroupMsg() ;
                    double userID = -1;
                    groupMsg.UserID = (userID == -1 ? SQLiteHelper.GetUserID() : userID).ToString();
                    if (groupMsg.UserID == "-1")
                    {
                        MessageBox.Show("获取用户编号失败，请检查数据库连接");
                        break;
                    }
                    groupMsg.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    groupMsg.LoadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    groupMsg.isManual = true;
                    groupMsg.state = "0";
                    groupMsg.FileName = "订单类型，手动开单";
                    groupMsg.GroupName = "用户名";
                    groupMsg.Count = "1";
                    groupMsg.PageCount = "----";
                    //groupMsg.initPageCount = -1;
                    groupMsg.VerForm = "正反";
                    groupMsg.PrintColor = "黑白";
                    string defaultPaper = GetPaperType.defaultBWPaper;
                    groupMsg.PaperType = defaultPaper;
                    groupMsg.Printer = "----";
                    groupMsg.Price = "----";
                    groupMsg.PayType = "4";
                    groupMsg.SetTime = DateTime.Parse(frm_Main.CurrentDate).ToString("yyyy-MM-dd HH:mm:ss");
                    groupList.Add(groupMsg);
                    SqlModlus.InsertTmpUserMsg(groupMsg);
                    refresh("");
                    #endregion
                    break;
                case "用户":
                    用户数据库 frm_user = new 用户数据库();
                    foreach (var v in main.groupList)
                    {
                        if (v.isChange)
                        {
                            SqlModlus.SaveGroupMsg(v);
                            v.isChange = false;
                        }
                    }
                    frm_user.ShowDialog();
                    break;
                case "账单":
                    账单 frm_账单 = new 账单();
                    foreach (var v in main.groupList)
                    {
                        if (v.isChange)
                        {
                            SqlModlus.SaveGroupMsg(v);
                            v.isChange = false;
                        }
                    }
                    frm_账单.ShowDialog();
                    break;
                case "中止":
                    if (MessageBox.Show("此操作会中断改订单的后续操作，请问是否中止?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (tmpmsg.isPrint)
                        {
                            tmpmsg.isAbort = true;
                            tmpmsg.isCanceling = true;
                        }
                    }
                    break;
                default:
                    if (cmd.Contains("查询:"))
                    {
                        refresh(cmd.Split(':')[1]);
                    }
                    break;
            }
            //RefreshTool();
        }

        public void OutUser(GroupMsg tmpmsg, UserDB udb)
        {
            tmpmsg.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tmpmsg.state = "3";
            if (tmpmsg.FileDirectory == null)
                tmpmsg.FileDirectory = frm_Main.CurrentPath;
            if (!SqlModlus.InsertUserMsg(tmpmsg))
                MessageBox.Show("订单插入账单失败");
            InsertOrUpdateUser(udb);
            if (null != tmpmsg.FileMsgList)
            {
                foreach (FileMsg fmsg in tmpmsg.FileMsgList)
                {
                    SqlModlus.InsertFileMsg(fmsg, tmpmsg.GroupName);
                    fmsg.state = "3";
                }
            }
            dataGridView1.SelectedRows[0].Cells["State"].Value = tmpmsg.state;
            dataGridView1.SelectedRows[0].Cells["icon"].Value = tmpmsg.isManual ? mStateList.Images[tmpmsg.state] : StateList.Images[tmpmsg.state];
            dataGridView1.SelectedRows[0].Cells["文件列表"].Value = tmpmsg.FileName;
            tmpmsg.isShow = true;
        }

        public void showTip(GroupMsg tmpmsg)
        {
            TipForm tip = new TipForm();
            tip.setFormLable(tmpmsg);
            tip.Show();
        }

        public bool Delete(GroupMsg tmpmsg,string filename)
        {
            if (tmpmsg.isRemove)
                return false;
            if (filename.Trim().Length == 0)
            {
                if (!tmpmsg.isManual)
                {
                   bool b = FileHelper.DirectoryDelete(groupList, tmpmsg, tmpmsg.GroupName, tmpmsg.LoadTime);
                    if (!b)
                    {
                        MessageBox.Show("订单文件夹删除失败！");
                        return false;
                    }
                } 
                bool b1 = SqlModlus.DeleteGroupMsg(tmpmsg);
                if (!( b1))
                {
                    MessageBox.Show("订单删除失败！");
                    return false;
                }
                tmpmsg.isRemove = true;
                return true;
            }
            else
            {
                if (tmpmsg.FileMsgList == null)
                    return false;
                try
                {
                    FileMsg fm = tmpmsg.FileMsgList.Find(t => t.FileName == filename);
                    if (File.Exists(fm.FullName))
                        File.Delete(fm.FullName);
                    if (File.Exists(fm.FullName.Substring(0,fm.FullName.LastIndexOf('\\')+1) + fm.FileName))
                        File.Delete(fm.FullName.Substring(0, fm.FullName.LastIndexOf('\\') + 1) + fm.FileName);
                    lock (tmpmsg)
                    {
                        tmpmsg.FileMsgList.Remove(fm);
                    }
                    SqlModlus.DeleteFileMsg(fm.UserID,fm.FileName,fm.FullName);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(GroupMsg tmpmsg)
        {
            if (tmpmsg.isRemove)
                return false;
            if (!tmpmsg.isManual)
            {
                bool b = FileHelper.DirectoryDelete(groupList, tmpmsg, tmpmsg.GroupName, tmpmsg.LoadTime);
                //bool b1 = SqlModlus.DeleteGroupMsg(tmpmsg);
                if (!(b))
                {
                    MessageBox.Show("完成订单到期文件删除失败！");
                    return false;
                }
            }
            return true;
        }

        public static bool InsertOrUpdateUser(UserDB user)
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

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void main_Layout(object sender, LayoutEventArgs e)
        {
            dataGridView1.Width = this.Width;
            dataGridView1.Height = this.Height ;
        }
        int []sortArr = new int[] {0,0,0,0,0 };
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //RowComparer.RowName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "icon")
            {
                refresh("");
                if (sortArr[0] % 2 == 0)
                    dataGridView1.Sort(new RowComparer(SortOrder.Ascending));
                else
                    dataGridView1.Sort(new RowComparer(SortOrder.Descending));
                sortArr[0]++;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "用户名")
            {
                refresh("");
                SortOrder s = ((sortArr[0] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
                SortOrder s1 = ((sortArr[2] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
                if (sortArr[1] % 2 == 0)
                    dataGridView1.Sort(new RowComparerUserState(SortOrder.Ascending, s1,s, "用户名"));
                else
                    dataGridView1.Sort(new RowComparerUserState(SortOrder.Descending, s1,s, "用户名"));
                sortArr[1]++;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "时间")
            {
                refresh("");
                SortOrder s = ((sortArr[0] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
                if (sortArr[2] % 2 == 0)
                    dataGridView1.Sort(new RowComparerUser(SortOrder.Ascending, s, "时间"));
                else
                    dataGridView1.Sort(new RowComparerUser(SortOrder.Descending, s, "时间"));
                sortArr[2]++;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "地点")
            {
                refresh("");
                SortOrder s = ((sortArr[0] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
                SortOrder s1 = ((sortArr[2] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
                if (sortArr[3] % 2 == 0)
                    dataGridView1.Sort(new RowComparerUserState(SortOrder.Ascending, s1, s, "地点"));
                else
                    dataGridView1.Sort(new RowComparerUserState(SortOrder.Descending, s1, s, "地点"));
                sortArr[3]++;
            }
            //else if (dataGridView1.Columns[e.ColumnIndex].Name == "录入时间")
            //{
            //    SortOrder s = ((sortArr[0] - 1) % 2) == 0 ? SortOrder.Ascending : SortOrder.Descending;
            //    if (sortArr[4] % 2 == 0)
            //        dataGridView1.Sort(new RowComparerUser(SortOrder.Ascending, s, "录入时间"));
            //    else
            //        dataGridView1.Sort(new RowComparerUser(SortOrder.Descending, s, "录入时间"));
            //    sortArr[4]++;
            //}
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            string userID = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == userID);
            if (msg == null)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Check")
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Size")
            {
                e.Cancel = true;
                return;
            }
            if (DateTime.Parse(msg.SetTime).Date < DateTime.Now.Date)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "时间")
                    {
                        //refreshDgvTimeItem(e.RowIndex);
                        //e.Cancel = true;
                        //return;
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "备注")
                    {
                        return;
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else if(dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "sub")
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["State"].Value.ToString() == "3")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "main")
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "计价" || dataGridView1.Columns[e.ColumnIndex].Name == "时间" ||
                        dataGridView1.Columns[e.ColumnIndex].Name == "地点" || dataGridView1.Columns[e.ColumnIndex].Name == "联系方式" || dataGridView1.Columns[e.ColumnIndex].Name == "支付方式")
                    {
                        if (DateTime.Parse(msg.FinishTime).Date < DateTime.Now.Date)
                        {
                            e.Cancel = true;
                            return;
                        }
                        msg.isChange = true;
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "备注")
                    {
                        msg.isChange = true;
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }

                }

            }
            if (dataGridView1.Rows[e.RowIndex].Cells["row_type"].Value.ToString() == "sub")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "用户名" || dataGridView1.Columns[e.ColumnIndex].Name == "页数"
                    || dataGridView1.Columns[e.ColumnIndex].Name == "时间" || dataGridView1.Columns[e.ColumnIndex].Name == "地点"
                    || dataGridView1.Columns[e.ColumnIndex].Name == "联系方式" //|| dataGridView1.Columns[e.ColumnIndex].Name == "备注"
                    || dataGridView1.Columns[e.ColumnIndex].Name == "文件列表" || dataGridView1.Columns[e.ColumnIndex].Name == "录入时间"
                    || dataGridView1.Columns[e.ColumnIndex].Name == "完成时间")
                    e.Cancel = true;
                else if ((dataGridView1.Columns[e.ColumnIndex].Name == "计价" || dataGridView1.Columns[e.ColumnIndex].Name == "份数") && int.Parse(msg.state) >= 3)
                {
                    e.Cancel = true;
                }
                return;
            }
            if (msg.isPrint)
            {
                e.Cancel = true;
                return;
            }
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "录入时间":
                    e.Cancel = true;
                    break;
               case "完成时间":
                    e.Cancel = true;
                    break;
                case "时间":
                    refreshDgvTimeItem(e.RowIndex);
                    break;
                case "用户名":
                    if (!msg.isManual)
                        e.Cancel = true;
                    break;
                case "文件列表":
                    if (!msg.isManual)
                        e.Cancel = true;
                    break;
                case "页数":
                    //if (!msg.isManual)
                    //    e.Cancel = true;
                    break;
                case "计价":
                    //if (!msg.isManual)
                    //    e.Cancel = true;
                    PriceEditFlag = true;
                    break;
                case "份数":
                    if (!msg.isManual)
                    {
                        string s = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? "" : dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        //if(s == "多选")
                        //    e.Cancel = true;
                    }
                    break;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PriceEditFlag = false;
        }

        private bool PriceEditFlag = false;
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           var v =  dataGridView1.HitTest(e.X,e.Y);
            if (v.ColumnIndex == -1 || v.RowIndex == -1)
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.SelectedRows[0].Cells["icon"].Selected = true;
                    dataGridView1.SelectedRows[0].Cells["icon"].Selected = false;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != "文件列表")
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewProgressBarCell)
                return;
            Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
             e.CellBounds.Y + 1, e.CellBounds.Width - 4,
             e.CellBounds.Height - 4);
            string userID = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == userID);
            Color c1,c2;
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index == e.RowIndex)
            {
                c1 = e.CellStyle.SelectionBackColor;
                c2 = e.CellStyle.SelectionForeColor;
            }
            else
            {
                c1 = e.CellStyle.BackColor;
                c2 = e.CellStyle.ForeColor;
            }
            if (msg.isManual || msg.FileMsgList == null)
                return;
            using (
                Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                backColorBrush = new SolidBrush(c1))
            {
                using (Pen gridLinePen = new Pen(gridBrush))
                {
                    Rectangle re = e.CellBounds;
                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), re);
                    re.Height = re.Height - 6;
                    e.Graphics.FillRectangle(backColorBrush, re);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                        e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                        e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom);

                    Font f1 = new Font("微软雅黑",9, FontStyle.Bold);
                    drawScale(e.Graphics, e.CellBounds.X + 2, e.CellBounds.Y + 2,f1);

                    if (e.Value != null)
                    {
                        FileMsg fmsg = msg.FileMsgList.Find(t=>t.FileName == e.Value.ToString());
                        if (fmsg.state == "-1")
                        {
                            Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                            e.Graphics.DrawString("×", f,
                                Brushes.Red, e.CellBounds.X + 2+15,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        }
                        else if(int.Parse(fmsg.state) >= 3)
                        {
                            Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                            e.Graphics.DrawString("√", f,
                                Brushes.Green, e.CellBounds.X + 2+15,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        }
                        e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                            Brushes.Black, e.CellBounds.X + 20 + 15,
                            e.CellBounds.Y + 2, StringFormat.GenericDefault);
                    }
                    e.Handled = true;
                }
            }
        }

        private void drawScale(Graphics g,int x,int y,Font f)
        {
            // 圆角半径
            int cRadius = 1;
            int Width = 15;
            int Height = 15;

            // 要实现 圆角化的 矩形
            Rectangle rect = new Rectangle(x, y, Width - cRadius, Height - cRadius);
            g.DrawString("4",f, Brushes.Red,new Point(x,y));

            // 指定图形路径， 有一系列 直线/曲线 组成
            GraphicsPath myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
            myPath.AddLine(new Point(rect.X + cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            myPath.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Bottom - cRadius));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
            myPath.AddLine(new Point(rect.Right - cRadius, rect.Bottom), new Point(rect.X + cRadius, rect.Bottom));
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
            myPath.AddLine(new Point(rect.X, rect.Bottom - cRadius), new Point(rect.X, rect.Y + cRadius));
            myPath.CloseFigure();
            g.DrawPath(new Pen(Color.Black, 1), myPath);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //RefreshTool();
        }
        public static string TipStr = "";
        private void RefreshTool( bool dateFlag)
        {
            int dateInt = dateFlag ? 1 : 0;
            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                dealControlDelegate(new int[] { gettoolState(-1) ,0, dateInt });
                TipStr = "";
                return;
            }
            int rowIndex = dataGridView1.SelectedRows[0].Index;
            GroupMsg groupmsg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[rowIndex].Cells["UserID"].Value.ToString());
            if (DateTime.Parse(groupmsg.SetTime).Date < DateTime.Now.Date)
            {
                dealControlDelegate(new int[] { 0x08, 0, dateInt });
                return;
            }
            if (dataGridView1.Rows[rowIndex].Cells["row_type"].Value.ToString() == "main")
            {
                int state = int.Parse(dataGridView1.Rows[rowIndex].Cells["State"].Value.ToString());
                if ((dataGridView1.Rows[rowIndex].Cells["时间"].Value == null || dataGridView1.Rows[rowIndex].Cells["时间"].Value.ToString() == "")
                    || (dataGridView1.Rows[rowIndex].Cells["地点"].Value == null || dataGridView1.Rows[rowIndex].Cells["地点"].Value.ToString() == "") 
                    || (dataGridView1.Rows[rowIndex].Cells["联系方式"].Value == null || dataGridView1.Rows[rowIndex].Cells["联系方式"].Value.ToString() == ""))
                {
                    TipStr = "时间、地点、联系方式信息填写不完整！";
                    dealControlDelegate(new int[] { 0x08 ,0, dateInt });
                }
                else
                {
                    TipStr = "";
                    GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[rowIndex].Cells["UserID"].Value.ToString());
                    int tmpi = !msg.isAbort && msg.isPrint && !msg.isCanceling ? 1 : 0;
                    if (msg.isManual)
                    {
                        if (state == 1 || state == 0)
                            dealControlDelegate(new int[] { gettoolState(-2), tmpi, dateInt });
                        else
                            dealControlDelegate(new int[] { gettoolState(state), tmpi, dateInt });
                    }
                    else
                    {
                        if (msg.FileMsgList.Count() == msg.FileMsgList.Count(t => t.isNormalFile))
                            dealControlDelegate(new int[] { gettoolState(state) & 0x0e , tmpi, dateInt });
                        if (msg.FileMsgList.Count(t => t.isNormalFile == false) == msg.FileMsgList.Count(t => t.isNormalFile == false && int.Parse(t.state) >= 3))
                        {
                            dealControlDelegate(new int[] { gettoolState(state) & 0x0e, tmpi, dateInt });
                        }
                        else
                        {
                            if (msg.isPrint)
                                dealControlDelegate(new int[] { gettoolState(state) & 0x00, tmpi, dateInt });
                            else
                                dealControlDelegate(new int[] { gettoolState(state), tmpi, dateInt });
                        }
                    }
                }
            }
            else if (dataGridView1.Rows[rowIndex].Cells["row_type"].Value.ToString() == "sub")
            {
                TipStr = "";
                GroupMsg msg = groupList.Find(t => t.isRemove == false && t.UserID.ToString() == dataGridView1.Rows[rowIndex].Cells["UserID"].Value.ToString());
                int tmpi = !msg.isAbort && msg.isPrint && !msg.isCanceling ? 1 : 0;
                if (msg.isPrint)
                    dealControlDelegate(new int[] { 0x00, tmpi, dateInt });
                else
                    dealControlDelegate(new int[] { 0x08, tmpi, dateInt });
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (Directory.Exists(path))
            {
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                if (!Directory.Exists(frm_Main.CurrentPath + "\\" + name))
                    FileHelper.CopyDirectory(path, frm_Main.CurrentPath);
                else
                    MessageBox.Show("文件已存在！");
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if(cb != null)
            {
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 10;
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += new DrawItemEventHandler(delegate (object sender1, DrawItemEventArgs e1)
                {
                    if (e1.Index < 0)
                    {
                        return;
                    }
                    e1.DrawBackground();
                    e1.DrawFocusRectangle();
                    e1.Graphics.DrawString(cb.Items[e1.Index].ToString(), e1.Font, new SolidBrush(e1.ForeColor), e1.Bounds.X, e1.Bounds.Y + 3);
                });
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == -1 || e.RowIndex == -1)
            //    return;
            //if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            //    return;
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "份数" || dataGridView1.Columns[e.ColumnIndex].Name == "页数" || dataGridView1.Columns[e.ColumnIndex].Name == "计价")
            //{
            //    if (e.FormattedValue != null && e.FormattedValue.ToString() != "")
            //    {
            //        float f = 0;
            //        bool b = float.TryParse(e.FormattedValue.ToString(), out f);
            //        if (!b)
            //        {
            //            e.Cancel = true;
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //        }
            //    }
            //}
        }
    }
}
