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
    public partial class frmSiparisler : Form
    {
        public int MasaKodu, MasaNumarasi, MasaDurumu;
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public frmSiparisler()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMasalar form_Masalar = new frmMasalar();
            form_Masalar.Show();
            this.Hide();
        }

        private void CountButtons(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (txtCount.Text == "0" && btn.Text != "C" && txtCount.Text.Length < 4)
            {
                txtCount.Text = btn.Text;
            }
            else if (txtCount.Text != "0" && btn.Text != "C" && txtCount.Text.Length < 4)
            {
                txtCount.Text = txtCount.Text + btn.Text;
            }
            else if (btn.Text == "C")
            {
                txtCount.Text = "0";
            }
        }

        private void frmSiparisler_Load(object sender, EventArgs e)
        {
            this.Text = "Masa " + MasaNumarasi;
            con.ConnectionString = cDataController.ConnectionString;
            dgvProducts.ForeColor = Color.Black;
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT KategoriKodu,KategoriAdi FROM Kategoriler";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Kategoriler");

            lbCategories.DataSource = ds.Tables["Kategoriler"];
            lbCategories.DisplayMember = "KategoriAdi";
            lbCategories.ValueMember = "KategoriKodu";

            cmd.CommandText = "SELECT UrunKodu AS [Ürün Kodu], KategoriKodu AS [Kategori Kodu], UrunAdi AS [Ürün Adı], Fiyat FROM Urunler";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Ürünler");
            dgvProducts.DataSource = ds.Tables["Ürünler"];
            dgvProducts.Columns["Kategori Kodu"].Visible = false;
            dgvProducts.Columns["Ürün Kodu"].Visible = false;
            dgvProducts.Columns["Ürün Adı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = ds.Tables["Ürünler"].Columns["Ürün Kodu"];
            ds.Tables["Ürünler"].PrimaryKey = keyColumns;

            if (MasaDurumu == 1 || MasaDurumu == 3)
            {
                btnCancel.Visible = false;
                btnPay.Visible = false;
            }
            else if (MasaDurumu == 2)
            {
                btnCancel.Visible = true;
                btnPay.Visible = true;
                AdisyonCek();
            }
            lbCategories_SelectedIndexChanged(sender, e);
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            if (ds.Tables["Ürünler"] != null) ds.Tables["Ürünler"].Clear();
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT UrunKodu AS [Ürün Kodu], KategoriKodu AS [Kategori Kodu], UrunAdi AS [Ürün Adı], Fiyat FROM Urunler WHERE KategoriKodu=@kkodu";
            cmd.Parameters.AddWithValue("@kkodu",lbCategories.SelectedValue.ToString());
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Ürünler");
            dgvProducts.DataSource = ds.Tables["Ürünler"];
            txtSearch.Text = "";
        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal ToplamFiyat = int.Parse(txtCount.Text) * decimal.Parse(dgvProducts.CurrentRow.Cells["Fiyat"].Value.ToString());
            if (txtCount.Text != "0")
            {
                bool KayitVar = false;
                for (int i = 0; i < lvOrders.Items.Count; i++)
                {
                    if (lvOrders.Items[i].Text == dgvProducts.CurrentRow.Cells["Ürün Adı"].Value.ToString())
                    {
                        KayitVar = true;
                        lvOrders.Items[i].SubItems[1].Text = (Convert.ToInt32(lvOrders.Items[i].SubItems[1].Text) + int.Parse(txtCount.Text)).ToString();
                        lvOrders.Items[i].SubItems[2].Text = (int.Parse(lvOrders.Items[i].SubItems[1].Text) * decimal.Parse(dgvProducts.CurrentRow.Cells["Fiyat"].Value.ToString())).ToString();
                    }
                }
                if (!KayitVar)
                {
                    lvOrders.Items.Add(dgvProducts.CurrentRow.Cells["Ürün Adı"].Value.ToString());
                    lvOrders.Items[lvOrders.Items.Count - 1].SubItems.Add(txtCount.Text);
                    lvOrders.Items[lvOrders.Items.Count - 1].SubItems.Add(ToplamFiyat.ToString());
                    lvOrders.Items[lvOrders.Items.Count - 1].SubItems.Add(dgvProducts.CurrentRow.Cells["Ürün Kodu"].Value.ToString());
                }
                AraToplamHesapla();
            }
            txtCount.Text = "1";
        }

        private void lvOrders_DoubleClick(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems != null)
            {
                lvOrders.Items.Remove(lvOrders.SelectedItems[0]);
                AraToplamHesapla();
            }
        }

        void AraToplamHesapla()
        {
            decimal Fiyat = 0.0m;
            foreach (ListViewItem urun in lvOrders.Items)
            {
                Fiyat += decimal.Parse(urun.SubItems[2].Text.ToString());
            }
            lblAraToplam.Text = Fiyat.ToString() + "  TL";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lvOrders.Items.Count == 0)
            {
                MessageBox.Show("Sipariş alabilmeniz için öncelikle ürünlerin üzerine çift\ntıklayarak siparişler listesine eklemeniz gerekmektedir.", "Hata");
            }
            else if (lvOrders.Items.Count > 0 && (MasaDurumu == 1 || MasaDurumu == 3))
            {
                AdisyonYaz();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Masalar SET Durum=2 WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
                cmd.ExecuteNonQuery();
                btnCancel.Visible = true;
                btnPay.Visible = true;
                MessageBox.Show("Sipariş eklenmiş ve masa dolu olarak işaretlenmiştir.", "Bilgilendirme");
            }
            else if (lvOrders.Items.Count > 0 && MasaDurumu == 2)
            {
                DialogResult dR = MessageBox.Show("Masanın mevcut siparişlerini değiştirdiyseniz veya sildiyseniz bu işlemin geri alınamayacağını unutmayınız.\nBu işlemi gerçekleştirmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dR == DialogResult.Yes)
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM Adisyon WHERE MasaKodu=@mkodu";
                    cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
                    cmd.ExecuteNonQuery();
                    AdisyonYaz();
                }
            }
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

        void UrunAra()
        {
            if (ds.Tables["Ürünler"] != null) ds.Tables["Ürünler"].Clear();
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT UrunKodu AS [Ürün Kodu], KategoriKodu AS [Kategori Kodu], UrunAdi AS [Ürün Adı], Fiyat FROM Urunler WHERE UrunAdi Like '%" + txtSearch.Text + "%'";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Ürünler");
            dgvProducts.DataSource = ds.Tables["Ürünler"];
        }

        void AdisyonYaz()
        {
            for (int i = 0; i < lvOrders.Items.Count; i++)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                int Day = DateTime.Now.Day;
                int Month = DateTime.Now.Month;
                int Year = DateTime.Now.Year;
                int Hour = DateTime.Now.Hour;
                int Minute = DateTime.Now.Minute;
                int Second = DateTime.Now.Second;
                string Tarih = Day + "." + Month + "." + Year + " " + Hour + ":" + Minute + ":" + Second;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Adisyon(PersonelKodu,UrunKodu,MasaKodu,UrunAdet,Tarih) VALUES(@pkodu,@ukodu,@mkodu,@uadet,@tarih)";
                cmd.Parameters.AddWithValue("@pkodu", frmLogin.PersonelKodu);
                cmd.Parameters.AddWithValue("@ukodu", int.Parse(lvOrders.Items[i].SubItems[3].Text));
                cmd.Parameters.AddWithValue("@mkodu", MasaKodu);
                cmd.Parameters.AddWithValue("@uadet", int.Parse(lvOrders.Items[i].SubItems[1].Text));
                cmd.Parameters.AddWithValue("@tarih", Tarih);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Bu masanın siparişleri iptal edilecektir ve masa boşa çıkarılacaktır.\nOnaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                if (con.State == ConnectionState.Closed) con.Open();
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
                lvOrders.Items.Clear();
                btnCancel.Visible = false;
                btnPay.Visible = false;
                AraToplamHesapla();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UrunAra();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmPay form_Pay = new frmPay();
            form_Pay.MasaKodu = MasaKodu;
            form_Pay.MasaNumarasi = MasaNumarasi;
            form_Pay.Show();
            this.Hide();
        }
    }
}