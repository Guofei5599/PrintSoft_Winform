namespace 打印管理
{
    partial class 价格管理
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(价格管理));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.纸张类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.纸张名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.彩色打印 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.黑白单面打印 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.黑白双面打印 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_活动折扣 = new System.Windows.Forms.TextBox();
            this.txt_附加费用 = new System.Windows.Forms.TextBox();
            this.txt_起步价 = new System.Windows.Forms.TextBox();
            this.txt_配送费 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.纸张类型,
            this.纸张名称,
            this.彩色打印,
            this.黑白单面打印,
            this.黑白双面打印});
            this.dataGridView1.Location = new System.Drawing.Point(1, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(512, 194);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // 纸张类型
            // 
            this.纸张类型.HeaderText = "纸张类型";
            this.纸张类型.Name = "纸张类型";
            this.纸张类型.ReadOnly = true;
            this.纸张类型.Visible = false;
            this.纸张类型.Width = 170;
            // 
            // 纸张名称
            // 
            this.纸张名称.HeaderText = "纸张名称";
            this.纸张名称.Name = "纸张名称";
            this.纸张名称.ReadOnly = true;
            this.纸张名称.Width = 170;
            // 
            // 彩色打印
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.彩色打印.DefaultCellStyle = dataGridViewCellStyle1;
            this.彩色打印.HeaderText = "彩色打印";
            this.彩色打印.Name = "彩色打印";
            this.彩色打印.Width = 90;
            // 
            // 黑白单面打印
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.黑白单面打印.DefaultCellStyle = dataGridViewCellStyle2;
            this.黑白单面打印.HeaderText = "黑白单面打印";
            this.黑白单面打印.Name = "黑白单面打印";
            this.黑白单面打印.Width = 120;
            // 
            // 黑白双面打印
            // 
            this.黑白双面打印.HeaderText = "黑白双面打印";
            this.黑白双面打印.Name = "黑白双面打印";
            this.黑白双面打印.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(171, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "单价设置(单价：元)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(215, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "附加设置";
            // 
            // txt_活动折扣
            // 
            this.txt_活动折扣.Location = new System.Drawing.Point(96, 318);
            this.txt_活动折扣.Name = "txt_活动折扣";
            this.txt_活动折扣.Size = new System.Drawing.Size(116, 23);
            this.txt_活动折扣.TabIndex = 4;
            this.txt_活动折扣.Validating += new System.ComponentModel.CancelEventHandler(this.txt_活动折扣_Validating);
            // 
            // txt_附加费用
            // 
            this.txt_附加费用.Location = new System.Drawing.Point(338, 318);
            this.txt_附加费用.Name = "txt_附加费用";
            this.txt_附加费用.Size = new System.Drawing.Size(116, 23);
            this.txt_附加费用.TabIndex = 5;
            this.txt_附加费用.Validating += new System.ComponentModel.CancelEventHandler(this.txt_附加费用_Validating);
            // 
            // txt_起步价
            // 
            this.txt_起步价.Location = new System.Drawing.Point(96, 350);
            this.txt_起步价.Name = "txt_起步价";
            this.txt_起步价.Size = new System.Drawing.Size(116, 23);
            this.txt_起步价.TabIndex = 6;
            this.txt_起步价.Validating += new System.ComponentModel.CancelEventHandler(this.txt_起步价_Validating);
            // 
            // txt_配送费
            // 
            this.txt_配送费.Location = new System.Drawing.Point(338, 350);
            this.txt_配送费.Name = "txt_配送费";
            this.txt_配送费.Size = new System.Drawing.Size(116, 23);
            this.txt_配送费.TabIndex = 7;
            this.txt_配送费.Validating += new System.ComponentModel.CancelEventHandler(this.txt_配送费_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "活动折扣：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "附加费用：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "起步价：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "配送费：";
            // 
            // 价格管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 405);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_配送费);
            this.Controls.Add(this.txt_起步价);
            this.Controls.Add(this.txt_附加费用);
            this.Controls.Add(this.txt_活动折扣);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "价格管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "价格管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.价格管理_FormClosing);
            this.Load += new System.EventHandler(this.价格管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_活动折扣;
        private System.Windows.Forms.TextBox txt_附加费用;
        private System.Windows.Forms.TextBox txt_起步价;
        private System.Windows.Forms.TextBox txt_配送费;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纸张类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纸张名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 彩色打印;
        private System.Windows.Forms.DataGridViewTextBoxColumn 黑白单面打印;
        private System.Windows.Forms.DataGridViewTextBoxColumn 黑白双面打印;
    }
}