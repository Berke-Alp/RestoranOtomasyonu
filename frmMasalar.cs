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
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        List<Button> ButtonList = new List<Button>();

        // Data Variables
        int TableCount;
        int PageIndex_Total = 0;
        int PageIndex_Current = 1;

        // Button variables
        int pos_X = 14, pos_Y = 14;
        Color button_BG_Rezerve = Color.FromArgb(0, 173, 181);
        Color button_BG_Dolu = Color.FromArgb(255, 0, 0);
        Color button_BG_Bos = Color.FromArgb(0, 255, 0);
        int size_W = 186, size_H = 75;
        
        void GetTables()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = cDataController.ConnectionString;
            if (con.State == ConnectionState.Closed) { con.Open(); }
            string cmdtext = "Select * From Masalar";
            OleDbCommand cmd = new OleDbCommand(cmdtext, con);
            OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adpt.Fill(dt);

            dt.DefaultView.Sort = "MasaNumarasi ASC";
            dt = dt.DefaultView.ToTable();

            // Primary key belirleme
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = dt.Columns["MasaKodu"];
            dt.PrimaryKey = keyColumns;

            con.Close();

            // Data Variables
            TableCount = dt.Rows.Count;
            if (TableCount % 20 != 0)
            {
                PageIndex_Total = (TableCount / 20) + 1;
            }
            else
            {
                PageIndex_Total = (TableCount / 20);
            }
        }

        void PlaceButtons()
        {
            pos_X = 14;
            pos_Y = 14;
            int i = 1, LastIndex = 0;
            i = (PageIndex_Current - 1) * 20 + 1;
            if (PageIndex_Total == PageIndex_Current)
            {
                LastIndex = TableCount;
            }
            else
            {
                LastIndex = 20 * PageIndex_Current;
            }
            for (; i <= LastIndex; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(pos_X, pos_Y);
                if (dt.Rows[i - 1]["Durum"].ToString() == "3") btn.BackColor = button_BG_Rezerve;
                else if (dt.Rows[i - 1]["Durum"].ToString() == "2") btn.BackColor = button_BG_Dolu;
                else btn.BackColor = button_BG_Bos;

                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;
                btn.Name = "btnMasa" + dt.Rows[i - 1]["MasaKodu"].ToString();
                btn.Text = "Masa " + dt.Rows[i - 1]["MasaNumarasi"].ToString();
                btn.Size = new Size(size_W, size_H);
                btn.Margin = new Padding(5);
                btn.Font = btnHome.Font;
                if (i % 5 == 0)
                {
                    pos_X = 14;
                    pos_Y += 85;
                }
                else
                {
                    pos_X += 196;
                }
                btn.Click += btnMasa;
                this.Controls.Add(btn);
                ButtonList.Add(btn);
            }
        }

        void btnMasa(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            frmSiparisler fsip = new frmSiparisler();
            DataRow satir = dt.Rows.Find(int.Parse(btn.Name.Substring(7, btn.Name.Length - 7)));
            fsip.MasaNumarasi = int.Parse(btn.Text.Substring(5, btn.Text.Length - 5));
            fsip.MasaKodu = int.Parse(btn.Name.Substring(7, btn.Name.Length - 7));
            fsip.MasaDurumu = int.Parse(satir["Durum"].ToString());
            fsip.lblTableName.Text = btn.Text;
            fsip.Show();
            this.Hide();
        }

        void DeleteButtons()
        {
            foreach (Button btn in ButtonList)
            {
                this.Controls.Remove(btn);
            }
            ButtonList.Clear();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmMasalar_Load(object sender, EventArgs e)
        {
            GetTables();
            PlaceButtons();
            if (frmLogin.PersonelGorevi == 3)
            {
                btnEditTables.Visible = true;
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            DeleteButtons();
            PageIndex_Current++;
            btnPrevPage.Visible = true;
            if (PageIndex_Current == PageIndex_Total)
            {
                btnNextPage.Visible = false;
            }
            PlaceButtons();
            lblIndex.Text = PageIndex_Current.ToString();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            DeleteButtons();
            PageIndex_Current--;
            btnNextPage.Visible = true;
            if (PageIndex_Current == 1)
            {
                btnPrevPage.Visible = false;
            }
            PlaceButtons();
            lblIndex.Text = PageIndex_Current.ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            frmSwapTables swp = new frmSwapTables();
            swp.Show();
            this.Hide();
        }

        private void btnEditTables_Click(object sender, EventArgs e)
        {
            frmEditTables ed = new frmEditTables();
            ed.Show();
            this.Hide();
        }
    }
}
