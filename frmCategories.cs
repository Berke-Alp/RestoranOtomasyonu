using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranOtomasyonu
{
    public partial class frmCategories : Form
    {
        cDataController Controller = new cDataController();
        BindingSource bs = new BindingSource();

        bool YeniKayit = false;
        int KayitliPozisyon = 1;

        public frmCategories()
        {
            InitializeComponent();
        }
        private void frmCatPro_Load(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            btnCatSave.Enabled = false;
            btnCatCancel.Enabled = false;
            Fields(false);

            Controller.Select_Kategori();
            bs.DataSource = Controller.ds.Tables["Kategoriler"];

            dataGridView1.DataSource = bs;
            dataGridView1.Columns["KategoriKodu"].Visible = false;

            lblKategoriKodu.DataBindings.Add("Text",bs,"KategoriKodu");
            txtCatName.DataBindings.Add("Text", bs, "Kategori Adı");
            txtCatDesc.DataBindings.Add("Text", bs, "Açıklama");
        } // Load fonksiyonu

        void Fields(bool State)
        {
            txtCatName.ReadOnly = !State;
            txtCatDesc.ReadOnly = !State;
            btnCatCancel.Enabled = State;
            btnCatSave.Enabled = State;
            btnNew.Enabled = !State;
            btnEdit.Enabled = !State;
            btnDelete.Enabled = !State;
        }

        void DisabledColorChange(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) btn.BackColor = Color.FromArgb(0, 173, 181);
            else btn.BackColor = Color.FromArgb(2, 82, 86);
        }
        

        #region Butonların Fonksiyonları
        private void btnNew_Click(object sender, EventArgs e)
        {
            Fields(true);
            YeniKayit = true;
            txtCatName.Text = "";
            txtCatDesc.Text = "";
        } // Yeni butonu
        private void btnEdit_Click(object sender, EventArgs e)
        {
            KayitliPozisyon = bs.Position;
            Fields(true);
            YeniKayit = false;
        } // Düzenle butonu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            DialogResult dR = MessageBox.Show("Bu kategoriyi gerçekten silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Controller.Delete_Kategori(int.Parse(lblKategoriKodu.Text));
                MessageBox.Show("Seçilmiş olan kategori silindi!", "Bilgilendirme");
                Controller.Select_Kategori();
            }
        } // Sil butonu

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            Fields(false);
            Controller.Select_Kategori();
            bs.Position = KayitliPozisyon;
        } // İptal butonu
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            if (txtCatName.Text.Trim() == "")
            {
                MessageBox.Show("Kategori adı boş olamaz!", "Hata");
            }
            else
            {
                if (YeniKayit)
                {
                    Controller.Insert_Kategori(txtCatName.Text, txtCatDesc.Text);
                    MessageBox.Show("Kategori başarıyla eklendi.", "Bilgilendirme");
                    Controller.Select_Kategori();
                    bs.Position = bs.List.Count;
                }
                else
                {
                    int KategoriKodu = int.Parse(lblKategoriKodu.Text);
                    Controller.Update_Kategori(txtCatName.Text, txtCatDesc.Text, KategoriKodu);
                    MessageBox.Show("Kategori başarıyla düzenlendi.", "Bilgilendirme");
                    Controller.Select_Kategori();
                    bs.Position = KayitliPozisyon;
                }
                Fields(false);
            }
        } // Kaydet butonu

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        } // Ana Menü butonu
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Controller.Select_Kategori(txtSearch.Text);
            if (dataGridView1.Rows.Count == 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        } 
    }
}