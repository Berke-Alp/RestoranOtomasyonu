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
    public partial class frmDiscount : Form
    {
        cDataController Controller = new cDataController();
        BindingSource bs = new BindingSource();

        int KayitliPozisyon = 1;
        bool YeniKayit = false;

        public frmDiscount()
        {
            InitializeComponent();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            Controller.Select_IndirimKodu();
            bs.DataSource = Controller.ds.Tables["İndirim Kodları"];
            dataGridView1.DataSource = bs;
            dataGridView1.ReadOnly = true;
            lblKod.DataBindings.Add("Text", bs, "Kod");
            txtCode.DataBindings.Add("Text", bs, "IndirimKodu");
            nupYuzde.DataBindings.Add("Value", bs, "IndirimYuzdesi");

            Fields(false);
        }

        void Fields(bool State)
        {
            txtCode.ReadOnly = !State;
            nupYuzde.Enabled = State;
            btnSave.Enabled = State;
            btnCancel.Enabled = State;
            btnNew.Enabled = !State;
            btnEdit.Enabled = !State;
            btnDelete.Enabled = !State;
        }

        void DisabledColorChange(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) btn.BackColor = Color.FromArgb(0, 173, 181);
            else btn.BackColor = Color.FromArgb(2, 82, 86);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Fields(true);
            YeniKayit = true;
            txtCode.Text = "";
            nupYuzde.Value = 0;
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
            DialogResult dR = MessageBox.Show("Bu kodu gerçekten silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Controller.Delete_IndirimKodu(int.Parse(lblKod.Text));
                MessageBox.Show("Seçilmiş olan kod silindi!", "Bilgilendirme");
                Controller.Select_IndirimKodu();
            }
        }

        private void btnProSave_Click(object sender, EventArgs e)
        {
            bool tkod = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (txtCode.Text.ToUpper() == Controller.ds.Tables["İndirim Kodları1"].Rows[i]["IndirimKodu"].ToString())
                {
                    tkod = true;
                }
            }

            if (tkod && YeniKayit)
            {
                MessageBox.Show("İndirim kodu zaten var!", "Hata");
                
            }
            else if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("İndirim kodu boş olamaz!", "Hata");
            }
            else
            {
                if (YeniKayit)
                {
                    Controller.Insert_IndirimKodu(txtCode.Text.ToUpper().Trim(), Convert.ToInt32(nupYuzde.Value));
                    MessageBox.Show("İndirim kodu başarıyla eklendi.", "Bilgilendirme");
                    Controller.Select_IndirimKodu();
                    bs.Position = bs.List.Count;
                }
                else
                {
                    Controller.Update_IndirimKodu(int.Parse(lblKod.Text), txtCode.Text.ToUpper().Trim(), Convert.ToInt32(nupYuzde.Value));
                    MessageBox.Show("İndirim kodu başarıyla düzenlendi.", "Bilgilendirme");
                    Controller.Select_IndirimKodu();
                    bs.Position = KayitliPozisyon;
                }
                Fields(false);
            }
        }

        private void btnProCancel_Click(object sender, EventArgs e)
        {
            Fields(false);
            Controller.Select_IndirimKodu();
            bs.Position = KayitliPozisyon;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        
    }
}
