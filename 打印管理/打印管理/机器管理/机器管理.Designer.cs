namespace 打印管理
{
    partial class 机器管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(机器管理));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.打印机 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.黑白可用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.彩色可用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_添加 = new System.Windows.Forms.Button();
            this.btn_删除 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.打印机,
            this.黑白可用,
            this.彩色可用});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(458, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // 打印机
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.打印机.DefaultCellStyle = dataGridViewCellStyle1;
            this.打印机.HeaderText = "打印机";
            this.打印机.Name = "打印机";
            this.打印机.ReadOnly = true;
            this.打印机.Width = 260;
            // 
            // 黑白可用
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.黑白可用.DefaultCellStyle = dataGridViewCellStyle2;
            this.黑白可用.HeaderText = "黑白可用";
            this.黑白可用.Name = "黑白可用";
            this.黑白可用.ReadOnly = true;
            this.黑白可用.Width = 90;
            // 
            // 彩色可用
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.彩色可用.DefaultCellStyle = dataGridViewCellStyle3;
            this.彩色可用.HeaderText = "彩色可用";
            this.彩色可用.Name = "彩色可用";
            this.彩色可用.ReadOnly = true;
            this.彩色可用.Width = 90;
            // 
            // btn_添加
            // 
            this.btn_添加.Location = new System.Drawing.Point(76, 222);
            this.btn_添加.Name = "btn_添加";
            this.btn_添加.Size = new System.Drawing.Size(87, 27);
            this.btn_添加.TabIndex = 0;
            this.btn_添加.Text = "添  加";
            this.btn_添加.UseVisualStyleBackColor = true;
            this.btn_添加.Click += new System.EventHandler(this.btn_添加_Click);
            // 
            // btn_删除
            // 
            this.btn_删除.Location = new System.Drawing.Point(259, 222);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(87, 27);
            this.btn_删除.TabIndex = 2;
            this.btn_删除.Text = "删  除";
            this.btn_删除.UseVisualStyleBackColor = true;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // 机器管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 258);
            this.Controls.Add(this.btn_删除);
            this.Controls.Add(this.btn_添加);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "机器管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "机器管理";
            this.Load += new System.EventHandler(this.机器管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_添加;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.DataGridViewTextBoxColumn 打印机;
        private System.Windows.Forms.DataGridViewTextBoxColumn 黑白可用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 彩色可用;
    }
}