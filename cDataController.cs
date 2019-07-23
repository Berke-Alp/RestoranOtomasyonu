using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace RestoranOtomasyonu
{
    class cDataController
    {
        // Genel veritabanı bağlantı cümlesi
        public static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Restoran.mdb";

        // OleDb sınıfına ait nesneler
        public OleDbConnection Connection = new OleDbConnection(ConnectionString);
        public OleDbCommand Command = new OleDbCommand();
        public OleDbDataAdapter Adapter;
        public DataSet ds = new DataSet();

        public cDataController()
        {
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            Command.Connection = Connection;
        }

        // Custom select sorgusu yapan metod
        public void Custom_Query(string CommandString, string TableName)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = CommandString;
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, TableName);
        }

        /// <summary>
        /// yyyy.m.d h:m:s formatındaki string bilgiyi DateTime tipine aktarır.
        /// </summary>
        /// <param name="Date">yyyy.m.d h:m:s formatındaki metin (ör: 2019.5.14 15:45:00)</param>
        /// <returns>DateTime tipinde tarih</returns>
        public DateTime CalculateTheTime(string Date)
        {
            int FirstDotIndex = Date.IndexOf('.');
            int Day = int.Parse(Date.Substring(0, FirstDotIndex));
            Date = Date.Substring(FirstDotIndex + 1, Date.Length - (FirstDotIndex + 1));

            FirstDotIndex = Date.IndexOf('.');
            int Month = int.Parse(Date.Substring(0, FirstDotIndex));
            Date = Date.Substring(FirstDotIndex + 1, Date.Length - (FirstDotIndex + 1));

            FirstDotIndex = Date.IndexOf(' ');
            int Year = int.Parse(Date.Substring(0, FirstDotIndex));
            Date = Date.Substring(FirstDotIndex + 1, Date.Length - (FirstDotIndex + 1));

            FirstDotIndex = Date.IndexOf(':');
            int Hour = int.Parse(Date.Substring(0, FirstDotIndex));
            Date = Date.Substring(FirstDotIndex + 1, Date.Length - (FirstDotIndex + 1));

            FirstDotIndex = Date.IndexOf(':');
            int Minute = int.Parse(Date.Substring(0, FirstDotIndex));
            Date = Date.Substring(FirstDotIndex + 1, Date.Length - (FirstDotIndex + 1));

            FirstDotIndex = Date.IndexOf(':');
            int Second = int.Parse(Date);

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }

        #region Personel İşlemleri
        public void Select_Personel()
        {
            if (ds.Tables["Personeller"] != null) ds.Tables["Personeller"].Clear();
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "SELECT PersonelKodu,(Adi+' '+Soyadi) as [AdSoyad] FROM Personel";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Personeller");
        }
        public void Insert_Personel(int GorevKodu, string TCNO, string Adi, string Soyadi, string KullaniciAdi, string Parola)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO Personel(GorevKodu,TCNO,Adi,Soyadi,KullaniciAdi,Parola,SonGiris) VALUES(@gkodu,@tc,@adi,@soyadi,@user,@pass,'Yok')";
            Command.Parameters.AddWithValue("@gkodu", GorevKodu);
            Command.Parameters.AddWithValue("@tc", TCNO);
            Command.Parameters.AddWithValue("@adi", Adi);
            Command.Parameters.AddWithValue("@soyadi", Soyadi);
            Command.Parameters.AddWithValue("@user", KullaniciAdi);
            Command.Parameters.AddWithValue("@pass", Parola);
            Command.ExecuteNonQuery();
        }
        public void Update_Personel(int GorevKodu, string TCNO, string Adi, string Soyadi, string KullaniciAdi, string Parola, int PersonelKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "UPDATE Personel SET GorevKodu=@gkodu,TCNO=@tc,Adi=@adi,Soyadi=@soyadi,KullaniciAdi=@user,Parola=@pass,SonGiris='Yok' WHERE PersonelKodu=@pkodu";
            Command.Parameters.AddWithValue("@gkodu", GorevKodu);
            Command.Parameters.AddWithValue("@tc", TCNO);
            Command.Parameters.AddWithValue("@adi", Adi);
            Command.Parameters.AddWithValue("@soyadi", Soyadi);
            Command.Parameters.AddWithValue("@user", KullaniciAdi);
            Command.Parameters.AddWithValue("@pass", Parola);
            Command.Parameters.AddWithValue("@pkodu", PersonelKodu);
            Command.ExecuteNonQuery();
        }
        #endregion

        #region Masa İşlemleri
        public void Select_Masa()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Masalar"] != null) ds.Tables["Masalar"].Clear();
            if (ds.Tables["Masalar1"] != null) ds.Tables["Masalar1"].Clear();
            Command.CommandText = "SELECT MasaKodu,Masalar.Durum as [dk],MasaNumarasi as [Masa Numarası],Kapasite,Durumlar.Durum FROM Masalar,Durumlar WHERE Masalar.Durum=Durumlar.DurumID ORDER BY MasaNumarasi";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Masalar");
            Adapter.Fill(ds, "Masalar1");
        }
        public void Select_Durum()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Durum"] != null) ds.Tables["Durum"].Clear();
            Command.CommandText = "SELECT * FROM Durumlar";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Durum");
        }
        public void Select_Masa(int Durum)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Masalar"] != null) ds.Tables["Masalar"].Clear();
            Command.CommandText = "SELECT MasaKodu, MasaNumarasi FROM Masalar WHERE Durum=@durum";
            Command.Parameters.AddWithValue("@durum", Durum);
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Masalar");
        }
        public void Insert_Masa(int Kapasite, int MasaNumarasi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO Masalar(MasaNumarasi,Kapasite,Durum) VALUES(@mno,@kap,1)";
            Command.Parameters.AddWithValue("@mno", MasaNumarasi);
            Command.Parameters.AddWithValue("@kap", Kapasite);
            Command.ExecuteNonQuery();
        }
        public void Update_Masa(int MasaKodu, int Kapasite, int MasaNumarasi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "UPDATE Masalar SET Kapasite=@kap, MasaNumarasi=@mno WHERE MasaKodu=@mkodu";
            Command.Parameters.AddWithValue("@kap", Kapasite);
            Command.Parameters.AddWithValue("@mno", MasaNumarasi);
            Command.Parameters.AddWithValue("@mkodu", MasaKodu);
            Command.ExecuteNonQuery();
        }
        public void Delete_Masa(int MasaKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM Masalar WHERE MasaKodu=@mkodu";
            Command.Parameters.AddWithValue("@mkodu", MasaKodu);
            Command.ExecuteNonQuery();
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM Adisyon WHERE MasaKodu=@mkodu";
            Command.Parameters.AddWithValue("@mkodu", MasaKodu);
            Command.ExecuteNonQuery();
        }
        #endregion

        #region Ödeme Türü İşlemleri
        public void Select_OdemeTuru()
        {
            if (ds.Tables["Ödeme Türleri"] != null) ds.Tables["Ödeme Türleri"].Clear();
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "SELECT * FROM OdemeTurleri";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Ödeme Türleri");
        }
        #endregion

        #region Kategori İşlemleri
        public void Select_Kategori()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Kategoriler"] != null) ds.Tables["Kategoriler"].Clear();
            Command.CommandText = "SELECT KategoriKodu, KategoriAdi as [Kategori Adı], Aciklama as [Açıklama] FROM Kategoriler";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Kategoriler");
        }
        public void Select_Kategori(string AramaCumlesi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Kategoriler"] != null) ds.Tables["Kategoriler"].Clear();
            Command.CommandText = "SELECT KategoriKodu, KategoriAdi as [Kategori Adı], Aciklama as [Açıklama] FROM Kategoriler WHERE KategoriAdi LIKE '%"+AramaCumlesi+"%' OR Aciklama LIKE '%"+AramaCumlesi+"%'";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Kategoriler");
        }
        public void Insert_Kategori(string KategoriAdi, string Aciklama)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO Kategoriler(KategoriAdi,Aciklama) VALUES(@kadi,@aciklama)";
            Command.Parameters.AddWithValue("@kadi", KategoriAdi);
            Command.Parameters.AddWithValue("@aciklama", Aciklama);
            Command.ExecuteNonQuery();
        }
        public void Update_Kategori(string KategoriAdi, string Aciklama, int KategoriKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "UPDATE Kategoriler SET KategoriAdi=@ad, Aciklama=@desc WHERE KategoriKodu=@kkodu";
            Command.Parameters.AddWithValue("@ad", KategoriAdi);
            Command.Parameters.AddWithValue("@desc", Aciklama);
            Command.Parameters.AddWithValue("@kkodu", KategoriKodu);
            Command.ExecuteNonQuery();
        }
        public void Delete_Kategori(int KategoriKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM Kategoriler WHERE KategoriKodu=@kkodu";
            Command.Parameters.AddWithValue("@kkodu", KategoriKodu);
            Command.ExecuteNonQuery();
        }
        #endregion

        #region Ürün İşlemleri
        public void Select_Urun()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Ürünler"] != null) ds.Tables["Ürünler"].Clear();
            Command.CommandText = "SELECT UrunKodu, Urunler.KategoriKodu, Kategoriler.KategoriAdi as [Kategori], UrunAdi as [Ürün Adı], Urunler.Aciklama as [Açıklama], Fiyat FROM Urunler,Kategoriler WHERE Urunler.KategoriKodu=Kategoriler.KategoriKodu";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Ürünler");
        }
        public void Select_Urun(string AramaCumlesi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Ürünler"] != null) ds.Tables["Ürünler"].Clear();
            Command.CommandText = "SELECT UrunKodu, Urunler.KategoriKodu, Kategoriler.KategoriAdi as [Kategori], UrunAdi as [Ürün Adı], Urunler.Aciklama as [Açıklama], Fiyat FROM Urunler,Kategoriler WHERE (Urunler.KategoriKodu=Kategoriler.KategoriKodu) AND (UrunAdi LIKE '%" + AramaCumlesi + "%' OR Urunler.Aciklama LIKE '%" + AramaCumlesi + "%' OR Kategoriler.KategoriAdi LIKE '%" + AramaCumlesi + "%')";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Ürünler");
        }
        public void Insert_Urun(int KategoriKodu, string UrunAdi, string Aciklama, decimal Fiyat)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO Urunler(KategoriKodu,UrunAdi,Aciklama,Fiyat) VALUES(@kkodu,@ad,@desc,@fiyat)";
            Command.Parameters.AddWithValue("@kkodu", KategoriKodu);
            Command.Parameters.AddWithValue("@ad", UrunAdi);
            Command.Parameters.AddWithValue("@desc", Aciklama);
            Command.Parameters.AddWithValue("@fiyat", Fiyat);
            Command.ExecuteNonQuery();
        }
        public void Update_Urun(int KategoriKodu, string UrunAdi, string Aciklama, decimal Fiyat, int UrunKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "UPDATE Urunler SET KategoriKodu=@kkodu, UrunAdi=@uadi, Aciklama=@desc, Fiyat=@fiyat WHERE UrunKodu=@ukodu";
            Command.Parameters.AddWithValue("@kkodu", KategoriKodu);
            Command.Parameters.AddWithValue("@uadi", UrunAdi);
            Command.Parameters.AddWithValue("@desc", Aciklama);
            Command.Parameters.AddWithValue("@fiyat", Fiyat);
            Command.Parameters.AddWithValue("@ukodu", UrunKodu);
            Command.ExecuteNonQuery();
        }
        public void Delete_Urun(int UrunKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM Urunler WHERE UrunKodu=@ukodu";
            Command.Parameters.AddWithValue("@ukodu", UrunKodu);
            Command.ExecuteNonQuery();
        }
        #endregion

        #region Adisyon İşlemleri
        public void Select_Adisyon()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Adisyonlar"] != null) ds.Tables["Adisyonlar"].Clear();
            Command.CommandText = "SELECT * FROM Adisyon";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Adisyonlar");
        }
        public void Select_Adisyon(int MasaKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Adisyonlar"] != null) ds.Tables["Adisyonlar"].Clear();
            Command.CommandText = "SELECT * FROM Adisyon WHERE MasaKodu=" + MasaKodu + "";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Adisyonlar");
        }
        #endregion

        #region Rezervasyon İşlemleri
        public void Select_Rezervasyon()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Rezervasyonlar"] != null) ds.Tables["Rezervasyonlar"].Clear();
            Command.CommandText = "SELECT RezervasyonKodu, Rezervasyonlar.MasaKodu, Masalar.MasaNumarasi as [Masa Numarası], MusteriAdiSoyadi as [İsim Soyisim], MusteriTelefonu as [Telefon], BaslangicZamani as [Başlangıç], BitisZamani as [Bitiş] FROM Rezervasyonlar,Masalar WHERE Rezervasyonlar.MasaKodu=Masalar.MasaKodu";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Rezervasyonlar");
        }
        public void Select_Rezervasyon(string AramaCumlesi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Rezervasyonlar"] != null) ds.Tables["Rezervasyonlar"].Clear();
            Command.CommandText = "SELECT RezervasyonKodu, Rezervasyonlar.MasaKodu, Masalar.MasaNumarasi as [Masa Numarası], MusteriAdiSoyadi as [İsim Soyisim], MusteriTelefonu as [Telefon], BaslangicZamani as [Başlangıç], BitisZamani as [Bitiş] FROM Rezervasyonlar,Masalar WHERE (Rezervasyonlar.MasaKodu=Masalar.MasaKodu) AND (Masalar.MasaNumarasi Like '%" + AramaCumlesi + "%' OR MusteriAdiSoyadi Like '%" + AramaCumlesi + "%' OR MusteriTelefonu Like '%" + AramaCumlesi + "%')";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Rezervasyonlar");
        }
        public void Insert_Rezervasyon(int MasaKodu,string MusteriAdiSoyadi,string MusteriTelefonu, string BaslangicZamani, string BitisZamani)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO Rezervasyonlar(MasaKodu,MusteriAdiSoyadi,MusteriTelefonu,BaslangicZamani,BitisZamani) VALUES(@mkodu,@mas,@mt,@baz,@biz)";
            Command.Parameters.AddWithValue("@mkodu", MasaKodu);
            Command.Parameters.AddWithValue("@mas", MusteriAdiSoyadi);
            Command.Parameters.AddWithValue("@mt", MusteriTelefonu);
            Command.Parameters.AddWithValue("@baz", BaslangicZamani);
            Command.Parameters.AddWithValue("@biz", BitisZamani);
            Command.ExecuteNonQuery();
        }
        public void Delete_Rezervasyon(int RezervasyonKodu)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM Rezervasyonlar WHERE RezervasyonKodu=@rkodu";
            Command.Parameters.AddWithValue("@rkodu", RezervasyonKodu);
            Command.ExecuteNonQuery();
        }
        #endregion

        #region Müşteri İşlemleri
        public void Select_Musteri()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Müşteriler"] != null) ds.Tables["Müşteriler"].Clear();
            Command.CommandText = "SELECT MusteriKodu,MusteriAdiSoyadi as [İsim Soyisim],MusteriTelefonu as [Telefon] FROM Musteriler";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Müşteriler");
        }
        public void Select_Musteri(string AramaCumlesi)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["Müşteriler"] != null) ds.Tables["Müşteriler"].Clear();
            Command.CommandText = "SELECT MusteriKodu,MusteriAdiSoyadi,MusteriTelefonu FROM Musteriler WHERE (MusteriAdiSoyadi Like '%"+AramaCumlesi+"%' OR MusteriTelefonu Like '%"+AramaCumlesi+"%')";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Müşteriler");
        }
        #endregion

        #region Hesap Hareketleri İşlemleri
        public void Select_HesapHareketi()
        {
            if (ds.Tables["Hesap Hareketleri"] != null) ds.Tables["Hesap Hareketleri"].Clear();
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "SELECT HesapKodu, HesapHareketleri.PersonelKodu, (Personel.Adi + ' ' + Personel.Soyadi) as [pas],HesapHareketleri.OdemeTuruKodu, OdemeTurleri.OdemeTuru,AraToplam, KdvTutari,Indirim,ToplamTutar,Tarih FROM HesapHareketleri,Personel,OdemeTurleri WHERE (Personel.PersonelKodu=HesapHareketleri.PersonelKodu) AND (OdemeTurleri.OdemeTuruKodu=HesapHareketleri.OdemeTuruKodu)";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Hesap Hareketleri");
        }
        public void Select_HesapHareketi(int PersonelKodu, int OdemeTuruKodu, decimal Max, decimal Min)
        {
            if (ds.Tables["Hesap Hareketleri"] != null) ds.Tables["Hesap Hareketleri"].Clear();
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "SELECT HesapKodu, HesapHareketleri.PersonelKodu, (Personel.Adi + ' ' + Personel.Soyadi) as [pas],HesapHareketleri.OdemeTuruKodu, OdemeTurleri.OdemeTuru,AraToplam, KdvTutari,Indirim,ToplamTutar,Tarih FROM HesapHareketleri,Personel,OdemeTurleri WHERE ((Personel.PersonelKodu=HesapHareketleri.PersonelKodu) AND (OdemeTurleri.OdemeTuruKodu=HesapHareketleri.OdemeTuruKodu)) AND (HesapHareketleri.PersonelKodu=@pkodu AND HesapHareketleri.OdemeTuruKodu=@okodu AND (ToplamTutar < @max AND ToplamTutar > @min))";
            Command.Parameters.AddWithValue("@pkodu", PersonelKodu);
            Command.Parameters.AddWithValue("@okodu", OdemeTuruKodu);
            Command.Parameters.AddWithValue("@max", Max);
            Command.Parameters.AddWithValue("@min", Min);
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "Hesap Hareketleri");
        }
        #endregion

        #region İndirim Kodu İşlemleri
        public void Select_IndirimKodu()
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            if (ds.Tables["İndirim Kodları"] != null) ds.Tables["İndirim Kodları"].Clear();
            if (ds.Tables["İndirim Kodları1"] != null) ds.Tables["İndirim Kodları1"].Clear();
            Command.CommandText = "SELECT * FROM IndirimKodlari";
            Adapter = new OleDbDataAdapter(Command);
            Command.ExecuteNonQuery();
            Adapter.Fill(ds, "İndirim Kodları");
            Adapter.Fill(ds, "İndirim Kodları1");
        }
        public void Insert_IndirimKodu(string Kod, int Yuzde)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "INSERT INTO IndirimKodlari(IndirimKodu,IndirimYuzdesi) VALUES(@kod,@yuzde)";
            Command.Parameters.AddWithValue("@kod", Kod);
            Command.Parameters.AddWithValue("@yuzde", Yuzde);
            Command.ExecuteNonQuery();
        }
        public void Update_IndirimKodu(int Kod,string IKod,int Yuzde)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "UPDATE IndirimKodlari SET IndirimKodu=@ikod, IndirimYuzdesi=@yuzde WHERE Kod=@kod";
            Command.Parameters.AddWithValue("@ikod", IKod);
            Command.Parameters.AddWithValue("@yuzde", Yuzde);
            Command.Parameters.AddWithValue("@kod", Kod);
            Command.ExecuteNonQuery();
        }
        public void Delete_IndirimKodu(int Kod)
        {
            Command = new OleDbCommand();
            Command.Connection = Connection;
            Command.CommandText = "DELETE FROM IndirimKodlari WHERE Kod=@kod";
            Command.Parameters.AddWithValue("@kod", Kod);
            Command.ExecuteNonQuery();
        }
        #endregion
    }
}