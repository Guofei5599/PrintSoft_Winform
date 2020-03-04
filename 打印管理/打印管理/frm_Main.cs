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
using Spire.Pdf;
using Spire.Pdf.Print;
using System.IO;
using System.Threading;
using System.Media;

namespace 打印管理
{
    public partial class frm_Main : Form
    {
        public static main frm_MainMenu;
        public static string CurrentDate = "";
        public delegate void toolDoWork(string tmp);
        public delegate void NumFormExect(string Num);
        public toolDoWork tooldoWork = null;

        public static sysConfig sysConfigData = new sysConfig();
        public static bool bExit = false;
        public static bool nFastPrint = false;
        public static SoundPlayer sound; 

        public frm_Main()
        {
            InitializeComponent();
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            Size size = this.MinimumSize;
            this.MinimumSize = new Size(Math.Min(ScreenArea.Width ,size.Width), Math.Min(ScreenArea.Height, size.Height));
        }

        private void GetUserMsg(string root)
        {
            DirectoryInfo info = new DirectoryInfo(root);
            var vvv = info.GetDirectories();
            foreach (var v in info.GetDirectories())
            {
                GetDocFile(v,v.Name);
            }
        }
        private void GetDocFile(DirectoryInfo userPath, string userName)
        {
            WTPMsg wTPMsg;
            foreach (var v in userPath.GetFiles())
            {
                string[] ext = v.Name.Split('.');
                if (ext[ext.Length - 1].ToUpper() != "DOC" && ext[ext.Length - 1].ToUpper() != "DOCX")
                    continue;
                if ((v.Attributes & FileAttributes.Hidden) > 0)
                    continue;
                if (v.Name.IndexOf("~$") == 0)
                    continue;
                wTPMsg = new WTPMsg()
                {
                    FileName = v.Name,
                    FullFileName = v.FullName,
                    UserName = userName,
                    pority = false
                };
                WordToPdf.AddMsg(wTPMsg);
            }
            foreach (var v in userPath.GetDirectories())
            {
                GetDocFile(v, userName);
            }
        }

        private void TimerGetUserMsg(string root)
        {
            DirectoryInfo info = new DirectoryInfo(root);
            foreach (var v in info.GetDirectories())
            {
                if (UserHelper.isRefresh)
                    return;
                AddNoConvertDocFile(v, v.Name);
            }
        }

        private void AddNoConvertDocFile(DirectoryInfo userPath, string userName)
        {
            WTPMsg wTPMsg;
            foreach (var v in userPath.GetFiles())
            {
                if (UserHelper.isRefresh)
                    return;
                string[] ext = v.Name.Split('.');
                if (ext[ext.Length - 1].ToUpper() != "DOC" && ext[ext.Length - 1].ToUpper() != "DOCX")
                    continue;
                if ((v.Attributes & FileAttributes.Hidden) > 0)
                    continue;
                if (v.Name.IndexOf("~$") == 0)
                    continue;
                string newFileName = WordToPdf.GetPdfPath(v.FullName);
                if (File.Exists(newFileName))
                    continue;
                wTPMsg = new WTPMsg()
                {
                    FileName = v.Name,
                    FullFileName = v.FullName,
                    UserName = userName,
                    pority = false
                };
                WordToPdf.AddMsg(wTPMsg);
            }
            foreach (var v in userPath.GetDirectories())
            {
                AddNoConvertDocFile(v, userName);
            }
        }

       

        public static bool unInit = true;
        public static bool logFlag = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            //File.AppendAllLines(@"E:\代码\C#\Winform\私单\打印管理20190916\20190820\打印管理\打印管理\bin\Debug\log\logtext 20190926 171728.txt",new string[] { "123456"});

