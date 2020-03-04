namespace 打印管理
{
    partial class frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("主界面");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("纸张管理");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("价格管理");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("配送管理");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("机器管理");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("设置", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("用户数据库");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("账单");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("主菜单", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode15,
            treeNode16,
            treeNode17});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.txt_Date = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel_Parent = new System.Windows.Forms.Panel();
            this.CK_fastPrint = new System.Windows.Forms.CheckBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.Search_panel1 = new System.Windows.Forms.Panel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_sub = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.查询 = new System.Windows.Forms.PictureBox();
            this.手动开单toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.新订单toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.本轮订单toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.下轮订单toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.已完成订单toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.WTP提示 = new System.Windows.Forms.ToolStripButton();
            this.刷新toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.开单toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.用户库toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.账单toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.设置toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.开始toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.缩印toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.出票toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.出库toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.删除toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.中止toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewProgressBarColumn1 = new 打印管理.DataGridViewProgressBarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.Search_panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.查询)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Date
            // 
            this.txt_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.txt_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_Date.Location = new System.Drawing.Point(103, 8);
            this.txt_Date.Name = "txt_Date";
            this.txt_Date.ReadOnly = true;
            this.txt_Date.Size = new System.Drawing.Size(186, 19);
            this.txt_Date.TabIndex = 1;
            this.txt_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Date.DoubleClick += new System.EventHandler(this.txt_Date_DoubleClick);
            this.txt_Date.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txt_Date_MouseMove);
            // 
            // txt_path
            // 
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_path.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_path.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_path.Location = new System.Drawing.Point(79, 43);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(236, 14);
            this.txt_path.TabIndex = 2;
            this.txt_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_path.DoubleClick += new System.EventHandler(this.txt_path_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 672);
            this.splitContainer1.SplitterDistance = 139;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode10.Name = "MainFormNode";
            treeNode10.Text = "主界面";
            treeNode11.Name = "纸张管理Node";
            treeNode11.Text = "纸张管理";
            treeNode12.Name = "价格管理Node";
            treeNode12.Text = "价格管理";
            treeNode13.Name = "配送管理Node";
            treeNode13.Text = "配送管理";
            treeNode14.Name = "机器管理Node";
            treeNode14.Text = "机器管理";
            treeNode15.Name = "SettingNode";
            treeNode15.Text = "设置";
            treeNode16.Name = "dbNode";
            treeNode16.Text = "用户数据库";
            treeNode17.Name = "账单Node";
            treeNode17.Text = "账单";
            treeNode18.Name = "rootNode";
            treeNode18.Text = "主菜单";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18});
            this.treeView1.Size = new System.Drawing.Size(137, 98);
            this.treeView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel_Parent);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.CK_fastPrint);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Size = new System.Drawing.Size(1360, 670);
            this.splitContainer2.SplitterDistance = 625;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel_Parent
            // 
            this.panel_Parent.AllowDrop = true;
            this.panel_Parent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Parent.Location = new System.Drawing.Point(0, 0);
            this.panel_Parent.Name = "panel_Parent";
            this.panel_Parent.Size = new System.Drawing.Size(1360, 625);
            this.panel_Parent.TabIndex = 1;
            // 
            // CK_fastPrint
            // 
            this.CK_fastPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CK_fastPrint.AutoSize = true;
            this.CK_fastPrint.Location = new System.Drawing.Point(1240, 14);
            this.CK_fastPrint.Name = "CK_fastPrint";
            this.CK_fastPrint.Size = new System.Drawing.Size(78, 16);
            this.CK_fastPrint.TabIndex = 1;
            this.CK_fastPrint.Text = "FastPrint";
            this.CK_fastPrint.UseVisualStyleBackColor = true;
            this.CK_fastPrint.CheckedChanged += new System.EventHandler(this.CK_fastPrint_CheckedChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(14, 14);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.手动开单toolStripButton1,
            this.toolStripLabel3,
            this.新订单toolStripButton1,
            this.toolStripLabel4,
            this.本轮订单toolStripButton2,
            this.toolStripLabel5,
            this.下轮订单toolStripButton3,
            this.toolStripLabel6,
            this.已完成订单toolStripButton4,
            this.toolStripLabel7,
            this.WTP提示});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1360, 41);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel2.Text = "          ";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel3.Text = "          ";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel4.Text = "          ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel5.Text = "          ";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel6.Text = "          ";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(48, 38);
            this.toolStripLabel7.Text = "          ";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txt_user
            // 
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_user.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(-1, 0);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(180, 24);
            this.txt_user.TabIndex = 0;
            this.txt_user.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_user_MouseClick);
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            this.txt_user.Enter += new System.EventHandler(this.txt_user_Enter);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            this.txt_user.Leave += new System.EventHandler(this.txt_user_Leave);
            // 
            // Search_panel1
            // 
            this.Search_panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Search_panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Search_panel1.Controls.Add(this.查询);
            this.Search_panel1.Controls.Add(this.txt_user);
            this.Search_panel1.Location = new System.Drawing.Point(1109, 24);
            this.Search_panel1.Name = "Search_panel1";
            this.Search_panel1.Size = new System.Drawing.Size(205, 26);
            this.Search_panel1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(250, 64);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 69);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新toolStripButton,
            this.toolStripLabel1,
            this.开单toolStripButton,
            this.用户库toolStripButton,
            this.账单toolStripButton,
            this.设置toolStripButton,
            this.toolStripSeparator1,
            this.开始toolStripButton,
            this.缩印toolStripButton,
            this.出票toolStripButton,
            this.出库toolStripButton,
            this.删除toolStripButton,
            this.toolStripSeparator2,
            this.中止toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1362, 69);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 69);
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.IncludeSubdirectories = true;
            this.fileWatcher.SynchronizingObject = this;
            this.fileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileWatcher_Changed);
            this.fileWatcher.Created += new System.IO.FileSystemEventHandler(this.fileWatcher_Created);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.panel2.Location = new System.Drawing.Point(76, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 25);
            this.panel2.TabIndex = 4;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(290, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(25, 25);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = ">";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_sub
            // 
            this.btn_sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.btn_sub.FlatAppearance.BorderSize = 0;
            this.btn_sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sub.Location = new System.Drawing.Point(76, 6);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(25, 25);
            this.btn_sub.TabIndex = 5;
            this.btn_sub.Text = "<";
            this.btn_sub.UseVisualStyleBackColor = false;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.panel3.Location = new System.Drawing.Point(102, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 25);
            this.panel3.TabIndex = 6;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // 查询
            // 
            this.查询.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.查询.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.查询.Image = ((System.Drawing.Image)(resources.GetObject("查询.Image")));
            this.查询.Location = new System.Drawing.Point(179, 0);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(23, 23);
            this.查询.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.查询.TabIndex = 4;
            this.查询.TabStop = false;
            this.查询.Click += new System.EventHandler(this.txt_user_Click);
            // 
            // 手动开单toolStripButton1
            // 
            this.手动开单toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.手动开单toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.手动开单toolStripButton1.Image = global::打印管理.Properties.Resources.tool人工;
            this.手动开单toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.手动开单toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.手动开单toolStripButton1.Name = "手动开单toolStripButton1";
            this.手动开单toolStripButton1.Size = new System.Drawing.Size(106, 38);
            this.手动开单toolStripButton1.Text = " 手动开单(0)";
            // 
            // 新订单toolStripButton1
            // 
            this.新订单toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.新订单toolStripButton1.Image = global::打印管理.Properties.Resources.tool未执行;
            this.新订单toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.新订单toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新订单toolStripButton1.Name = "新订单toolStripButton1";
            this.新订单toolStripButton1.Size = new System.Drawing.Size(92, 38);
            this.新订单toolStripButton1.Text = " 新订单(0)";
            // 
            // 本轮订单toolStripButton2
            // 
            this.本轮订单toolStripButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.本轮订单toolStripButton2.Image = global::打印管理.Properties.Resources.tool紧急;
            this.本轮订单toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.本轮订单toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.本轮订单toolStripButton2.Name = "本轮订单toolStripButton2";
            this.本轮订单toolStripButton2.Size = new System.Drawing.Size(106, 38);
            this.本轮订单toolStripButton2.Text = " 本轮订单(0)";
            // 
            // 下轮订单toolStripButton3
            // 
            this.下轮订单toolStripButton3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.下轮订单toolStripButton3.Image = global::打印管理.Properties.Resources.tool不急;
            this.下轮订单toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.下轮订单toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.下轮订单toolStripButton3.Name = "下轮订单toolStripButton3";
            this.下轮订单toolStripButton3.Size = new System.Drawing.Size(120, 38);
            this.下轮订单toolStripButton3.Text = " 下一轮订单(0)";
            // 
            // 已完成订单toolStripButton4
            // 
            this.已完成订单toolStripButton4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.已完成订单toolStripButton4.Image = global::打印管理.Properties.Resources.tool已执行;
            this.已完成订单toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.已完成订单toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.已完成订单toolStripButton4.Name = "已完成订单toolStripButton4";
            this.已完成订单toolStripButton4.Size = new System.Drawing.Size(120, 38);
            this.已完成订单toolStripButton4.Text = " 已完成订单(0)";
            // 
            // WTP提示
            // 
            this.WTP提示.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WTP提示.Image = global::打印管理.Properties.Resources.转换;
            this.WTP提示.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WTP提示.Name = "WTP提示";
            this.WTP提示.Size = new System.Drawing.Size(101, 38);
            this.WTP提示.Text = "转换文件(0)";
            // 
            // 刷新toolStripButton
            // 
            this.刷新toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.刷新toolStripButton.Image = global::打印管理.Properties.Resources.刷新;
            this.刷新toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.刷新toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.刷新toolStripButton.Name = "刷新toolStripButton";
            this.刷新toolStripButton.Size = new System.Drawing.Size(64, 66);
            this.刷新toolStripButton.Tag = "1";
            this.刷新toolStripButton.Text = "toolStripButton1";
            this.刷新toolStripButton.ToolTipText = "F12";
            // 
            // 开单toolStripButton
            // 
            this.开单toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.开单toolStripButton.Image = global::打印管理.Properties.Resources.开单;
            this.开单toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.开单toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.开单toolStripButton.Name = "开单toolStripButton";
            this.开单toolStripButton.Size = new System.Drawing.Size(66, 66);
            this.开单toolStripButton.Text = "toolStripButton2";
            this.开单toolStripButton.ToolTipText = "F1";
            // 
            // 用户库toolStripButton
            // 
            this.用户库toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.用户库toolStripButton.Image = global::打印管理.Properties.Resources.用户库;
            this.用户库toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.用户库toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.用户库toolStripButton.Name = "用户库toolStripButton";
            this.用户库toolStripButton.Size = new System.Drawing.Size(66, 66);
            this.用户库toolStripButton.Text = "toolStripButton3";
            this.用户库toolStripButton.ToolTipText = "F2";
            // 
            // 账单toolStripButton
            // 
            this.账单toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.账单toolStripButton.Image = global::打印管理.Properties.Resources.账单;
            this.账单toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.账单toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.账单toolStripButton.Name = "账单toolStripButton";
            this.账单toolStripButton.Size = new System.Drawing.Size(64, 66);
            this.账单toolStripButton.Text = "toolStripButton4";
            this.账单toolStripButton.ToolTipText = "F3";
            // 
            // 设置toolStripButton
            // 
            this.设置toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.设置toolStripButton.Image = global::打印管理.Properties.Resources.设置;
            this.设置toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.设置toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.设置toolStripButton.Name = "设置toolStripButton";
            this.设置toolStripButton.Size = new System.Drawing.Size(66, 66);
            this.设置toolStripButton.Text = "toolStripButton5";
            this.设置toolStripButton.ToolTipText = "F4";
            // 
            // 开始toolStripButton
            // 
            this.开始toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.开始toolStripButton.Image = global::打印管理.Properties.Resources.开始;
            this.开始toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.开始toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.开始toolStripButton.Name = "开始toolStripButton";
            this.开始toolStripButton.Size = new System.Drawing.Size(66, 66);
            this.开始toolStripButton.Tag = "1";
            this.开始toolStripButton.Text = "toolStripButton6";
            this.开始toolStripButton.ToolTipText = "F5";
            // 
            // 缩印toolStripButton
            // 
            this.缩印toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.缩印toolStripButton.Image = global::打印管理.Properties.Resources.缩印1;
            this.缩印toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.缩印toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩印toolStripButton.Name = "缩印toolStripButton";
            this.缩印toolStripButton.Size = new System.Drawing.Size(64, 66);
            this.缩印toolStripButton.Tag = "";
            this.缩印toolStripButton.Text = "toolStripButton6";
            this.缩印toolStripButton.ToolTipText = "F5";
            // 
            // 出票toolStripButton
            // 
            this.出票toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.出票toolStripButton.Image = global::打印管理.Properties.Resources.出票;
            this.出票toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.出票toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.出票toolStripButton.Name = "出票toolStripButton";
            this.出票toolStripButton.Size = new System.Drawing.Size(64, 66);
            this.出票toolStripButton.Text = "toolStripButton7";
            this.出票toolStripButton.ToolTipText = "F6";
            // 
            // 出库toolStripButton
            // 
            this.出库toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.出库toolStripButton.Image = global::打印管理.Properties.Resources.出库;
            this.出库toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.出库toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.出库toolStripButton.Name = "出库toolStripButton";
            this.出库toolStripButton.Size = new System.Drawing.Size(66, 66);
            this.出库toolStripButton.Text = "toolStripButton8";
            this.出库toolStripButton.ToolTipText = "F7";
            // 
            // 删除toolStripButton
            // 
            this.删除toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.删除toolStripButton.Image = global::打印管理.Properties.Resources.删除;
            this.删除toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.删除toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.删除toolStripButton.Name = "删除toolStripButton";
            this.删除toolStripButton.Size = new System.Drawing.Size(64, 66);
            this.删除toolStripButton.Tag = "1";
            this.删除toolStripButton.Text = "toolStripButton9";
            this.删除toolStripButton.ToolTipText = "F8";
            // 
            // 中止toolStripButton1
            // 
            this.中止toolStripButton1.Image = global::打印管理.Properties.Resources.终止;
            this.中止toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.中止toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.中止toolStripButton1.Name = "中止toolStripButton1";
            this.中止toolStripButton1.Size = new System.Drawing.Size(66, 66);
            this.中止toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.中止toolStripButton1.ToolTipText = "F9";
            // 
            // dataGridViewProgressBarColumn1
            // 
            this.dataGridViewProgressBarColumn1.HeaderText = "文件列表";
            this.dataGridViewProgressBarColumn1.Name = "dataGridViewProgressBarColumn1";
            this.dataGridViewProgressBarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressBarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frm_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.txt_Date);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_sub);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Search_panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "印象RPA订单处理系统1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.frm_Main_SizeChanged);
            this.Click += new System.EventHandler(this.frm_Main_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Main_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_Main_KeyPress);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.Search_panel1.ResumeLayout(false);
            this.Search_panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.查询)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Date;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private DataGridViewProgressBarColumn dataGridViewProgressBarColumn1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Panel Search_panel1;
        private System.Windows.Forms.PictureBox 查询;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel_Parent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton 手动开单toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton 刷新toolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton 开单toolStripButton;
        private System.Windows.Forms.ToolStripButton 用户库toolStripButton;
        private System.Windows.Forms.ToolStripButton 账单toolStripButton;
        private System.Windows.Forms.ToolStripButton 设置toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 开始toolStripButton;
        private System.Windows.Forms.ToolStripButton 出票toolStripButton;
        private System.Windows.Forms.ToolStripButton 出库toolStripButton;
        private System.Windows.Forms.ToolStripButton 删除toolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton 新订单toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton 本轮订单toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton 下轮订单toolStripButton3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton 已完成订单toolStripButton4;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripButton WTP提示;
        private System.Windows.Forms.CheckBox CK_fastPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton 中止toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btn_sub;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripButton 缩印toolStripButton;
    }
}

