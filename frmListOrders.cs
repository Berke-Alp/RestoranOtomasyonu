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
    public partial class frmListOrders : Form
    {
        cDataController Controller = new cDataController();
        public string PersonelAdiSoyadi;
        public int PersonelKodu;

        public frmListOrders()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Gerçekten çıkmak istiyor musunuz?", "Soru", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmListOrders_Load(object sender, EventArgs e)
        {
            Controller.Select_Masa(2);
            lbTables.DataSource = Controller.ds.Tables["Masalar"];
            lbTables.ValueMember = "MasaKodu";
            lbTables.DisplayMember = "MasaNumarasi";

            string CustomQueryString = "SELECT UrunKodu AS [Ürün Kodu], KategoriKodu AS [Kategori Kodu], UrunAdi AS [Ürün Adı], Fiyat FROM Urunler";
            Controller.Custom_Query(CustomQueryString, "Ürünler");
            
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = Controller.ds.Tables["Ürünler"].Columns["Ürün Kodu"];
            Controller.ds.Tables["Ürünler"].PrimaryKey = keyColumns;
            lbTables_SelectedIndexChanged(sender, e);
            if (lbTables.Items.Count == 0)
            {
                MessageBox.Show("Şu anda dolu bir masa bulunmamaktadır.","Bilgi");
            }
        }

        private void lbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lvOrders.Items.Clear();
                Controller.Select_Adisyon(int.Parse(lbTables.SelectedValue.ToString()));
                for (int i = 0; i < Controller.ds.Tables["Adisyonlar"].Rows.Count; i++)
                {
                    DataRow satir = Controller.ds.Tables["Ürünler"].Rows.Find(Controller.ds.Tables["Adisyonlar"].Rows[i]["UrunKodu"]);
                    lvOrders.Items.Add(satir["Ürün Adı"].ToString());
                    lvOrders.Items[i].SubItems.Add(Controller.ds.Tables["Adisyonlar"].Rows[i]["UrunAdet"].ToString());
                    int Fiyat = int.Parse(Controller.ds.Tables["Adisyonlar"].Rows[i]["UrunAdet"].ToString()) * int.Parse(satir["Fiyat"].ToString());
                    lvOrders.Items[i].SubItems.Add(Fiyat.ToString());
                    lvOrders.Items[i].SubItems.Add(satir["Ürün Kodu"].ToString());
                }

                DateTime AdisyonTarihi = Controller.CalculateTheTime(Controller.ds.Tables["Adisyonlar"].Rows[0]["Tarih"].ToString());
                DateTime Simdi = DateTime.Now;
                TimeSpan GecenSure = Simdi - AdisyonTarihi;

                if (lbTables.Items.Count == 0)
                {
                    lblMasaSuresi.Text = "";
                }
                else
                {
                    if (GecenSure.Days == 0 && GecenSure.Hours == 0 && GecenSure.Minutes == 0)
                    {
                        lblMasaSuresi.Text = "Sipariş şimdi verildi.";
                    }
                    else if (GecenSure.Days == 0 && GecenSure.Hours == 0 && GecenSure.Minutes > 0)
                    {
                        lblMasaSuresi.Text = GecenSure.Minutes + " dakika";
                    }
                    else if (GecenSure.Days == 0 && GecenSure.Hours > 0 && GecenSure.Minutes > 0)
                    {
                        lblMasaSuresi.Text = GecenSure.Hours + " saat " + GecenSure.Minutes + " dakika";
                    }
                    else
                    {
                        lblMasaSuresi.Text = GecenSure.Days + " gün " + GecenSure.Hours + " saat " + GecenSure.Minutes + " dakika";
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }
    }
}
