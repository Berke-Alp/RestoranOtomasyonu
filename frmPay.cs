using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranOtomasyonu
{
    public partial class frmPay : Form
    {
        public int MasaNumarasi, MasaKodu;
        int IndirimKodu, IndirimYuzdesi;
        bool Indirim = false;
        decimal KDVTutari, AraToplam, ToplamTutar, IndirimTutari = 0;

        OleDbConnection con = new OleDbConnection(cDataController.ConnectionString);
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        OleDbCommand cmd = new OleDbCommand();
        DataSet ds = new DataSet();

        public frmPay()
        {
            InitializeComponent();
        }

        void AdisyonCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Adisyon WHERE MasaKodu=@mkodu";
            cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Adisyon");
            for (int i = 0; i < ds.Tables["Adisyon"].Rows.Count; i++)
            {
                DataRow satir = ds.Tables["Ürünler"].Rows.Find(ds.Tables["Adisyon"].Rows[i]["UrunKodu"]);
                lvOrders.Items.Add(satir["Ürün Adı"].ToString());
                lvOrders.Items[i].SubItems.Add(ds.Tables["Adisyon"].Rows[i]["UrunAdet"].ToString());
                int Fiyat = int.Parse(ds.Tables["Adisyon"].Rows[i]["UrunAdet"].ToString()) * int.Parse(satir["Fiyat"].ToString());
                lvOrders.Items[i].SubItems.Add(Fiyat.ToString());
                lvOrders.Items[i].SubItems.Add(satir["Ürün Kodu"].ToString());
            }
            AraToplamHesapla();
        }

        void AraToplamHesapla()
        {
            decimal Fiyat = 0.0m;
            foreach (ListViewItem urun in lvOrders.Items)
            {
                Fiyat += decimal.Parse(urun.SubItems[2].Text.ToString());
            }
            lblAraToplam.Text = String.Format("{0:0.00}", Fiyat) + "  TL";
            AraToplam = Fiyat;
        }

        void OdemeTuruCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM OdemeTurleri";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Ödeme Türleri");
            cbPayType.DataSource = ds.Tables["Ödeme Türleri"];
            cbPayType.ValueMember = "OdemeTuruKodu";
            cbPayType.DisplayMember = "OdemeTuru";
        }

        bool IndirimKoduCek(string DiscountCode)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            if (ds.Tables["İndirim Kodları"] != null) ds.Tables["İndirim Kodları"].Clear();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM IndirimKodlari WHERE IndirimKodu='" + DiscountCode + "'";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "İndirim Kodları");
            if (ds.Tables["İndirim Kodları"].Rows.Count == 0)
            {
                return false;
            }
            else if (ds.Tables["İndirim Kodları"].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.CommandText = "SELECT UrunKodu AS [Ürün Kodu], KategoriKodu AS [Kategori Kodu], UrunAdi AS [Ürün Adı], Fiyat FROM Urunler";
            cmd.Connection = con;
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Ürünler");

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = ds.Tables["Ürünler"].Columns["Ürün Kodu"];
            ds.Tables["Ürünler"].PrimaryKey = keyColumns;

            lblTableName.Text = "Masa " + MasaNumarasi;
            AdisyonCek();
            OdemeTuruCek();
            KDVTutari = AraToplam * 0.18M;
            ToplamTutar = AraToplam;
            lblToplamTutar.Text = String.Format("{0:0.00}", ToplamTutar) + " TL";
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (IndirimKoduCek(txtDiscount.Text))
            {
                pbDiscount.Image = Properties.Resources.Tick_96;
                IndirimKodu = int.Parse(ds.Tables["İndirim Kodları"].Rows[0]["Kod"].ToString());
                IndirimYuzdesi = int.Parse(ds.Tables["İndirim Kodları"].Rows[0]["IndirimYuzdesi"].ToString());
                IndirimTutari = AraToplam * (decimal)(IndirimYuzdesi / 100M);
                ToplamTutar = AraToplam - IndirimTutari;
                lblToplamTutar.Text = ToplamTutar + "  TL";
                txtDiscount.ReadOnly = true;
                Indirim = true;
            }
            else
            {
                pbDiscount.Image = Properties.Resources.Delete_96;
                IndirimTutari = 0;
                ToplamTutar = AraToplam;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int Day = DateTime.Now.Day;
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            int Hour = DateTime.Now.Hour;
            int Minute = DateTime.Now.Minute;
            int Second = DateTime.Now.Second;
            string Date = Day + "." + Month + "." + Year + " " + Hour + ":" + Minute + ":" + Second;

            //AraToplam = Math.Round(AraToplam, 2, MidpointRounding.AwayFromZero);
            //KDVTutari = Math.Round(KDVTutari, 2, MidpointRounding.AwayFromZero);
            //IndirimTutari = Math.Round(IndirimTutari, 2, MidpointRounding.AwayFromZero);
            //ToplamTutar = Math.Round(ToplamTutar, 2, MidpointRounding.AwayFromZero);

            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO HesapHareketleri(PersonelKodu,OdemeTuruKodu,AraToplam,KdvTutari,Indirim,ToplamTutar,Tarih) VALUES(@PK,@OTK,@AT,@KDV,@DIS,@TT,@Tarih)";
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.Parameters.AddWithValue("@PK", frmLogin.PersonelKodu);
            cmd.Parameters.AddWithValue("@OTK", int.Parse(cbPayType.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@AT",Math.Round((double)AraToplam, 2));
            cmd.Parameters.AddWithValue("@KDV", Math.Round((double)KDVTutari, 2));
            cmd.Parameters.AddWithValue("@DIS", Math.Round((double)IndirimTutari, 2));
            cmd.Parameters.AddWithValue("@TT", Math.Round((double)ToplamTutar, 2));
            cmd.Parameters.AddWithValue("@Tarih", Date);
            cmd.ExecuteNonQuery();
            if (Indirim)
            {
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM IndirimKodlari WHERE Kod=@Kod";
                cmd.Parameters.AddWithValue("@Kod", IndirimKodu);
                cmd.ExecuteNonQuery();
            }
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Adisyon WHERE MasaKodu=@mkodu";
            cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Masalar SET Durum=1 WHERE MasaKodu=@mkodu";
            cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO PersonelHareketleri(PersonelKodu,Islem,Tarih) VALUES(@pkodu,@islem,@tarih)";
            cmd.Parameters.AddWithValue("@pkodu", frmLogin.PersonelKodu);
            cmd.Parameters.AddWithValue("@islem", MasaNumarasi + " Numaralı masanın ödemesini gerçekleştirdi.");
            cmd.Parameters.AddWithValue("@tarih", Date);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ödeme işlemi başarıyla tamamlandı ve kayıtlara işlendi.","Bilgi");

            frmMasalar form_Masalar = new frmMasalar();
            form_Masalar.Show();
            this.Hide();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMasalar form_Masalar = new frmMasalar();
            form_Masalar.Show();
            this.Hide();
        }
    }
}