            bool b = SQLiteHelper.SQLiteInit(string.Format(@"Data Source={0}\PrintDB.db", Application.StartupPath), "jtmes");
            if (b)
            {
                KeyPreview = true;
                try
                {
                    foreach (var v in toolStrip1.Items)
                    {
                        if (v is ToolStripButton)
                        {
                            ToolStripButton Tbtn = v as ToolStripButton;
                            if (Convert.ToString(Tbtn.Tag) == "1")
                            {
                                Tbtn.Paint += toolStrip1_Paint;
                                Tbtn.MouseMove += toolStrip1_MouseMove;
                            }
                        }
                    }
                    logFlag = Convert.ToBoolean(ConfigClass.GetConfigString("sys", "log", "true"));
                    LogOperate.Init();
                    LogOperate.Start();
                    LogOperate.Add("软件运行");
                    CurrentPath = ConfigClass.GetConfigString("File", "path", "");
                    if (!Directory.Exists(CurrentPath))
                    {
                        FolderBrowserDialog f = new FolderBrowserDialog();
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            CurrentPath = f.SelectedPath;
                            ConfigClass.SetConfigString("File", "path", CurrentPath);
                        }
                        else
                        {
                            unInit = true;
                            Application.Exit();
                        }
                    }
                    string strFastPrint = ConfigClass.GetConfigString("Printer", "speed", "false");
                    CK_fastPrint.Checked = strFastPrint.ToUpper() == "TRUE" ? true : false;
                    nFastPrint = CK_fastPrint.Checked;
                    bool bConvert = Convert.ToBoolean(ConfigClass.GetConfigString("sys", "Convert", "false"));
                    if (bConvert)
                    {
                        timer2.Interval = 1000;
                        timer2.Enabled = true;
                    }
                    else
                    {
                        fileWatcher.Path = CurrentPath;
                        fileWatcher.EnableRaisingEvents = true;
                    }
                    sysConfigData.printerName = ConfigClass.GetConfigString("sys", "小票打印机", "");
                    sysConfigData.ShopName = ConfigClass.GetConfigString("sys", "店铺名称", "");
                    sysConfigData.BarcodePath = ConfigClass.GetConfigString("sys", "二维码路径", "");
                    sound = new System.Media.SoundPlayer("Audio.wav");
                    sound.Load();
                    //main.groupList = ConfigClass.LoadCookie<GroupMsg>("cookie.dat");
                    main.groupList = SqlModlus.selectTmpUserMsg();
                    if (main.groupList == null)
                        main.groupList = new List<GroupMsg>();
                    foreach (var v in main.groupList)
                    {
                        if (!v.isManual)
                        {
                            List<FileMsg> fmsg = SqlModlus.selectTmpFileMsg(v.UserID);
                            v.FileMsgList = fmsg;
                        }
                    }
                    main.groupList.ForEach(t => t.isPrint = false);
                    main.groupList.RemoveAll(t => t.isRemove == true);
                    txt_Date.Text = DateTime.Now.Date.ToLongDateString();
                    CurrentDate = txt_Date.Text;

                    FileHelper.timelist = GetPeopleMsg.GetTimeList();
                    FileHelper.addrList = GetPeopleMsg.GetAddrList();
                    FileHelper.rowMsg = GetDefaultAddMsg.getMsg();
                    GetPaperType.UpdatePaperList();
                    GetPrinterType.UpdatePrinterList();
                    GetPaperPrice.getPrice();

                    GetUserMsg(CurrentPath);
                    WordToPdf.Start();
                    DealControl(new int[] { 0, 0, 0 });
                    CheckForIllegalCrossThreadCalls = false;
                    treeView1.ExpandAll();
                    treeView1.MouseDoubleClick += new MouseEventHandler(treeView1_DoubleClick);
                    txt_path.Text = CurrentPath;
                    //FileHelper.act.BeginInvoke(frm_Main.CurrentPath, callback, null);
                    frm_MainMenu = New_Form(frm_MainMenu);
                    tooldoWork = frm_MainMenu.doWork;
                    if (frm_MainMenu != null)
                    {
                        frm_MainMenu.setdgvPos(panel_Parent.Width, panel_Parent.Height);
                    }
                    ExcelHelper.Start();
                    frm_MainMenu.refresh("");
                    toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
                    unInit = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("数据库连接异常!");
            }
        }

