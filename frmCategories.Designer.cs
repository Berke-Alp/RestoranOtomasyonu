namespace RestoranOtomasyonu
{
    partial class frmCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategories));
            this.btnGoBack = new System.Windows.Forms.Button();
            this.lblKategoriKodu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCatSave = new System.Windows.Forms.Button();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.btnCatCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.gbActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbCategory.SuspendLayout();
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
            this.btnGoBack.TabIndex = 9;
            this.btnGoBack.Text = "Ana Menü";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // lblKategoriKodu
            // 
            this.lblKategoriKodu.AutoSize = true;
            this.lblKategoriKodu.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKategoriKodu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.lblKategoriKodu.Location = new System.Drawing.Point(154, 14);
            this.lblKategoriKodu.Margin = new System.Windows.Forms.Padding(5);
            this.lblKategoriKodu.Name = "lblKategoriKodu";
            this.lblKategoriKodu.Size = new System.Drawing.Size(20, 23);
            this.lblKategoriKodu.TabIndex = 61;
            this.lblKategoriKodu.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(416, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.TabIndex = 59;
            this.label8.Text = "Kategori Ara";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSearch.Location = new System.Drawing.Point(524, 84);
            this.txtSearch.MaxLength = 25;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(208, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnDelete);
            this.gbActions.Controls.Add(this.btnNew);
            this.gbActions.Controls.Add(this.btnEdit);
            this.gbActions.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbActions.ForeColor = System.Drawing.Color.White;
            this.gbActions.Location = new System.Drawing.Point(738, 14);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(250, 146);
            this.gbActions.TabIndex = 60;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "İşlemler";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(12, 106);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(230, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.DisabledColorChange);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Location = new System.Drawing.Point(12, 30);
            this.btnNew.Margin = new System.Windows.Forms.Padding(5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(230, 28);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.EnabledChanged += new System.EventHandler(this.DisabledColorChange);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(12, 68);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(230, 28);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.EnabledChanged += new System.EventHandler(this.DisabledColorChange);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(714, 330);
            this.dataGridView1.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 23);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "Kategoriler";
            // 
            // btnCatSave
            // 
            this.btnCatSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnCatSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatSave.FlatAppearance.BorderSize = 0;
            this.btnCatSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnCatSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnCatSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatSave.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnCatSave.ForeColor = System.Drawing.Color.Black;
            this.btnCatSave.Location = new System.Drawing.Point(120, 98);
            this.btnCatSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnCatSave.Name = "btnCatSave";
            this.btnCatSave.Size = new System.Drawing.Size(122, 28);
            this.btnCatSave.TabIndex = 7;
            this.btnCatSave.Text = "Kaydet";
            this.btnCatSave.UseVisualStyleBackColor = false;
            this.btnCatSave.EnabledChanged += new System.EventHandler(this.DisabledColorChange);
            this.btnCatSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCatName
            // 
            this.txtCatName.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCatName.Location = new System.Drawing.Point(120, 30);
            this.txtCatName.MaxLength = 25;
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(122, 27);
            this.txtCatName.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label10.Location = new System.Drawing.Point(7, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 19);
            this.label10.TabIndex = 47;
            this.label10.Text = "Kategori Adı";
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCatDesc.Location = new System.Drawing.Point(120, 63);
            this.txtCatDesc.MaxLength = 100;
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(122, 27);
            this.txtCatDesc.TabIndex = 6;
            // 
            // btnCatCancel
            // 
            this.btnCatCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.btnCatCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatCancel.FlatAppearance.BorderSize = 0;
            this.btnCatCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(160)))));
            this.btnCatCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.btnCatCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatCancel.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnCatCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCatCancel.Location = new System.Drawing.Point(11, 98);
            this.btnCatCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCatCancel.Name = "btnCatCancel";
            this.btnCatCancel.Size = new System.Drawing.Size(94, 28);
            this.btnCatCancel.TabIndex = 8;
            this.btnCatCancel.Text = "İptal";
            this.btnCatCancel.UseVisualStyleBackColor = false;
            this.btnCatCancel.EnabledChanged += new System.EventHandler(this.DisabledColorChange);
            this.btnCatCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label9.Location = new System.Drawing.Point(8, 66);
            this.label9.Margin = new System.Windows.Forms.Padding(5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 49;
            this.label9.Text = "Açıklama";
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.label9);
            this.gbCategory.Controls.Add(this.btnCatCancel);
            this.gbCategory.Controls.Add(this.txtCatDesc);
            this.gbCategory.Controls.Add(this.label10);
            this.gbCategory.Controls.Add(this.txtCatName);
            this.gbCategory.Controls.Add(this.btnCatSave);
            this.gbCategory.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.gbCategory.Location = new System.Drawing.Point(738, 166);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(250, 140);
            this.gbCategory.TabIndex = 59;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Kategori";
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblKategoriKodu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategoriler";
            this.Load += new System.EventHandler(this.frmCatPro_Load);
            this.gbActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoBack;
        public System.Windows.Forms.Label lblKategoriKodu;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCatSave;
        private System.Windows.Forms.TextBox txtCatName;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.Button btnCatCancel;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbCategory;
    }
}