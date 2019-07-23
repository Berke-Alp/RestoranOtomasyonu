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
    public partial class frmLogin : Form
    {
        public static string Username, Password, Name_, Surname, Name_Surname;
        public static int PersonelGorevi = 1, PersonelKodu = 1;

        string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Restoran.mdb";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Çıkmak istiyor musunuz?","Çıkış",MessageBoxButtons.YesNo);
            if (dR == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(conString);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    Username = txtUsername.Text;
                    Password = txtPassword.Text;

                    string command = "SELECT * FROM Personel WHERE KullaniciAdi=@Username AND Parola=@Password";
                    OleDbCommand cmd = new OleDbCommand(command, con);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    cmd.ExecuteNonQuery();
                    adapter.Fill(ds, "Personel");

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Yanlış kullanıcı adı veya parola.", "Hatalı giriş");
                    }
                    else
                    {
                        int Day = DateTime.Now.Day;
                        int Month = DateTime.Now.Month;
                        int Year = DateTime.Now.Year;
                        int Hour = DateTime.Now.Hour;
                        int Minute = DateTime.Now.Minute;
                        int Second = DateTime.Now.Second;
                        string Date = Day + "." + Month + "." + Year + " " + Hour + ":" + Minute + ":" + Second;

                        Name_ = ds.Tables[0].Rows[0]["Adi"].ToString();
                        Surname = ds.Tables[0].Rows[0]["Soyadi"].ToString();
                        Name_Surname = Name_ + " " + Surname;
                        PersonelGorevi = int.Parse(ds.Tables[0].Rows[0]["GorevKodu"].ToString());
                        PersonelKodu = int.Parse(ds.Tables[0].Rows[0]["PersonelKodu"].ToString());
                        
                        command = "UPDATE Personel SET SonGiris=@LastLoginDate WHERE KullaniciAdi=@Username";
                        cmd = new OleDbCommand(command, con);
                        cmd.Parameters.AddWithValue("@LastLoginDate", Date);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.ExecuteNonQuery();

                        command = "INSERT INTO PersonelHareketleri(PersonelKodu,Islem,Tarih) VALUES(@PersonelKodu,'Giriş yaptı.',@IslemTarihi)";
                        cmd = new OleDbCommand(command, con);
                        cmd.Parameters.AddWithValue("@PersonelKodu", PersonelKodu);
                        cmd.Parameters.AddWithValue("@IslemTarihi", Date);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(Name_ + " " + Surname + " olarak giriş yaptınız.", "Başarılı giriş");
                        frmMain mainMenu = new frmMain();
                        mainMenu.Show();
                        this.Hide();
                    }
                }
            }
            catch { MessageBox.Show("Bağlantı kurulamadı. Sistem yöneticinize başvurun.", "Hata"); }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
