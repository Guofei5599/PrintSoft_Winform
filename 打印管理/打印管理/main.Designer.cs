namespace 打印管理
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewProgressBarColumn1 = new 打印管理.DataGridViewProgressBarColumn();
            this.StateList = new System.Windows.Forms.ImageList(this.components);
            this.payList = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mStateList = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.row_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.用户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件列表 = new 打印管理.DataGridViewProgressBarColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.份数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.版面 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.颜色 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.纸张类型 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.打印机 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.页数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.地点 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.联系方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支付方式 = new System.Windows.Forms.DataGridViewImageColumn();
            this.LoadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.录入时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isManual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.完成时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProgressBarColumn1
            // 
            this.dataGridViewProgressBarColumn1.HeaderText = "文件列表";
            this.dataGridViewProgressBarColumn1.Name = "dataGridViewProgressBarColumn1";
            this.dataGridViewProgressBarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressBarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewProgressBarColumn1.Width = 250;
            // 
            // StateList
            // 
            this.StateList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StateList.ImageStream")));
            this.StateList.TransparentColor = System.Drawing.Color.Transparent;
            this.StateList.Images.SetKeyName(0, "0");
            this.StateList.Images.SetKeyName(1, "1");
            this.StateList.Images.SetKeyName(2, "2");
            this.StateList.Images.SetKeyName(3, "3");
            this.StateList.Images.SetKeyName(4, "4");
            // 
            // payList
            // 
            this.payList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("payList.ImageStream")));
            this.payList.TransparentColor = System.Drawing.Color.Transparent;
            this.payList.Images.SetKeyName(0, "0");
            this.payList.Images.SetKeyName(1, "1");
            this.payList.Images.SetKeyName(2, "2");
            this.payList.Images.SetKeyName(3, "3");
            this.payList.Images.SetKeyName(4, "4");
            this.payList.Images.SetKeyName(5, "5");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mStateList
            // 
            this.mStateList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mStateList.ImageStream")));
            this.mStateList.TransparentColor = System.Drawing.Color.Transparent;
            this.mStateList.Images.SetKeyName(0, "0");
            this.mStateList.Images.SetKeyName(1, "1");
            this.mStateList.Images.SetKeyName(2, "2");
            this.mStateList.Images.SetKeyName(3, "3");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.row_type,
            this.ID,
            this.State,
            this.icon,
            this.用户名,
            this.文件列表,
            this.Size,
            this.份数,
            this.版面,
            this.颜色,
            this.纸张类型,
            this.打印机,
            this.页数,
            this.计价,
            this.时间,
            this.地点,
            this.联系方式,
            this.备注,
            this.支付方式,
            this.LoadTime,
            this.UserID,
            this.录入时间,
            this.isManual,
            this.完成时间,
            this.FullName});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.RowTemplate.DividerHeight = 5;
            this.dataGridView1.RowTemplate.Height = 46;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1372, 680);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Check
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.NullValue = false;
            this.Check.DefaultCellStyle = dataGridViewCellStyle2;
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 40;
            // 
            // row_type
            // 
            this.row_type.HeaderText = "row_type";
            this.row_type.Name = "row_type";
            this.row_type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.row_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.row_type.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.State.Visible = false;
            // 
            // icon
            // 
            this.icon.HeaderText = "";
            this.icon.Name = "icon";
            this.icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.icon.Width = 16;
            // 
            // 用户名
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.用户名.DefaultCellStyle = dataGridViewCellStyle3;
            this.用户名.HeaderText = "用户名";
            this.用户名.Name = "用户名";
            this.用户名.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.用户名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.用户名.Width = 90;
            // 
            // 文件列表
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.文件列表.DefaultCellStyle = dataGridViewCellStyle4;
            this.文件列表.HeaderText = "文件列表";
            this.文件列表.Name = "文件列表";
            this.文件列表.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.文件列表.Width = 250;
            // 
            // Size
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Size.DefaultCellStyle = dataGridViewCellStyle5;
            this.Size.HeaderText = "大小";
            this.Size.Name = "Size";
            this.Size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Size.Width = 60;
            // 
            // 份数
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.份数.DefaultCellStyle = dataGridViewCellStyle6;
            this.份数.HeaderText = "份数";
            this.份数.Name = "份数";
            this.份数.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.份数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.份数.Width = 54;
            // 
            // 版面
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.版面.DefaultCellStyle = dataGridViewCellStyle7;
            this.版面.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.版面.HeaderText = "版面";
            this.版面.Name = "版面";
            this.版面.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.版面.Width = 54;
            // 
            // 颜色
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.颜色.DefaultCellStyle = dataGridViewCellStyle8;
            this.颜色.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.颜色.HeaderText = "颜色";
            this.颜色.Name = "颜色";
            this.颜色.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.颜色.Width = 54;
            // 
            // 纸张类型
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.纸张类型.DefaultCellStyle = dataGridViewCellStyle9;
            this.纸张类型.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.纸张类型.HeaderText = "纸张类型";
            this.纸张类型.Name = "纸张类型";
            this.纸张类型.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.纸张类型.Width = 78;
            // 
            // 打印机
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.打印机.DefaultCellStyle = dataGridViewCellStyle10;
            this.打印机.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.打印机.HeaderText = "打印机";
            this.打印机.Name = "打印机";
            this.打印机.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.打印机.Width = 120;
            // 
            // 页数
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.页数.DefaultCellStyle = dataGridViewCellStyle11;
            this.页数.HeaderText = "页数/P";
            this.页数.Name = "页数";
            this.页数.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.页数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.页数.Width = 60;
            // 
            // 计价
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Red;
            this.计价.DefaultCellStyle = dataGridViewCellStyle12;
            this.计价.HeaderText = "计价/元";
            this.计价.Name = "计价";
            this.计价.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.计价.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.计价.Width = 65;
            // 
            // 时间
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.时间.DefaultCellStyle = dataGridViewCellStyle13;
            this.时间.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.时间.Width = 80;
            // 
            // 地点
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.地点.DefaultCellStyle = dataGridViewCellStyle14;
            this.地点.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.地点.HeaderText = "地点";
            this.地点.MaxDropDownItems = 3;
            this.地点.Name = "地点";
            this.地点.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.地点.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.地点.Width = 120;
            // 
            // 联系方式
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.联系方式.DefaultCellStyle = dataGridViewCellStyle15;
            this.联系方式.HeaderText = "联系方式";
            this.联系方式.Name = "联系方式";
            this.联系方式.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.联系方式.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 备注
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.备注.DefaultCellStyle = dataGridViewCellStyle16;
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.备注.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.备注.Width = 150;
            // 
            // 支付方式
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.NullValue = null;
            this.支付方式.DefaultCellStyle = dataGridViewCellStyle17;
            this.支付方式.HeaderText = "支付方式";
            this.支付方式.Name = "支付方式";
            this.支付方式.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.支付方式.Width = 70;
            // 
            // LoadTime
            // 
            this.LoadTime.HeaderText = "LoadTime";
            this.LoadTime.Name = "LoadTime";
            this.LoadTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoadTime.Visible = false;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserID.Visible = false;
            // 
            // 录入时间
            // 
            this.录入时间.HeaderText = "录入时间";
            this.录入时间.Name = "录入时间";
            this.录入时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.录入时间.Width = 150;
            // 
            // isManual
            // 
            this.isManual.HeaderText = "isManual";
            this.isManual.Name = "isManual";
            this.isManual.Visible = false;
            // 
            // 完成时间
            // 
            this.完成时间.HeaderText = "完成时间";
            this.完成时间.Name = "完成时间";
            this.完成时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.完成时间.Width = 150;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Visible = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 680);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main";
            this.Text = "main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.main_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewProgressBarColumn dataGridViewProgressBarColumn1;
        private System.Windows.Forms.ImageList StateList;
        private System.Windows.Forms.ImageList payList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList mStateList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn row_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewImageColumn icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户名;
        private DataGridViewProgressBarColumn 文件列表;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn 份数;
        private System.Windows.Forms.DataGridViewButtonColumn 版面;
        private System.Windows.Forms.DataGridViewButtonColumn 颜色;
        private System.Windows.Forms.DataGridViewButtonColumn 纸张类型;
        private System.Windows.Forms.DataGridViewButtonColumn 打印机;
        private System.Windows.Forms.DataGridViewTextBoxColumn 页数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计价;
        private System.Windows.Forms.DataGridViewComboBoxColumn 时间;
        private System.Windows.Forms.DataGridViewComboBoxColumn 地点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewImageColumn 支付方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 录入时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn isManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn 完成时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
    }
}