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
    public partial class frmProducts : Form
    {
        cDataController Controller = new cDataController();
        BindingSource bs = new BindingSource();

        bool YeniKayit = false;
        int KayitliPozisyon = 1;

        public frmProducts()
        {
            InitializeComponent();
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            Fields(false);
            Controller.Select_Urun();
            Controller.Select_Kategori();
            bs.DataSource = Controller.ds.Tables["Ürünler"];
            dataGridView1.DataSource = bs;

            dataGridView1.Columns["UrunKodu"].Visible = false;
            dataGridView1.Columns["KategoriKodu"].Visible = false;

            cbCategory.DataSource = Controller.ds.Tables["Kategoriler"];
            cbCategory.ValueMember = "KategoriKodu";
            cbCategory.DisplayMember = "Kategori Adı";

            lblUrunKodu.DataBindings.Add("Text", bs, "UrunKodu");
            cbCategory.DataBindings.Add("SelectedValue", bs, "KategoriKodu");
            txtProName.DataBindings.Add("Text", bs, "Ürün Adı");
            txtProDesc.DataBindings.Add("Text", bs, "Açıklama");
            nupPrice.DataBindings.Add("Value", bs, "Fiyat");
        }

        void Fields(bool State)
        {
            txtProName.ReadOnly = !State;
            txtProDesc.ReadOnly = !State;
            nupPrice.ReadOnly = !State;
            nupPrice.Enabled = State;
            cbCategory.Enabled = State;
            btnProSave.Enabled = State;
            btnProCancel.Enabled = State;
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
            txtProName.Text = "";
            txtProDesc.Text = "";
            nupPrice.Value = 0;
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
            DialogResult dR = MessageBox.Show("Bu ürünü gerçekten silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Controller.Delete_Urun(int.Parse(lblUrunKodu.Text));
                MessageBox.Show("Seçilmiş olan ürün silindi!", "Bilgilendirme");
                Controller.Select_Urun();
            }
        } // Sil butonu

        private void btnProSave_Click(object sender, EventArgs e)
        {
            int KategoriKodu = int.Parse(cbCategory.SelectedValue.ToString());
            int UrunKodu = int.Parse(lblUrunKodu.Text);
            if (txtProName.Text.Trim() == "" || txtProDesc.Text.Trim() == "")
            {
                MessageBox.Show("Alanlar boş olamaz!", "Hata");
            }
            else
            {
                if (YeniKayit)
                {
                    Controller.Insert_Urun(KategoriKodu, txtProName.Text, txtProDesc.Text, nupPrice.Value);
                    MessageBox.Show("Ürün başarıyla eklendi.", "Bilgilendirme");
                    Controller.Select_Urun();
                    bs.Position = bs.List.Count;
                }
                else
                {
                    Controller.Update_Urun(KategoriKodu, txtProName.Text, txtProDesc.Text, nupPrice.Value, UrunKodu);
                    MessageBox.Show("Ürün başarıyla düzenlendi.", "Bilgilendirme");
                    Controller.Select_Urun();
                    bs.Position = KayitliPozisyon;
                }
                Fields(false);
            }
        } // Kaydet butonu
        private void btnProCancel_Click(object sender, EventArgs e)
        {
            Fields(false);
            Controller.Select_Urun();
            bs.Position = KayitliPozisyon;
        } // İptal butonu

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        } // Ana Menü butonu
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Controller.Select_Urun(txtSearch.Text);
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
