namespace 打印管理
{
    partial class TipForm
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
            this.出货时间 = new System.Windows.Forms.Label();
            this.订单 = new System.Windows.Forms.Label();
            this.设备 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.文件个数 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.配送时间 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.备注 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // 出货时间
            // 
            this.出货时间.AutoSize = true;
            this.出货时间.ForeColor = System.Drawing.Color.Red;
            this.出货时间.Location = new System.Drawing.Point(14, 50);
            this.出货时间.Name = "出货时间";
            this.出货时间.Size = new System.Drawing.Size(63, 14);
            this.出货时间.TabIndex = 0;
            this.出货时间.Text = "出货时间";
            // 
            // 订单
            // 
            this.订单.AutoSize = true;
            this.订单.Location = new System.Drawing.Point(58, 82);
            this.订单.Name = "订单";
            this.订单.Size = new System.Drawing.Size(0, 14);
            this.订单.TabIndex = 1;
            // 
            // 设备
            // 
            this.设备.AutoSize = true;
            this.设备.Location = new System.Drawing.Point(58, 121);
            this.设备.Name = "设备";
            this.设备.Size = new System.Drawing.Size(0, 14);
            this.设备.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "设备：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "订单：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件个数：";
            // 
            // 文件个数
            // 
            this.文件个数.AutoSize = true;
            this.文件个数.Location = new System.Drawing.Point(83, 158);
            this.文件个数.Name = "文件个数";
            this.文件个数.Size = new System.Drawing.Size(0, 14);
            this.文件个数.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "配送时间：";
            // 
            // 配送时间
            // 
            this.配送时间.AutoSize = true;
            this.配送时间.Location = new System.Drawing.Point(83, 194);
            this.配送时间.Name = "配送时间";
            this.配送时间.Size = new System.Drawing.Size(0, 14);
            this.配送时间.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "备注：";
            // 
            // 备注
            // 
            this.备注.AutoSize = true;
            this.备注.Location = new System.Drawing.Point(56, 225);
            this.备注.Name = "备注";
            this.备注.Size = new System.Drawing.Size(0, 14);
            this.备注.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.出货时间);
            this.panel1.Controls.Add(this.备注);
            this.panel1.Controls.Add(this.订单);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.设备);
            this.panel1.Controls.Add(this.配送时间);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.文件个数);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 261);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 29);
            this.panel2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(267, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "出货提醒";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 261);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TipForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TipForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label 出货时间;
        private System.Windows.Forms.Label 订单;
        private System.Windows.Forms.Label 设备;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label 文件个数;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label 配送时间;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label 备注;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
    }
}