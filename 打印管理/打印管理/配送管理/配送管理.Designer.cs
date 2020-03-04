namespace 打印管理
{
    partial class 配送管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(配送管理));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_time = new System.Windows.Forms.DataGridView();
            this.数值1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数值2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数值3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数值4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_addr = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addr)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_time);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.dgv_addr);
            this.splitContainer1.Size = new System.Drawing.Size(610, 452);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(267, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "配送时间";
            // 
            // dgv_time
            // 
            this.dgv_time.AllowUserToAddRows = false;
            this.dgv_time.AllowUserToDeleteRows = false;
            this.dgv_time.AllowUserToResizeColumns = false;
            this.dgv_time.AllowUserToResizeRows = false;
            this.dgv_time.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_time.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_time.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_time.ColumnHeadersVisible = false;
            this.dgv_time.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.数值1,
            this.数值2,
            this.数值3,
            this.数值4});
            this.dgv_time.Location = new System.Drawing.Point(6, 35);
            this.dgv_time.MultiSelect = false;
            this.dgv_time.Name = "dgv_time";
            this.dgv_time.RowHeadersVisible = false;
            this.dgv_time.RowTemplate.Height = 23;
            this.dgv_time.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_time.Size = new System.Drawing.Size(601, 127);
            this.dgv_time.TabIndex = 0;
            this.dgv_time.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_time_CellClick);
            this.dgv_time.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_time_CellValidating);
            // 
            // 数值1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.数值1.DefaultCellStyle = dataGridViewCellStyle1;
            this.数值1.HeaderText = "数值1";
            this.数值1.Name = "数值1";
            // 
            // 数值2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.数值2.DefaultCellStyle = dataGridViewCellStyle2;
            this.数值2.HeaderText = "数值2";
            this.数值2.Name = "数值2";
            // 
            // 数值3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.数值3.DefaultCellStyle = dataGridViewCellStyle3;
            this.数值3.HeaderText = "数值3";
            this.数值3.Name = "数值3";
            // 
            // 数值4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.数值4.DefaultCellStyle = dataGridViewCellStyle4;
            this.数值4.HeaderText = "数值4";
            this.数值4.Name = "数值4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(267, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "配送地点";
            // 
            // dgv_addr
            // 
            this.dgv_addr.AllowUserToAddRows = false;
            this.dgv_addr.AllowUserToDeleteRows = false;
            this.dgv_addr.AllowUserToResizeColumns = false;
            this.dgv_addr.AllowUserToResizeRows = false;
            this.dgv_addr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_addr.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_addr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addr.ColumnHeadersVisible = false;
            this.dgv_addr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1});
            this.dgv_addr.Location = new System.Drawing.Point(6, 37);
            this.dgv_addr.MultiSelect = false;
            this.dgv_addr.Name = "dgv_addr";
            this.dgv_addr.RowHeadersVisible = false;
            this.dgv_addr.RowTemplate.Height = 23;
            this.dgv_addr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_addr.Size = new System.Drawing.Size(601, 243);
            this.dgv_addr.TabIndex = 1;
            this.dgv_addr.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_addr_CellValidating);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "数值1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "数值2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "数值3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column1
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column1.HeaderText = "数值4";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 配送管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 452);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "配送管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配送管理";
            this.Load += new System.EventHandler(this.配送管理_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_time;
        private System.Windows.Forms.DataGridView dgv_addr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数值1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数值2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数值3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数值4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}