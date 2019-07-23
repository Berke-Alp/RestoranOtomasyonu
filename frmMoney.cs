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
    public partial class frmMoney : Form
    {
        cDataController Controller = new cDataController();
        public static DataSet dsMoney;
        public frmMoney()
        {
            InitializeComponent();
        }

        private void frmMoney_Load(object sender, EventArgs e)
        {
            Controller.Select_HesapHareketi();
            Controller.Select_Personel();
            Controller.Select_OdemeTuru();
            dataGridView1.DataSource = Controller.ds.Tables["Hesap Hareketleri"];

            cbPersonel.DataSource = Controller.ds.Tables["Personeller"];
            cbPersonel.ValueMember = "PersonelKodu";
            cbPersonel.DisplayMember = "AdSoyad";

            cbOdemeTuru.DataSource = Controller.ds.Tables["Ödeme Türleri"];
            cbOdemeTuru.ValueMember = "OdemeTuruKodu";
            cbOdemeTuru.DisplayMember = "OdemeTuru";
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain mn = new frmMain();
            mn.Show();
            this.Hide();
        }

        private void btnDoFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (nupMax.Value < nupMin.Value)
                {
                    MessageBox.Show("Maksimum tutar minimum tutardan küçük olamaz!", "Hata");
                }
                else
                {
                    Controller.Select_HesapHareketi(int.Parse(cbPersonel.SelectedValue.ToString()), int.Parse(cbOdemeTuru.SelectedValue.ToString()), nupMax.Value, nupMin.Value);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Filtreler boş olamaz.", "Hata");
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cbOdemeTuru.SelectedIndex = 0;
            cbPersonel.SelectedIndex = 0;
            cbTumKayitlar.Checked = true;
            nupMin.Value = 0M;
            nupMax.Value = 100000M;
        }

        private void cbTumKayitlar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTumKayitlar.Checked)
            {
                cbOdemeTuru.Enabled = false;
                cbPersonel.Enabled = false;
                nupMax.Enabled = false;
                nupMin.Enabled = false;
                btnDoFilter.Enabled = false;
                btnResetFilters.Enabled = false;
                Controller.Select_HesapHareketi();
            }
            else
            {
                cbOdemeTuru.Enabled = true;
                cbPersonel.Enabled = true;
                nupMax.Enabled = true;
                nupMin.Enabled = true;
                btnDoFilter.Enabled = true;
                btnResetFilters.Enabled = true;
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            frmMoneyReport mnr = new frmMoneyReport();
            mnr.ds = Controller.ds;
            mnr.Show();
            this.Hide();
        }
    }
}
