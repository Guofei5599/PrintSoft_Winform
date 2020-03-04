namespace 打印管理
{
    partial class 系统设置
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(系统设置));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ShopName = new System.Windows.Forms.TextBox();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comb_Printer = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_Log = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btn机器管理 = new System.Windows.Forms.Button();
            this.btn价格管理 = new System.Windows.Forms.Button();
            this.btn配送管理 = new System.Windows.Forms.Button();
            this.btn纸张管理 = new System.Windows.Forms.Button();
            this.cb_timerConvert = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "小票打印机：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(439, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "店铺名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "二维码：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_ShopName
            // 
            this.txt_ShopName.Location = new System.Drawing.Point(522, 16);
            this.txt_ShopName.Name = "txt_ShopName";
            this.txt_ShopName.Size = new System.Drawing.Size(244, 23);
            this.txt_ShopName.TabIndex = 5;
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Location = new System.Drawing.Point(103, 55);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(265, 23);
            this.txt_Barcode.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 27);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comb_Printer
            // 
            this.comb_Printer.FormattingEnabled = true;
            this.comb_Printer.Location = new System.Drawing.Point(103, 16);
            this.comb_Printer.Name = "comb_Printer";
            this.comb_Printer.Size = new System.Drawing.Size(265, 22);
            this.comb_Printer.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cb_timerConvert);
            this.splitContainer1.Panel1.Controls.Add(this.cb_Log);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.comb_Printer);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Barcode);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ShopName);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn机器管理);
            this.splitContainer1.Panel2.Controls.Add(this.btn价格管理);
            this.splitContainer1.Panel2.Controls.Add(this.btn配送管理);
            this.splitContainer1.Panel2.Controls.Add(this.btn纸张管理);
            this.splitContainer1.Size = new System.Drawing.Size(796, 371);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 9;
            // 
            // cb_Log
            // 
            this.cb_Log.AutoSize = true;
            this.cb_Log.Location = new System.Drawing.Point(26, 99);
            this.cb_Log.Name = "cb_Log";
            this.cb_Log.Size = new System.Drawing.Size(54, 18);
            this.cb_Log.TabIndex = 11;
            this.cb_Log.Text = "日志";
            this.cb_Log.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(425, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "二维码宽度：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(522, 56);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btn机器管理
            // 
            this.btn机器管理.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn机器管理.Location = new System.Drawing.Point(185, 138);
            this.btn机器管理.Name = "btn机器管理";
            this.btn机器管理.Size = new System.Drawing.Size(149, 60);
            this.btn机器管理.TabIndex = 3;
            this.btn机器管理.Text = "机器管理";
            this.btn机器管理.UseVisualStyleBackColor = true;
            this.btn机器管理.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn价格管理
            // 
            this.btn价格管理.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn价格管理.Location = new System.Drawing.Point(422, 41);
            this.btn价格管理.Name = "btn价格管理";
            this.btn价格管理.Size = new System.Drawing.Size(149, 60);
            this.btn价格管理.TabIndex = 2;
            this.btn价格管理.Text = "价格管理";
            this.btn价格管理.UseVisualStyleBackColor = true;
            this.btn价格管理.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn配送管理
            // 
            this.btn配送管理.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn配送管理.Location = new System.Drawing.Point(422, 138);
            this.btn配送管理.Name = "btn配送管理";
            this.btn配送管理.Size = new System.Drawing.Size(149, 60);
            this.btn配送管理.TabIndex = 1;
            this.btn配送管理.Text = "配送管理";
            this.btn配送管理.UseVisualStyleBackColor = true;
            this.btn配送管理.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn纸张管理
            // 
            this.btn纸张管理.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn纸张管理.Location = new System.Drawing.Point(185, 41);
            this.btn纸张管理.Name = "btn纸张管理";
            this.btn纸张管理.Size = new System.Drawing.Size(149, 60);
            this.btn纸张管理.TabIndex = 0;
            this.btn纸张管理.Text = "纸张管理";
            this.btn纸张管理.UseVisualStyleBackColor = true;
            this.btn纸张管理.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb_timerConvert
            // 
            this.cb_timerConvert.AutoSize = true;
            this.cb_timerConvert.Location = new System.Drawing.Point(115, 99);
            this.cb_timerConvert.Name = "cb_timerConvert";
            this.cb_timerConvert.Size = new System.Drawing.Size(82, 18);
            this.cb_timerConvert.TabIndex = 12;
            this.cb_timerConvert.Text = "定时转换";
            this.cb_timerConvert.UseVisualStyleBackColor = true;
            // 
            // 系统设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 371);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "系统设置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.系统设置_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ShopName;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comb_Printer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn机器管理;
        private System.Windows.Forms.Button btn价格管理;
        private System.Windows.Forms.Button btn配送管理;
        private System.Windows.Forms.Button btn纸张管理;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox cb_Log;
        private System.Windows.Forms.CheckBox cb_timerConvert;
    }
}