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
    public partial class frmEditTables : Form
    {
        cDataController Controller = new cDataController();
        BindingSource bs = new BindingSource();

        bool YeniKayit = false;
        int KayitliPozisyon = 1;

        public frmEditTables()
        {
            InitializeComponent();
        }

        private void frmEditTables_Load(object sender, EventArgs e)
        {
            cbDurum.Enabled = false;
            Fields(false);
            Controller.Select_Masa();
            Controller.Select_Durum();
            bs.DataSource = Controller.ds.Tables["Masalar"];
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["dk"].Visible = false;
            dataGridView1.Columns["MasaKodu"].Visible = false;

            cbDurum.DataSource = Controller.ds.Tables["Durum"];
            cbDurum.ValueMember = "DurumID";
            cbDurum.DisplayMember = "Durum";

            lblMasaKodu.DataBindings.Add("Text", bs, "MasaKodu");
            nupKapasite.DataBindings.Add("Value", bs, "Kapasite");
            nupNo.DataBindings.Add("Value", bs, "Masa Numarası");
            cbDurum.DataBindings.Add("SelectedValue", bs, "dk");
        }

        void Fields(bool State)
        {
            nupNo.ReadOnly = !State;
            nupKapasite.ReadOnly = !State;
            btnSave.Enabled = State;
            btnCancel.Enabled = State;
            btnNew.Enabled = !State;
            btnEdit.Enabled = !State;
            btnDelete.Enabled = !State;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbDurum.SelectedValue = 1;
            Fields(true);
            YeniKayit = true;
            nupKapasite.Value = 1;
            nupNo.Value = 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Fields(true);
            YeniKayit = false;
            KayitliPozisyon = bs.Position;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Controller.Connection.State == ConnectionState.Closed) Controller.Connection.Open();
            DialogResult dR = MessageBox.Show("Bu masayı gerçekten silmek istiyor musunuz?\nMasa dolu ise siparişleri de silinecektir.", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Controller.Delete_Masa(int.Parse(lblMasaKodu.Text));
                MessageBox.Show("Seçilmiş olan masa ve adisyonları silindi!", "Bilgilendirme");
                Controller.Select_Masa();
            }
        }
        private void DisabledColorChange(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) btn.BackColor = Color.FromArgb(0, 173, 181);
            else btn.BackColor = Color.FromArgb(2, 82, 86);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool masano = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Controller.ds.Tables["Masalar1"].Rows[i]["Masa Numarası"].ToString() == nupNo.Value.ToString())
                {
                    masano = true;
                }
            }
            if (masano && YeniKayit)
            {
                MessageBox.Show("Aynı numarada zaten bir masa var!", "Bilgilendirme");
            }
            else if (nupKapasite.Value == 0)
            {
                MessageBox.Show("Kapasite '0' olamaz!", "Hata");
            }
            else
            {
                if (YeniKayit)
                {
                    Controller.Insert_Masa(Convert.ToInt32(nupKapasite.Value), Convert.ToInt32(nupNo.Value));
                    MessageBox.Show("Yeni masa başarıyla eklendi!", "Bilgilendirme");
                    bs.Position = bs.List.Count;
                }
                else
                {
                    Controller.Update_Masa(int.Parse(lblMasaKodu.Text), Convert.ToInt32(nupKapasite.Value), Convert.ToInt32(nupNo.Value));
                    MessageBox.Show("Masa başarıyla düzenlendi!", "Bilgilendirme");
                    bs.Position = KayitliPozisyon;
                }
                Fields(false);
                Controller.Select_Masa();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Fields(false);
            Controller.Select_Masa();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMasalar main = new frmMasalar();
            main.Show();
            this.Hide();
        }
    }
}
