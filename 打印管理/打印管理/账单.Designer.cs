namespace 打印管理
{
    partial class 账单
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(账单));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.当日总金额 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.用户ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.录单时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出货时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消费金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支付方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.小票预览 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.用户ID,
            this.用户名,
            this.录单时间,
            this.出货时间,
            this.配送时间,
            this.消费金额,
            this.支付方式,
            this.小票预览});
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(844, 604);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 622);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 23);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "账单时间:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(880, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "当日总金额:";
            // 
            // 当日总金额
            // 
            this.当日总金额.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.当日总金额.AutoSize = true;
            this.当日总金额.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.当日总金额.ForeColor = System.Drawing.Color.Red;
            this.当日总金额.Location = new System.Drawing.Point(987, 630);
            this.当日总金额.Name = "当日总金额";
            this.当日总金额.Size = new System.Drawing.Size(38, 14);
            this.当日总金额.TabIndex = 4;
            this.当日总金额.Text = "0 元";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(461, 615);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "导出EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Location = new System.Drawing.Point(266, 621);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(147, 23);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.DropDown += new System.EventHandler(this.dateTimePicker2_DropDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 626);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "--";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 592);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(852, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 604);
            this.panel1.TabIndex = 9;
            // 
            // 用户ID
            // 
            this.用户ID.HeaderText = "用户ID";
            this.用户ID.Name = "用户ID";
            this.用户ID.ReadOnly = true;
            this.用户ID.Visible = false;
            this.用户ID.Width = 74;
            // 
            // 用户名
            // 
            this.用户名.HeaderText = "用户名";
            this.用户名.Name = "用户名";
            this.用户名.ReadOnly = true;
            this.用户名.Width = 150;
            // 
            // 录单时间
            // 
            this.录单时间.HeaderText = "录单时间";
            this.录单时间.Name = "录单时间";
            this.录单时间.ReadOnly = true;
            this.录单时间.Width = 140;
            // 
            // 出货时间
            // 
            this.出货时间.HeaderText = "出货时间";
            this.出货时间.Name = "出货时间";
            this.出货时间.ReadOnly = true;
            this.出货时间.Width = 140;
            // 
            // 配送时间
            // 
            this.配送时间.HeaderText = "配送时间";
            this.配送时间.Name = "配送时间";
            this.配送时间.ReadOnly = true;
            this.配送时间.Width = 88;
            // 
            // 消费金额
            // 
            this.消费金额.HeaderText = "消费金额";
            this.消费金额.Name = "消费金额";
            this.消费金额.ReadOnly = true;
            this.消费金额.Width = 88;
            // 
            // 支付方式
            // 
            this.支付方式.HeaderText = "支付方式";
            this.支付方式.Name = "支付方式";
            this.支付方式.ReadOnly = true;
            this.支付方式.Width = 88;
            // 
            // 小票预览
            // 
            this.小票预览.HeaderText = "小票预览";
            this.小票预览.Name = "小票预览";
            this.小票预览.ReadOnly = true;
            this.小票预览.Width = 88;
            // 
            // 账单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 659);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.当日总金额);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "账单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "账单";
            this.Load += new System.EventHandler(this.账单_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label 当日总金额;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 录单时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出货时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消费金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支付方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 小票预览;
    }
}