        private void NumFormExectFunc(string Num)
        {
            if (Num == "CLR")
                txt_user.Text = "";
            else if (Num == "Esc")
            {
                if (txt_user.Text.Length > 0)
                    txt_user.Text = txt_user.Text.Substring(0, txt_user.Text.Length - 1);
            }
            else
            {
                txt_user.Text += Num;
            }
            txt_user.SelectionStart=txt_user.Text.Length;
            txt_user.Focus();
        }

        private bool HitFlag = false;
        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(new Point(46, 50),new Size(9,7));
            if (rect.Contains(new Point(e.X, e.Y)))
            {
                HitFlag = true;
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                HitFlag = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = Brushes.Black;
            g.FillPolygon(b,new Point[] {new Point(47,52),new Point(55,52),new Point(51,56) });
        }

        private DateTime RefreshDateTime = DateTime.Now;
        private void toolStrip1_ItemClicked(object sender,ToolStripItemClickedEventArgs e)
        {
            if (tooldoWork != null)
            {
                if (HitFlag)
                {
                    if (e.ClickedItem.Name.Substring(0, 2) == "刷新")
                    {
                        ContextMenu contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add(0, new MenuItem("保存", subMenuItemClick));
                        int i = contextMenu.MenuItems.Add(1, new MenuItem("上次刷新" + ((int)((DateTime.Now - RefreshDateTime).TotalMinutes)).ToString() + "min"));
                        contextMenu.MenuItems[i].Enabled = false;
                        Point p = PointToClient(MousePosition);
                        contextMenu.Show(toolStrip1, p);
                    }
                    else if (e.ClickedItem.Name.Substring(0, 2) == "开始")
                    {
                        ContextMenu contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add(0, new MenuItem("封面输出", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("合并输出", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("定时输出", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("多线输出", subMenuItemClick));
                        Point p = PointToClient(MousePosition);
                        contextMenu.Show(toolStrip1, p);
                    }
                    else if (e.ClickedItem.Name.Substring(0, 2) == "删除")
                    {
                        ContextMenu contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add(0, new MenuItem("复制", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("合并", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("拆分", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("预览", subMenuItemClick));
                        contextMenu.MenuItems.Add(0, new MenuItem("中止", subMenuItemClick));
                        Point p = PointToClient(MousePosition);
                        contextMenu.Show(toolStrip1, p);
                    }
                }
                else
                {
                    if (e.ClickedItem.Name.Substring(0, 2) == "刷新")
                    {
                        txt_user.Text = "";
                        RefreshDateTime = DateTime.Now;
                    }
                    tooldoWork.Invoke(e.ClickedItem.Name.Substring(0, 2));
                    if (e.ClickedItem.Name.Substring(0, 2) == "设置")
                    {
                        系统设置 frm_sys = new 系统设置();
                        frm_sys.ShowDialog();
                        sysConfigData.printerName = ConfigClass.GetConfigString("sys", "小票打印机", "");
                        sysConfigData.ShopName = ConfigClass.GetConfigString("sys", "店铺名称", "");
                        sysConfigData.BarcodePath = ConfigClass.GetConfigString("sys", "二维码路径", "");
                        FileHelper.timelist = GetPeopleMsg.GetTimeList();
                        FileHelper.addrList = GetPeopleMsg.GetAddrList();
                        FileHelper.rowMsg = GetDefaultAddMsg.getMsg();
                        GetPaperType.UpdatePaperList();
                        GetPrinterType.UpdatePrinterList();
                        GetPaperPrice.getPrice();
                    }
                }
            } 
        }

        private void subMenuItemClick(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch (item.Text)
            {
                case "保存":

                    break;
                    
            }
        }

        public static int[] clickArr = new int[] { 0, 0, 0, 0, 0 };

        private void inittool()
        {
            新订单toolStripButton1.BackColor = SystemColors.Control;
            本轮订单toolStripButton2.BackColor = SystemColors.Control;
            下轮订单toolStripButton3.BackColor = SystemColors.Control;
            已完成订单toolStripButton4.BackColor = SystemColors.Control;
            clickArr[1] = 0;
            clickArr[2] = 0;
            clickArr[3] = 0;
            clickArr[4] = 0;
        }
        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Substring(0,4))
            {
                case "手动开单":
                    if (e.ClickedItem.BackColor == SystemColors.ButtonShadow)
                    {
                        clickArr[0] = 0;
                        e.ClickedItem.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        clickArr[0] = 1;
                        e.ClickedItem.BackColor = SystemColors.ButtonShadow;
                    }
                    break;
                case "新订单(":
                    if (e.ClickedItem.BackColor == SystemColors.ButtonShadow)
                    {
                        clickArr[1] = 0;
                        e.ClickedItem.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        inittool();
                        clickArr[1] = 1;
                        e.ClickedItem.BackColor = SystemColors.ButtonShadow;
                    }
                    break;
                case "本轮订单":
                    if (e.ClickedItem.BackColor == SystemColors.ButtonShadow)
                    {
                        clickArr[2] = 0;
                        e.ClickedItem.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        inittool();
                        clickArr[2] = 1;
                        e.ClickedItem.BackColor = SystemColors.ButtonShadow;
                    }
                    break;
                case "下一轮订":
                    if (e.ClickedItem.BackColor == SystemColors.ButtonShadow)
                    {
                        clickArr[3] = 0;
                        e.ClickedItem.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        inittool();
                        clickArr[3] = 1;
                        e.ClickedItem.BackColor = SystemColors.ButtonShadow;
                    }
                    break;
                case "已完成订":
                    if (e.ClickedItem.BackColor == SystemColors.ButtonShadow)
                    {
                        clickArr[4] = 0;
                        e.ClickedItem.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        inittool();
                        clickArr[4] = 1;
                        e.ClickedItem.BackColor = SystemColors.ButtonShadow;
                    }
                    break;
            }
            frm_MainMenu.refresh("");
        }

        string[] tip = new string[] {"F5","F6","F7","F8" };
        public void DealControl(int[] state)
        {
            #region  开始 出票  出库 删除
            开始toolStripButton.Enabled = (state[0] & 0x01) == 0x01 ? true : false;
            出票toolStripButton.Enabled = ((state[0] >> 1) & 0x01) == 0x01 ? true : false;
            出库toolStripButton.Enabled = ((state[0] >> 2) & 0x01) == 0x01 ? true : false;
            删除toolStripButton.Enabled = ((state[0] >> 3) & 0x01) == 0x01 ? true : false;
            中止toolStripButton1.Enabled = state[1] == 1 ? true : false;
            if (state[2] == 1)
            {
                btn_add.Enabled = true;
                btn_sub.Enabled = true;
                txt_Date.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
                btn_sub.Enabled = false;
                txt_Date.Enabled = false;
            }
            if (main.TipStr != "")
            {
                开始toolStripButton.ToolTipText = 开始toolStripButton.Enabled ? tip[0] : main.TipStr;
                出票toolStripButton.ToolTipText = 出票toolStripButton.Enabled ? tip[1] : main.TipStr;
                出库toolStripButton.ToolTipText = 出库toolStripButton.Enabled ? tip[2] : main.TipStr;
                删除toolStripButton.ToolTipText = 删除toolStripButton.Enabled ? tip[3] : main.TipStr;
            }
            else
            {
                开始toolStripButton.ToolTipText = tip[0];
                出票toolStripButton.ToolTipText = tip[1];
                出库toolStripButton.ToolTipText = tip[2];
                删除toolStripButton.ToolTipText = tip[3];
            }
            #endregion
        }

        public void DealStatus(int [] value)
        {
            #region  状态栏
            手动开单toolStripButton1.Text = string.Format("手动开单({0})",value[0]);
            新订单toolStripButton1.Text = string.Format("新订单({0})", value[1]);
            本轮订单toolStripButton2.Text = string.Format("本轮订单({0})", value[2]);
            下轮订单toolStripButton3.Text = string.Format("下一轮订单({0})", value[3]);
            已完成订单toolStripButton4.Text = string.Format("已完成订单({0})", value[4]);
            #endregion
        }

        private void treeView1_DoubleClick(object sender, MouseEventArgs e)
        {
            var tmpControl = treeView1.GetNodeAt(new Point(e.X,e.Y));
            if (tmpControl == null)
                return;
            switch (tmpControl.Text)
            {
                case "主界面":
                    frm_MainMenu = New_Form(frm_MainMenu);
                    tooldoWork = frm_MainMenu.doWork;
                    if (frm_MainMenu != null)
                    {
                        frm_MainMenu.setdgvPos(panel_Parent.Width, panel_Parent.Height);
                    }
                    break;
                case "机器管理":
                    机器管理 frm_机器管理 = new 机器管理();
                    frm_机器管理.ShowDialog();
                    break;
                case "纸张管理":
                    纸张管理 frm_纸张管理 = new 纸张管理();
                    frm_纸张管理.ShowDialog();
                    break;
                case "价格管理":
                    价格管理 frm_价格管理 = new 价格管理();
                    frm_价格管理.ShowDialog();
                    break;
                case "配送管理":
                    配送管理 frm_配送管理 = new 配送管理();
                    frm_配送管理.ShowDialog();
                    FileHelper.timelist = GetPeopleMsg.GetTimeList();
                    FileHelper.addrList = GetPeopleMsg.GetAddrList();
                    break;
                case "小票管理":
                    //List<GroupMsg> tmpList = new List<GroupMsg>();
                    //tmpList.Add( new GroupMsg { GroupName = "150001", Area = "地址", Note = "订单备注",Price = "15.3元", Phone = "189XXXXXXXX",
                    //    FileMsgList = new List<FileMsg> { new FileMsg { Printer = "打印机1输出", FileName = "文件名1。。。" , Count = 1, VerForm = emVerForm.单面},
                    //                                                            new FileMsg { Printer = "打印机1输出", FileName = "文件名2。。。" , Count = 1, VerForm = emVerForm.单面},
                    //                                                            new FileMsg { Printer = "打印机1输出", FileName = "文件名3。。。" , Count = 1, VerForm = emVerForm.正反},
                    //                                                            new FileMsg { Printer = "打印机1输出", FileName = "文件名4。。。" , Count = 1, VerForm = emVerForm.单面},
                    //                                                            new FileMsg { Printer = "打印机2输出", FileName = "文件名1。。。" , Count = 1, VerForm = emVerForm.正反}} });
                    //小票管理 f = new 小票管理();
                    //f.CreateMsg(tmpList[0]);
                    //f.ShowDialog();
                    //f.Dispose();
                    //f.Show();
                    break;
                case "用户数据库":
                    用户数据库 frm_user = new 用户数据库();
                    frm_user.ShowDialog();
                    break;
                case "账单":
                    账单 frm_账单 = new 账单();
                    frm_账单.ShowDialog();
                    break;
            }
        }

        private void txt_user_Click(object sender, EventArgs e)
        {
            if (tooldoWork != null)
                tooldoWork.Invoke("查询:"+ txt_user.Text);
        }

    public T New_Form<T>(T Form) where T : Form,new()
        {
            if (panel_Parent.Controls.Contains(Form))
            {
                panel_Parent.Controls.SetChildIndex(Form, 0);
                Form.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Form = new T();
                if (Form is main)
                {
                    (Form as main).dealControlDelegate = DealControl;
                    (Form as main).dealStatusDelegate = DealStatus;
                }
                panel_Parent.Controls.Add(Form);
                Form.Show();
            }
            return Form;
        }

        public static string CurrentPath = "";

        private string tmp_tishi = "";
        public static string preString = "-正在转换...";
        int tmpi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmpi < 3)
            {
                tmpi++;
            }
            if (tmpi == 3)
            {
                txt_user.Focus();
                tmpi++;
            }
            //txt_path.Text = CurrentPath;
            if (WordToPdf.WTPFileMsgList.Count > 0)
            {
                if (this.Text.IndexOf(preString) == -1)
                    this.Text += preString;
                tmp_tishi = string.Format("文件转换({0})", WordToPdf.WTPFileMsgList.Count.ToString());
                刷新toolStripButton.Enabled = false;
                txt_path.Enabled = false;
            }
            else
            {
                if (this.Text.IndexOf(preString) != -1)
                    this.Text = this.Text.Replace(preString,"");
                tmp_tishi = string.Format("文件转换(0)");
                刷新toolStripButton.Enabled = true;
                txt_path.Enabled = true;
            }
            设置toolStripButton.Enabled = 刷新toolStripButton.Enabled;
            账单toolStripButton.Enabled = 刷新toolStripButton.Enabled;
            用户库toolStripButton.Enabled = 刷新toolStripButton.Enabled;
            WTP提示.Text = tmp_tishi;
        }

        private void txt_Date_DoubleClick(object sender, EventArgs e)
        {
            string tDateTime = string.Empty;
            Point t = PointToScreen(new Point(txt_Date.Location.X, txt_Date.Location.Y + txt_Date.Height));
            NewOpenManager1.OpenWindow(ref tDateTime, t);
            if (tDateTime == null)
            { 
            }
            else
            {
                txt_Date.Text = tDateTime;
                CurrentDate = txt_Date.Text;
                FileHelper.timelist = GetPeopleMsg.GetTimeList();
                if (tooldoWork != null)
                    tooldoWork.Invoke("Date");
            }
        }

        private void txt_path_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("修改路径将重启程序，请问是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    CurrentPath = folder.SelectedPath;
                    //txt_path.Text = CurrentPath;
                    ConfigClass.SetConfigString("File", "path", CurrentPath);
                    Application.Restart();
                }
               
            }
            
        }
        private Point pos(Control c)
        {
            Point reval = new Point(0,0);
            do
            {
                reval.Offset(c.Location);
                c = c.Parent;
            } while (c != null);
            return reval;

        }

