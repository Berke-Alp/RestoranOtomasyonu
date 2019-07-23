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
    public partial class frmActions : Form
    {
        OleDbConnection con = new OleDbConnection(cDataController.ConnectionString);
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public int PersonelKodu;

        public frmActions()
        {
            InitializeComponent();
        }

        private void frmActions_Load(object sender, EventArgs e)
        {
            HareketCek();
            dataGridView1.DataSource = ds.Tables["Hareketler"];
            dataGridView1.Columns["PersonelKodu"].Visible = false;
            dataGridView1.Columns["İşlem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Tarih"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void HareketCek()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT PersonelKodu, Islem as [İşlem], Tarih FROM PersonelHareketleri WHERE PersonelKodu=@pkodu";
            cmd.Parameters.AddWithValue("@pkodu", PersonelKodu);
            adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(ds, "Hareketler");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
