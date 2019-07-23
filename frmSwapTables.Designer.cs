namespace RestoranOtomasyonu
{
    partial class frmSwapTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSwapTables));
            this.lblTableName = new System.Windows.Forms.Label();
            this.rbDolu = new System.Windows.Forms.RadioButton();
            this.rbBos = new System.Windows.Forms.RadioButton();
            this.lbFirstTable = new System.Windows.Forms.ListBox();
            this.lbSecondTable = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTableName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblTableName.Location = new System.Drawing.Point(14, 14);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(5);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(172, 23);
            this.lblTableName.TabIndex = 2;
            this.lblTableName.Text = "Masa Taşıma İşlemi";
            // 
            // rbDolu
            // 
            this.rbDolu.AutoSize = true;
            this.rbDolu.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbDolu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.rbDolu.Location = new System.Drawing.Point(377, 15);
            this.rbDolu.Name = "rbDolu";
            this.rbDolu.Size = new System.Drawing.Size(184, 23);
            this.rbDolu.TabIndex = 3;
            this.rbDolu.Text = "Dolu masayla değiştir";
            this.rbDolu.UseVisualStyleBackColor = true;
            this.rbDolu.CheckedChanged += new System.EventHandler(this.RadioButtonStateChange);
            // 
            // rbBos
            // 
            this.rbBos.AutoSize = true;
            this.rbBos.Checked = true;
            this.rbBos.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbBos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.rbBos.Location = new System.Drawing.Point(567, 15);
            this.rbBos.Name = "rbBos";
            this.rbBos.Size = new System.Drawing.Size(143, 23);
            this.rbBos.TabIndex = 4;
            this.rbBos.TabStop = true;
            this.rbBos.Text = "Boş masaya taşı";
            this.rbBos.UseVisualStyleBackColor = true;
            this.rbBos.CheckedChanged += new System.EventHandler(this.RadioButtonStateChange);
            // 
            // lbFirstTable
            // 
            this.lbFirstTable.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFirstTable.FormattingEnabled = true;
            this.lbFirstTable.ItemHeight = 19;
            this.lbFirstTable.Location = new System.Drawing.Point(6, 48);
            this.lbFirstTable.Name = "lbFirstTable";
            this.lbFirstTable.Size = new System.Drawing.Size(339, 346);
            this.lbFirstTable.TabIndex = 5;
            this.lbFirstTable.SelectedIndexChanged += new System.EventHandler(this.lbFirstTable_SelectedIndexChanged);
            // 
            // lbSecondTable
            // 
            this.lbSecondTable.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSecondTable.FormattingEnabled = true;
            this.lbSecondTable.ItemHeight = 19;
            this.lbSecondTable.Location = new System.Drawing.Point(351, 48);
            this.lbSecondTable.Name = "lbSecondTable";
            this.lbSecondTable.Size = new System.Drawing.Size(339, 346);
            this.lbSecondTable.TabIndex = 6;
            this.lbSecondTable.SelectedIndexChanged += new System.EventHandler(this.lbSecondTable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(2, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Taşınacak Masa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(347, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Masanın Yeni Yeri";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbFirstTable);
            this.groupBox1.Controls.Add(this.lbSecondTable);
            this.groupBox1.Location = new System.Drawing.Point(14, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 402);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPay.Location = new System.Drawing.Point(230, 455);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(265, 36);
            this.btnPay.TabIndex = 36;
            this.btnPay.Text = "Masayı Taşı";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.EnabledChanged += new System.EventHandler(this.btnSwap_EnabledChanged);
            this.btnPay.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoBack.Location = new System.Drawing.Point(12, 455);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(125, 36);
            this.btnGoBack.TabIndex = 37;
            this.btnGoBack.Text = "Geri Dön";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblWarning.Location = new System.Drawing.Point(503, 464);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(5);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(165, 19);
            this.lblWarning.TabIndex = 9;
            this.lblWarning.Text = "Seçimler aynı olamaz";
            this.lblWarning.Visible = false;
            // 
            // frmSwapTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(724, 500);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbBos);
            this.Controls.Add(this.rbDolu);
            this.Controls.Add(this.lblTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSwapTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa Taşıma İşlemi";
            this.Load += new System.EventHandler(this.frmSwapTables_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.RadioButton rbDolu;
        private System.Windows.Forms.RadioButton rbBos;
        private System.Windows.Forms.ListBox lbFirstTable;
        private System.Windows.Forms.ListBox lbSecondTable;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnGoBack;
        public System.Windows.Forms.Label lblWarning;
    }
}