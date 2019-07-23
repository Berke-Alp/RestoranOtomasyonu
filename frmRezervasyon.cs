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
    public partial class frmRezervasyon : Form
    {
        cDataController Controller = new cDataController();
        BindingSource bs = new BindingSource();

        public int PersonelKodu;
        public string PersonelAdiSoyadi;
        public string MusteriAdiSoyadi, MusteriTelefonu;

        bool YeniKayit = false;
        int KayitliPozisyon = 1;

        public frmRezervasyon()
        {
            InitializeComponent();
        }

        void DateControl()
        {
            int Yil = DateTime.Now.Year;
            int Ay = DateTime.Now.Month;
            int Gun = DateTime.Now.Day;
            int Saat = DateTime.Now.Hour + 2;
            dtpStart.MinDate = new DateTime(Yil, Ay, Gun, Saat, 0, 0);
            dtpEnd.MinDate = new DateTime(Yil, Ay, Gun, Saat + 1, 0, 0);
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            Fields(false);
            btnChoose.Enabled = false;
            Controller.Select_Rezervasyon();
            Controller.Select_Masa();
            bs.DataSource = Controller.ds.Tables["Rezervasyonlar"];
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["MasaKodu"].Visible = false;
            dataGridView1.Columns["RezervasyonKodu"].Visible = false;

            DateControl();

            cbTable.DataSource = Controller.ds.Tables["Masalar"];
            cbTable.ValueMember = "MasaKodu";
            cbTable.DisplayMember = "Masa Numarası";

            lblRezervasyonKodu.DataBindings.Add("Text", bs, "RezervasyonKodu");
            txtNameSurname.DataBindings.Add("Text", bs, "İsim Soyisim");
            txtPhone.DataBindings.Add("Text", bs, "Telefon");
            cbTable.DataBindings.Add("SelectedValue", bs, "MasaKodu");
            dtpStart.DataBindings.Add("Value", bs, "Başlangıç");
            dtpEnd.DataBindings.Add("Value", bs, "Bitiş");
        }

        void DisabledColorChange(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) btn.BackColor = Color.FromArgb(0, 173, 181);
            else btn.BackColor = Color.FromArgb(2, 82, 86);
        }

        public void MusteriSec()
        {
            MusteriAdiSoyadi = frmMusteriSec.MusteriAdiSoyadi;
            MusteriTelefonu = frmMusteriSec.MusteriTelefonu;
            txtNameSurname.Text = MusteriAdiSoyadi;
            txtPhone.Text = MusteriTelefonu;
        }

        void Fields(bool State)
        {
            btnSave.Enabled = State;
            btnCancel.Enabled = State;

            btnNew.Enabled = !State;
            btnEdit.Enabled = !State;
            btnDelete.Enabled = !State;

            checkBox1.Enabled = State;
            txtNameSurname.ReadOnly = !State;
            txtPhone.ReadOnly = !State;
            cbTable.Enabled = State;
            dtpStart.Enabled = State;
            dtpEnd.Enabled = State;
        }

        #region Butonların Fonksiyonları
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        } // Ana menü butonu

        private void btnNew_Click(object sender, EventArgs e)
        {
            Fields(true);
            YeniKayit = true;
            txtNameSurname.Text = "";
            txtPhone.Text = "";
            DateControl();
        } // Yeni butonu

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Fields(true);
            YeniKayit = false;
            KayitliPozisyon = bs.Position;
            DateControl();
        } // Düzenle butonu

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            DialogResult dR = MessageBox.Show("Bu rezervasyonu gerçekten silmek istiyor musunuz?\nBu işlem geri alınamaz.", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Controller.Delete_Rezervasyon(int.Parse(lblRezervasyonKodu.Text));
                MessageBox.Show("Seçilmiş olan rezervasyon silindi!", "Bilgilendirme");
                Controller.Select_Rezervasyon();
            }
        } // Sil butonu

        private void btnChoose_Click(object sender, EventArgs e)
        {
            frmMusteriSec msc = new frmMusteriSec();
            msc.frR = this;
            msc.Show();
        } // Seç butonu

        private void btnSave_Click(object sender, EventArgs e)
        {
            int MasaKodu = int.Parse(cbTable.SelectedValue.ToString());

            if (YeniKayit)
            {
                if (txtNameSurname.Text.Trim() != "" || txtPhone.Text.Trim() != "")
                {
                    Controller.Insert_Rezervasyon(MasaKodu, txtNameSurname.Text, txtPhone.Text, dtpStart.Value.ToString(), dtpEnd.Value.ToString());
                    Controller.Select_Rezervasyon();
                    MessageBox.Show("Rezervasyon başarıyla eklendi.", "Bilgilendirme");
                    bs.Position = bs.List.Count;
                }
                else
                {
                    MessageBox.Show("İsim soyisim ve telefon alanları boş olamaz.", "Hata");
                }
            }
            else
            {
                bs.Position = KayitliPozisyon;
            }
            checkBox1.Checked = false;
            btnChoose.Enabled = false;
        } // Kaydet butonu

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Fields(false);
            Controller.Select_Rezervasyon();
            bs.Position = KayitliPozisyon;

            checkBox1.Checked = false;
            btnChoose.Enabled = false;
        } // İptal butonu
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Controller.Select_Rezervasyon(txtSearch.Text);
            bs.DataSource = Controller.ds.Tables["Rezervasyonlar"];
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["MasaKodu"].Visible = false;
            dataGridView1.Columns["RezervasyonKodu"].Visible = false;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btnChoose.Enabled = true;
                txtNameSurname.Text = "";
                txtPhone.Text = "";
                txtNameSurname.ReadOnly = true;
                txtPhone.ReadOnly = true;
            }
            else
            {
                btnChoose.Enabled = false;
                txtNameSurname.ReadOnly = false;
                txtPhone.ReadOnly = false;
            }
        }

        
    }
}
