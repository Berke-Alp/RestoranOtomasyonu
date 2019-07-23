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
    public partial class frmMusteriSec : Form
    {
        cDataController Controller = new cDataController();

        public frmRezervasyon frR;
        public static string MusteriAdiSoyadi = "", MusteriTelefonu = "";

        public frmMusteriSec()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MusteriAdiSoyadi = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["İsim Soyisim"].Value.ToString();
            MusteriTelefonu = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Telefon"].Value.ToString();
            frR.MusteriSec();
            this.Hide();
        }

        private void frmMusteriSec_Load(object sender, EventArgs e)
        {
            Controller.Select_Musteri();
            dataGridView1.DataSource = Controller.ds.Tables["Müşteriler"];
            dataGridView1.Columns["MusteriKodu"].Visible = false;
        }
    }
}
