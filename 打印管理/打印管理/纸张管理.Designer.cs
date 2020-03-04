namespace 打印管理
{
    partial class 纸张管理
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(纸张管理));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.纸张类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.纸张名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.黑白可用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.彩色可用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.纸张类型,
            this.纸张名称,
            this.黑白可用,
            this.彩色可用});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(487, 220);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // 纸张类型
            // 
            this.纸张类型.HeaderText = "纸张类型";
            this.纸张类型.Name = "纸张类型";
            this.纸张类型.ReadOnly = true;
            this.纸张类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.纸张类型.Width = 150;
            // 
            // 纸张名称
            // 
            this.纸张名称.HeaderText = "纸张名称";
            this.纸张名称.Name = "纸张名称";
            this.纸张名称.Width = 150;
            // 
            // 黑白可用
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.黑白可用.DefaultCellStyle = dataGridViewCellStyle1;
            this.黑白可用.HeaderText = "黑白可用";
            this.黑白可用.Name = "黑白可用";
            this.黑白可用.ReadOnly = true;
            this.黑白可用.Width = 90;
            // 
            // 彩色可用
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.彩色可用.DefaultCellStyle = dataGridViewCellStyle2;
            this.彩色可用.HeaderText = "彩色可用";
            this.彩色可用.Name = "彩色可用";
            this.彩色可用.ReadOnly = true;
            this.彩色可用.Width = 90;
            // 
            // 纸张管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 220);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "纸张管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "纸张管理";
            this.Load += new System.EventHandler(this.纸张管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纸张类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纸张名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 黑白可用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 彩色可用;
    }
}