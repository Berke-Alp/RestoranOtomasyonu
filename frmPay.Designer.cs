namespace RestoranOtomasyonu
{
    partial class frmPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPay));
            this.lblTableName = new System.Windows.Forms.Label();
            this.cbPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAraToplam = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.pbDiscount = new System.Windows.Forms.PictureBox();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiscount)).BeginInit();
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
            this.lblTableName.Size = new System.Drawing.Size(69, 23);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Masa X";
            // 
            // cbPayType
            // 
            this.cbPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPayType.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbPayType.FormattingEnabled = true;
            this.cbPayType.Location = new System.Drawing.Point(445, 162);
            this.cbPayType.Name = "cbPayType";
            this.cbPayType.Size = new System.Drawing.Size(121, 27);
            this.cbPayType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(336, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ödeme Türü";
            // 
            // lvOrders
            // 
            this.lvOrders.BackColor = System.Drawing.SystemColors.Control;
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOrders.Location = new System.Drawing.Point(18, 93);
            this.lvOrders.MultiSelect = false;
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(310, 344);
            this.lvOrders.TabIndex = 32;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ürün Adedi";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fiyat";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ürün Kodu";
            this.columnHeader4.Width = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Siparişler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(336, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Ara Toplam:";
            // 
            // lblAraToplam
            // 
            this.lblAraToplam.AutoSize = true;
            this.lblAraToplam.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAraToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblAraToplam.Location = new System.Drawing.Point(441, 93);
            this.lblAraToplam.Margin = new System.Windows.Forms.Padding(5);
            this.lblAraToplam.Name = "lblAraToplam";
            this.lblAraToplam.Size = new System.Drawing.Size(38, 19);
            this.lblAraToplam.TabIndex = 34;
            this.lblAraToplam.Text = "0 TL";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPay.Location = new System.Drawing.Point(334, 359);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(265, 36);
            this.btnPay.TabIndex = 35;
            this.btnPay.Text = "Ödemeyi Tamamla";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(336, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "İndirim Kodu";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDiscount.Location = new System.Drawing.Point(445, 129);
            this.txtDiscount.MaxLength = 8;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(121, 27);
            this.txtDiscount.TabIndex = 37;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // pbDiscount
            // 
            this.pbDiscount.Image = global::RestoranOtomasyonu.Properties.Resources.Delete_96;
            this.pbDiscount.Location = new System.Drawing.Point(572, 129);
            this.pbDiscount.Name = "pbDiscount";
            this.pbDiscount.Size = new System.Drawing.Size(27, 27);
            this.pbDiscount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDiscount.TabIndex = 38;
            this.pbDiscount.TabStop = false;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblToplamTutar.Location = new System.Drawing.Point(451, 323);
            this.lblToplamTutar.Margin = new System.Windows.Forms.Padding(5);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(38, 19);
            this.lblToplamTutar.TabIndex = 40;
            this.lblToplamTutar.Text = "0 TL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label6.Location = new System.Drawing.Point(336, 323);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 39;
            this.label6.Text = "Toplam Tutar:";
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Firebrick;
            this.btnGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoBack.Location = new System.Drawing.Point(334, 401);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(265, 36);
            this.btnGoBack.TabIndex = 41;
            this.btnGoBack.Text = "Geri Dön";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(612, 455);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblAraToplam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPayType);
            this.Controls.Add(this.lblTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme";
            this.Load += new System.EventHandler(this.frmPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ComboBox cbPayType;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblAraToplam;
        private System.Windows.Forms.Button btnPay;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.PictureBox pbDiscount;
        public System.Windows.Forms.Label lblToplamTutar;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGoBack;
    }
}