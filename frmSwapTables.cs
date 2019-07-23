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
    public partial class frmSwapTables : Form
    {
        OleDbConnection con = new OleDbConnection(cDataController.ConnectionString);
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        OleDbCommand cmd = new OleDbCommand();
        DataSet ds = new DataSet();

        public frmSwapTables()
        {
            InitializeComponent();
        }

        private void frmSwapTables_Load(object sender, EventArgs e)
        {
            MasalariCek();
        }

        void MasalariCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            
            if (ds.Tables["Boş Masalar"] == null || ds.Tables["Boş Masalar"].Rows.Count == 0)
            {
                cmd.CommandText = "SELECT * FROM Masalar WHERE Durum=1 ORDER BY MasaNumarasi";
                adpt = new OleDbDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adpt.Fill(ds, "Boş Masalar");
            }
            if (ds.Tables["Dolu Masalar 1"] == null || ds.Tables["Dolu Masalar 1"].Rows.Count == 0 || ds.Tables["Dolu Masalar 2"] == null || ds.Tables["Dolu Masalar 2"].Rows.Count == 0)
            {
                cmd.CommandText = "SELECT * FROM Masalar WHERE Durum=2 ORDER BY MasaNumarasi";
                adpt = new OleDbDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adpt.Fill(ds, "Dolu Masalar 1");
                adpt.Fill(ds, "Dolu Masalar 2");
            }
            if (rbDolu.Checked)
            {
                lbSecondTable.DataSource = ds.Tables["Dolu Masalar 2"];
                lbSecondTable.ValueMember = "MasaKodu";
                lbSecondTable.DisplayMember = "MasaNumarasi";
            }
            else if (rbBos.Checked)
            {
                lbSecondTable.DataSource = ds.Tables["Boş Masalar"];
                lbSecondTable.ValueMember = "MasaKodu";
                lbSecondTable.DisplayMember = "MasaNumarasi";
            }
            lbFirstTable.DataSource = ds.Tables["Dolu Masalar 1"];
            lbFirstTable.ValueMember = "MasaKodu";
            lbFirstTable.DisplayMember = "MasaNumarasi";
        }

        private void RadioButtonStateChange(object sender, EventArgs e)
        {
            if (ds.Tables["Boş Masalar"] != null) ds.Tables["Boş Masalar"].Clear();
            if (ds.Tables["Dolu Masalar 1"] != null) ds.Tables["Dolu Masalar 1"].Clear();
            if (ds.Tables["Dolu Masalar 2"] != null) ds.Tables["Dolu Masalar 2"].Clear();
            MasalariCek();
            Kontrol();
            
        }
        void Kontrol()
        {
            if (lbFirstTable.SelectedItem != null && lbSecondTable.SelectedItem != null && lbFirstTable.SelectedValue.ToString() == lbSecondTable.SelectedValue.ToString())
            {
                btnPay.Enabled = false;
                btnPay.BackColor = Color.FromArgb(2, 46, 48);
            }
            else
            {
                btnPay.Enabled = true;
                btnPay.BackColor = Color.FromArgb(0, 173, 181);
            }
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMasalar form_Masalar = new frmMasalar();
            form_Masalar.Show();
            this.Hide();
        }

        private void lbFirstTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kontrol();
        }

        private void lbSecondTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kontrol();
        }

        private void btnSwap_EnabledChanged(object sender, EventArgs e)
        {
            lblWarning.Visible = !lblWarning.Visible;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (rbBos.Checked)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Adisyon SET MasaKodu=@ymkodu WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@ymkodu",lbSecondTable.SelectedValue);
                cmd.Parameters.AddWithValue("@mkodu", lbFirstTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Masalar SET Durum=1 WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbFirstTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Masalar SET Durum=2 WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbSecondTable.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Masa " + lbFirstTable.Text + ", Masa "+lbSecondTable.Text+"'ye taşınmıştır.", "Bilgi");
                frmMasalar frm = new frmMasalar();
                frm.Show();
                this.Hide();
            }
            else if (rbDolu.Checked)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO MasaTasima SELECT * FROM Adisyon WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbFirstTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Adisyon WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbFirstTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Adisyon SET MasaKodu=@ymkodu WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@ymkodu", lbFirstTable.SelectedValue);
                cmd.Parameters.AddWithValue("@mkodu", lbSecondTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE MasaTasima SET MasaKodu=@ymkodu WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@ymkodu", lbSecondTable.SelectedValue);
                cmd.Parameters.AddWithValue("@mkodu", lbFirstTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Adisyon SELECT * FROM MasaTasima WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbSecondTable.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM MasaTasima WHERE MasaKodu=@mkodu";
                cmd.Parameters.AddWithValue("@mkodu", lbSecondTable.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Masa " + lbFirstTable.Text + " ile Masa "+lbSecondTable.Text+" değiştirilmiştir.", "Bilgi");
                frmMasalar frm = new frmMasalar();
                frm.Show();
                this.Hide();
            }
        }
    }
}
