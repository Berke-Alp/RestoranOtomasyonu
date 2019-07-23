using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RestoranOtomasyonu
{
    public partial class frmPersonel : Form
    {
        cDataController Controller = new cDataController();
        OleDbConnection con = new OleDbConnection(cDataController.ConnectionString);
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        bool YeniKayitMi = false;

        public frmPersonel()
        {
            InitializeComponent();
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            GorevCek();
            PersonelCek();

            txtName.ReadOnly = true;
            txtSurname.ReadOnly = true;
            cbTask.Enabled = false;
            txtTC.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            bs.DataSource = ds.Tables["Personeller"];
            dataGridView1.DataSource = bs;

            dataGridView1.Columns["PersonelKodu"].Visible = false;
            dataGridView1.Columns["GorevKodu"].Visible = false;

            lblPersonelKodu.DataBindings.Add("Text",bs,"PersonelKodu");
            txtName.DataBindings.Add("Text", bs, "Adı");
            txtSurname.DataBindings.Add("Text", bs, "Soyadı");
            cbTask.DataBindings.Add("Text", bs, "Görev");
            txtTC.DataBindings.Add("Text", bs, "TCNO");
            txtUsername.DataBindings.Add("Text", bs, "Kullanıcı Adı");
            txtPassword.DataBindings.Add("Text", bs, "Parola");
        }

        // Personel tablosunu getir
        void PersonelCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            if (ds.Tables["Personeller"] != null) ds.Tables["Personeller"].Clear();
            if (ds.Tables["Personeller1"] != null) ds.Tables["Personeller1"].Clear();
            cmd.Connection = con;
            cmd.CommandText = "SELECT PersonelKodu,Personel.GorevKodu,Gorevler.Aciklama as [Görev],TCNO,Adi as [Adı],Soyadi as [Soyadı],KullaniciAdi as [Kullanıcı Adı],Parola,SonGiris as [Son Giriş] FROM Personel,Gorevler WHERE Personel.GorevKodu=Gorevler.GorevKodu";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Personeller");
            adpt.Fill(ds, "Personeller1");
        }
        // Personel tablosundan ARAMA yaparak veri çek
        void PersonelCek(string SearchText)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            if (ds.Tables["Personeller"] != null) ds.Tables["Personeller"].Clear();
            cmd.Connection = con;
            cmd.CommandText = "SELECT PersonelKodu,Personel.GorevKodu,Gorevler.Aciklama as [Görev],TCNO,Adi as [Adı],Soyadi as [Soyadı],KullaniciAdi as [Kullanıcı Adı],Parola,SonGiris as [Son Giriş] FROM Personel,Gorevler WHERE (Personel.GorevKodu=Gorevler.GorevKodu) and (Adi Like '%" + SearchText + "%' or Soyadi Like '%" + SearchText + "%' or KullaniciAdi Like '%" + SearchText + "%' or SonGiris Like '%" + SearchText + "%' or Gorevler.Aciklama Like '%" + SearchText + "%' or TCNO Like '%" + SearchText + "%')";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Personeller");
        }
        // Veritabanından görev tiplerini çek
        void GorevCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Gorevler";
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Görevler");
            cbTask.DataSource = ds.Tables["Görevler"];
            cbTask.ValueMember = "GorevKodu";
            cbTask.DisplayMember = "Aciklama";
        }
        // Giriş alanlarının KAPALI/AÇIK kontrolleri
        void Fields(bool State)
        {
            btnSave.Enabled = State;
            btnCancel.Enabled = State;

            btnNew.Enabled = !State;
            btnActions.Enabled = !State;
            btnEdit.Enabled = !State;
            btnDelete.Enabled = !State;

            txtName.ReadOnly = !State;
            txtSurname.ReadOnly = !State;
            cbTask.Enabled = State;
            txtTC.ReadOnly = !State;
            txtUsername.ReadOnly = !State;
            txtPassword.ReadOnly = !State;
        }

        private void DisabledColorChange(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) btn.BackColor = Color.FromArgb(0, 173, 181);
            else btn.BackColor = Color.FromArgb(2, 82, 86);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PersonelCek(txtSearch.Text);
            if (dataGridView1.Rows.Count == 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnActions.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnActions.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            YeniKayitMi = true;
            Fields(true);
            txtName.Text = "";
            txtSurname.Text = "";
            txtTC.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            YeniKayitMi = false;
            Fields(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Bu personeli gerçekten silmek istiyor musunuz?\nUyarı: Personelin tüm kayıtlı hareketleri silinecektir.", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                cmd.CommandText = "DELETE FROM PersonelHareketleri WHERE PersonelKodu=@pkodu";
                cmd.Parameters.AddWithValue("@pkodu", int.Parse(lblPersonelKodu.Text));
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Personel WHERE PersonelKodu=@pkodu";
                cmd.Parameters.AddWithValue("@pkodu", int.Parse(lblPersonelKodu.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seçilmiş olan personel ve kayıtlı hareketleri silindi!","Bilgilendirme");
                PersonelCek();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Fields(false);
            PersonelCek();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            int GorevKodu = int.Parse(cbTask.SelectedValue.ToString());
            int PersonelKodu = int.Parse(lblPersonelKodu.Text);
            bool kadi = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (ds.Tables["Personeller1"].Rows[i]["Kullanıcı Adı"].ToString() == txtUsername.Text)
                {
                    kadi = true;
                }
            }

            if (txtName.Text.Trim() == "" || txtSurname.Text.Trim() == "" || txtTC.Text.Trim() == "" || txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Alanlar boş olamaz!", "Hata");
            }
            else
            {
                if (kadi && YeniKayitMi)
                {
                    MessageBox.Show("Kullanıcı adı zaten var!", "Hata");
                }
                else
                {
                    if (YeniKayitMi)
                    {
                        Controller.Insert_Personel(GorevKodu, txtTC.Text, txtName.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text);
                        MessageBox.Show("Personel başarıyla eklenmiştir.", "Bilgilendirme");
                    }
                    else
                    {
                        Controller.Update_Personel(GorevKodu, txtTC.Text, txtName.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, PersonelKodu);
                        MessageBox.Show("Personel başarıyla düzenlenmiştir.", "Bilgilendirme");
                    }
                    Fields(false);
                    PersonelCek();
                }
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnActions_Click(object sender, EventArgs e)
        {
            frmActions ac = new frmActions();
            ac.PersonelKodu = int.Parse(lblPersonelKodu.Text);
            ac.Show();
        }
    }
}
