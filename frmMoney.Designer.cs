namespace RestoranOtomasyonu
{
    partial class frmMoney
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoney));
            this.btnGoBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDoFilter = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nupMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nupMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPersonel = new System.Windows.Forms.ComboBox();
            this.cbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTumKayitlar = new System.Windows.Forms.CheckBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnGoBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnGoBack.ForeColor = System.Drawing.Color.Black;
            this.btnGoBack.Location = new System.Drawing.Point(18, 458);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(106, 28);
            this.btnGoBack.TabIndex = 15;
            this.btnGoBack.Text = "Ana Menü";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Hesap Hareketleri";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column9,
            this.Column10,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(18, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(713, 352);
            this.dataGridView1.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "HesapKodu";
            this.Column1.HeaderText = "HesapKodu";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PersonelKodu";
            this.Column2.HeaderText = "PersonelKodu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OdemeTuruKodu";
            this.Column3.HeaderText = "OdemeTuruKodu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "pas";
            this.Column9.HeaderText = "Personel";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "OdemeTuru";
            this.Column10.HeaderText = "Ödeme Türü";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "AraToplam";
            this.Column4.HeaderText = "Ara Toplam";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "KdvTutari";
            this.Column5.HeaderText = "KDV Tutarı";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Indirim";
            this.Column6.HeaderText = "İndirim Tutarı";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ToplamTutar";
            this.Column7.HeaderText = "Toplam Tutar";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Tarih";
            this.Column8.HeaderText = "Tarih";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDoFilter);
            this.groupBox1.Controls.Add(this.btnResetFilters);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nupMax);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nupMin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbPersonel);
            this.groupBox1.Controls.Add(this.cbOdemeTuru);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox1.Location = new System.Drawing.Point(737, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 241);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtreleme";
            // 
            // btnDoFilter
            // 
            this.btnDoFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnDoFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoFilter.FlatAppearance.BorderSize = 0;
            this.btnDoFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnDoFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnDoFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoFilter.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnDoFilter.ForeColor = System.Drawing.Color.Black;
            this.btnDoFilter.Location = new System.Drawing.Point(12, 164);
            this.btnDoFilter.Margin = new System.Windows.Forms.Padding(5);
            this.btnDoFilter.Name = "btnDoFilter";
            this.btnDoFilter.Size = new System.Drawing.Size(229, 28);
            this.btnDoFilter.TabIndex = 61;
            this.btnDoFilter.Text = "Filtrele";
            this.btnDoFilter.UseVisualStyleBackColor = false;
            this.btnDoFilter.Click += new System.EventHandler(this.btnDoFilter_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnResetFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilters.FlatAppearance.BorderSize = 0;
            this.btnResetFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnResetFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnResetFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilters.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnResetFilters.ForeColor = System.Drawing.Color.Black;
            this.btnResetFilters.Location = new System.Drawing.Point(12, 202);
            this.btnResetFilters.Margin = new System.Windows.Forms.Padding(5);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(229, 28);
            this.btnResetFilters.TabIndex = 43;
            this.btnResetFilters.Text = "Filtreleri Sıfırla";
            this.btnResetFilters.UseVisualStyleBackColor = false;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 19);
            this.label7.TabIndex = 59;
            this.label7.Text = "TL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(8, 131);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 19);
            this.label8.TabIndex = 58;
            this.label8.Text = "Max. Tutar";
            // 
            // nupMax
            // 
            this.nupMax.Location = new System.Drawing.Point(120, 129);
            this.nupMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupMax.Name = "nupMax";
            this.nupMax.Size = new System.Drawing.Size(89, 27);
            this.nupMax.TabIndex = 57;
            this.nupMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupMax.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "TL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(8, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 55;
            this.label4.Text = "Min. Tutar";
            // 
            // nupMin
            // 
            this.nupMin.Location = new System.Drawing.Point(120, 96);
            this.nupMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupMin.Name = "nupMin";
            this.nupMin.Size = new System.Drawing.Size(89, 27);
            this.nupMin.TabIndex = 54;
            this.nupMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 52;
            this.label3.Text = "Personel";
            // 
            // cbPersonel
            // 
            this.cbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonel.FormattingEnabled = true;
            this.cbPersonel.Location = new System.Drawing.Point(120, 63);
            this.cbPersonel.Name = "cbPersonel";
            this.cbPersonel.Size = new System.Drawing.Size(121, 27);
            this.cbPersonel.TabIndex = 51;
            // 
            // cbOdemeTuru
            // 
            this.cbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdemeTuru.FormattingEnabled = true;
            this.cbOdemeTuru.Location = new System.Drawing.Point(120, 30);
            this.cbOdemeTuru.Name = "cbOdemeTuru";
            this.cbOdemeTuru.Size = new System.Drawing.Size(121, 27);
            this.cbOdemeTuru.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label6.Location = new System.Drawing.Point(8, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 19);
            this.label6.TabIndex = 47;
            this.label6.Text = "Ödeme Türü";
            // 
            // cbTumKayitlar
            // 
            this.cbTumKayitlar.AutoSize = true;
            this.cbTumKayitlar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTumKayitlar.ForeColor = System.Drawing.Color.White;
            this.cbTumKayitlar.Location = new System.Drawing.Point(749, 354);
            this.cbTumKayitlar.Name = "cbTumKayitlar";
            this.cbTumKayitlar.Size = new System.Drawing.Size(170, 23);
            this.cbTumKayitlar.TabIndex = 53;
            this.cbTumKayitlar.Text = "Tüm kayıtları göster";
            this.cbTumKayitlar.UseVisualStyleBackColor = true;
            this.cbTumKayitlar.CheckedChanged += new System.EventHandler(this.cbTumKayitlar_CheckedChanged);
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnShowReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowReport.FlatAppearance.BorderSize = 0;
            this.btnShowReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnShowReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReport.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnShowReport.ForeColor = System.Drawing.Color.Black;
            this.btnShowReport.Location = new System.Drawing.Point(480, 458);
            this.btnShowReport.Margin = new System.Windows.Forms.Padding(5);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(251, 28);
            this.btnShowReport.TabIndex = 42;
            this.btnShowReport.Text = "Raporu Görüntüle";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // frmMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.cbTumKayitlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesap Hareketleri";
            this.Load += new System.EventHandler(this.frmMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoBack;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOdemeTuru;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPersonel;
        private System.Windows.Forms.CheckBox cbTumKayitlar;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupMin;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nupMax;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnDoFilter;
    }
}