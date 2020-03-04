namespace 打印管理
{
    partial class 用户数据库
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(用户数据库));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.用户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.上次地点 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消费总金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.上次下单时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户属性备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.用户名,
            this.上次地点,
            this.电话,
            this.消费总金额,
            this.上次下单时间,
            this.用户属性备注});
            this.dataGridView1.Location = new System.Drawing.Point(2, 96);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(949, 461);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(588, 51);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(87, 36);
            this.btn_Export.TabIndex = 6;
            this.btn_Export.Text = "导出Excel";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(394, 51);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(87, 36);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "删 除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Btn_New
            // 
            this.Btn_New.Location = new System.Drawing.Point(171, 51);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(87, 36);
            this.Btn_New.TabIndex = 4;
            this.Btn_New.Text = "新 增";
            this.Btn_New.UseVisualStyleBackColor = true;
            this.Btn_New.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "电话:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "备注:";
            // 
            // txt_User
            // 
            this.txt_User.Location = new System.Drawing.Point(115, 19);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(156, 23);
            this.txt_User.TabIndex = 10;
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(346, 19);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(156, 23);
            this.txt_Phone.TabIndex = 11;
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(577, 19);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(196, 23);
            this.txt_Note.TabIndex = 12;
            // 
            // 用户名
            // 
            this.用户名.HeaderText = "用户名";
            this.用户名.MinimumWidth = 150;
            this.用户名.Name = "用户名";
            this.用户名.Width = 150;
            // 
            // 上次地点
            // 
            this.上次地点.HeaderText = "上次地点";
            this.上次地点.MinimumWidth = 88;
            this.上次地点.Name = "上次地点";
            this.上次地点.ReadOnly = true;
            this.上次地点.Width = 88;
            // 
            // 电话
            // 
            this.电话.HeaderText = "电话";
            this.电话.MinimumWidth = 60;
            this.电话.Name = "电话";
            this.电话.Width = 60;
            // 
            // 消费总金额
            // 
            this.消费总金额.HeaderText = "消费总金额";
            this.消费总金额.MinimumWidth = 102;
            this.消费总金额.Name = "消费总金额";
            this.消费总金额.ReadOnly = true;
            this.消费总金额.Width = 102;
            // 
            // 上次下单时间
            // 
            this.上次下单时间.HeaderText = "上次下单时间";
            this.上次下单时间.MinimumWidth = 130;
            this.上次下单时间.Name = "上次下单时间";
            this.上次下单时间.ReadOnly = true;
            this.上次下单时间.Width = 130;
            // 
            // 用户属性备注
            // 
            this.用户属性备注.HeaderText = "用户属性备注";
            this.用户属性备注.MinimumWidth = 360;
            this.用户属性备注.Name = "用户属性备注";
            this.用户属性备注.Width = 360;
            // 
            // 用户数据库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 558);
            this.Controls.Add(this.txt_Note);
            this.Controls.Add(this.txt_Phone);
            this.Controls.Add(this.txt_User);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.Btn_New);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "用户数据库";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户数据库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.用户数据库_FormClosing);
            this.Load += new System.EventHandler(this.用户数据库_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.TextBox txt_Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 上次地点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消费总金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 上次下单时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户属性备注;
    }
}