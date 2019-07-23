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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string ButonTanimi;

        private void frmMain_Load(object sender, EventArgs e)
        {
            ButonTanimi = lblButonTanimi.Text;

            PersonelAdiSoyadi.Text = frmLogin.Name_Surname;

            if (frmLogin.PersonelGorevi == 1 || frmLogin.PersonelGorevi == 2)
            {
                btnTables.Visible = true;
                btnSiparisler.Visible = true;
                
                btnPersonel.Visible = false;
                btnCategories.Visible = false;
                btnProducts.Visible = false;
                btnMoney.Visible = false;
                btnDiscount.Visible = false;
            }
            else if (frmLogin.PersonelGorevi == 3)
            {
                btnTables.Visible = true;
                btnSiparisler.Visible = true;
                
                btnPersonel.Visible = true;
                btnCategories.Visible = true;
                btnProducts.Visible = true;
                btnMoney.Visible = true;
                btnDiscount.Visible = true;
            }
        }

        #region Butonların Fonksiyonları
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            frmDiscount dis = new frmDiscount();
            dis.Show();
            this.Hide();
        } // İndirim Kodları butonu
        private void btnMoney_Click(object sender, EventArgs e)
        {
            frmMoney mn = new frmMoney();
            mn.Show();
            this.Hide();
        } // Hesap Kaydı butonu
        private void btnTables_Click(object sender, EventArgs e)
        {
            frmMasalar form_Masalar = new frmMasalar();
            form_Masalar.Show();
            this.Hide();
        } // Masalar butonu
        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            frmListOrders form_LO = new frmListOrders();
            form_LO.Show();
            this.Hide();
        } // Siparişler butonu
        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon rz = new frmRezervasyon();
            rz.Show();
            this.Hide();
        } // Rezervasyonlar butonu
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Gerçekten çıkmak istiyor musunuz?", "Soru", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Application.Exit();
            }
        } // Çıkış butonu
        private void btnPersonel_Click(object sender, EventArgs e)
        {
            frmPersonel pr = new frmPersonel();
            pr.Show();
            this.Hide();
        } // Personeller butonu
        private void btnCatPro_Click(object sender, EventArgs e)
        {
            frmCategories cp = new frmCategories();
            cp.Show();
            this.Hide();
        } // Kategoriler butonu
        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts pr = new frmProducts();
            pr.Show();
            this.Hide();
        } // Ürünler butonu
        #endregion

        #region MouseEnter Metodları
        private void frmMain_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = ButonTanimi;
        } // Formun MouseEnter metodu
        private void btnTables_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Masaları görüntüler";
        } // Masalar butonunun MouseEnter metodu

        private void btnSiparisler_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Mevcut siparişleri görüntüler";
        } // Siparişler butonunun MouseEnter metodu

        private void btnPersonel_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Personelleri düzenleme menüsü";
        } // Personeller butonunun MouseEnter metodu

        private void btnCategories_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Kategorileri düzenleme menüsü";
        } // Kategoriler butonunun MouseEnter metodu

        private void btnProducts_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Ürünleri düzenleme menüsü";
        } // Ürünler butonunun MouseEnter metodu

        private void btnMoney_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Hesap kaydını görüntüleme ve raporlama menüsü";
        }

        private void btnDiscount_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* İndirim kodlarını düzenleme menüsü";
        } // Hesap hareketleri butonunun MouseEnter metodu

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            lblButonTanimi.Text = "* Çıkış butonu";
        }
        #endregion
    }
}