        private void frm_Main_Click(object sender, EventArgs e)
        {
            if (NewOpenManager1.State)
                NewOpenManager1.Close();
        }

        private void txt_Date_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!unInit)
            {
                if (main.groupList.FindIndex(t => t.isPrint == true) != -1)
                {
                    MessageBox.Show("请打印文件完成后再退出！");
                    e.Cancel = true;
                }
                if (this.Text.IndexOf(preString) != -1)
                    this.Text.Replace(preString, "-正在关闭...");
                else
                    this.Text += "-正在关闭...";
                foreach (var v in main.groupList)
                {
                    if(!v.isRemove)
                        SqlModlus.SaveGroupMsg(v);
                }
                try
                {
                    bExit = true;
                    WordToPdf.RunFlag = false;
                    ExcelHelper.RunFlag = false;
                    WordToPdf.Stop();
                    ExcelHelper.Stop();
                    foreach (var v in FileHelper.lockFileList)
                    {
                        v.fs.Close();
                        File.Delete(v.FullName);
                    }
                    LogOperate.Add("软件关闭！");
                    LogOperate.Stop();
                }
                catch { }
            }
           
        }
        private void frm_Main_SizeChanged(object sender, EventArgs e)
        {
            if (frm_MainMenu != null)
            {
                frm_MainMenu.setdgvPos(panel_Parent.Width, panel_Parent.Height);
                NumForm.Location = PointToScreen(new Point(Search_panel1.Left, Search_panel1.Bottom));
            }
        }

        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Replace(fileWatcher.Path,"").Contains('\\'))
                return;
            string [] ext = e.Name.Split('.');
            if (ext[ext.Length - 1].ToUpper() != "DOC" && ext[ext.Length - 1].ToUpper() != "DOCX")
                return;
            string[] tmpStr = e.Name.Split('\\');
            WTPMsg wTPMsg = new WTPMsg()
            {
                FileName = tmpStr[tmpStr.Length - 1],
                FullFileName = e.FullPath,
                UserName = tmpStr[0],
                pority = false
            };
            WordToPdf.AddMsg(wTPMsg);
        }

        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {

        }

        DateTime lastDateTime = DateTime.Now;
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if ((DateTime.Now - lastDateTime).TotalMilliseconds < 500)
                return;
            switch (e.KeyCode)
            {
                case Keys.F12:
                    if (刷新toolStripButton.Enabled)
                    {
                        刷新toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F1:
                    if (开单toolStripButton.Enabled)
                    {
                        开单toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F2:
                    if (用户库toolStripButton.Enabled)
                    {
                        用户库toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F3:
                    if (账单toolStripButton.Enabled)
                    {
                        账单toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F4:
                    if (设置toolStripButton.Enabled)
                    {
                        设置toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F5:
                    if (开始toolStripButton.Enabled)
                    {
                        开始toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F6:
                    if (出票toolStripButton.Enabled)
                    {
                        出票toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    }  
                    break;
                case Keys.F7:
                    if (出库toolStripButton.Enabled)
                    {
                        出库toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    } 
                    break;
                case Keys.F8:
                    if (删除toolStripButton.Enabled)
                    {
                        删除toolStripButton.PerformClick();
                        lastDateTime = DateTime.Now;
                    } 
                    break;
                case Keys.F9:
                    if (中止toolStripButton1.Enabled)
                    {
                        中止toolStripButton1.PerformClick();
                        lastDateTime = DateTime.Now;
                    }
                    break;
                case Keys.F:
                    if (e.Modifiers == Keys.Control)
                    {
                        txt_user.Focus();
                    }
                    break;
            }
        }

        private void frm_Main_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CK_fastPrint_CheckedChanged(object sender, EventArgs e)
        {
            ConfigClass.SetConfigString("Printer","speed", CK_fastPrint.Checked.ToString());
            nFastPrint = CK_fastPrint.Checked;
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            DateTime tmpDt = DateTime.Parse(CurrentDate);
            tmpDt = tmpDt.AddDays(-1);
            txt_Date.Text = tmpDt.ToLongDateString();
            CurrentDate = tmpDt.ToLongDateString();
            FileHelper.timelist = GetPeopleMsg.GetTimeList();
            if (tooldoWork != null)
                tooldoWork.Invoke("Date");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DateTime tmpDt = DateTime.Parse(CurrentDate);
            tmpDt = tmpDt.Date.AddDays(1);
            txt_Date.Text = tmpDt.ToLongDateString();
            CurrentDate = tmpDt.ToLongDateString();
            FileHelper.timelist = GetPeopleMsg.GetTimeList();
            if (tooldoWork != null)
                tooldoWork.Invoke("Date");
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txt_user_Click(null,null);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (UserHelper.isRefresh)
                return;
            TimerGetUserMsg(CurrentPath);
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
                txt_user_Click(null, null);
        }

        private void txt_user_Enter(object sender, EventArgs e)
        {

        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            NumForm.Hide();
        }

        数字键盘 NumForm = new 数字键盘();
        private void txt_user_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_user.Focused)
            {
                if (!NumForm.Visible)
                {
                    NumForm.Show();
                    NumForm.DelNumFormExect = NumFormExectFunc;
                    NumForm.TopMost = true;
                    txt_user.Focus();
                    NumForm.Location = PointToScreen(new Point(Search_panel1.Left, Search_panel1.Bottom)); 
                }   
            }
        }


    }
    public abstract class NewOpenManager1
    {
        public static bool State = false;
        static DateForm frm = null;
        public static void OpenWindow(ref string tDateTime,Point p)
        {
            frm = new DateForm();
            frm.pos = p;
            tDateTime =  frm.GetNewWindowDateTime();
            State = true;
        }
        public static void Close()
        {
            if (frm != null)
            {
                frm.Close();
                frm = null;
                State = false;
            }
        }
    }
}
