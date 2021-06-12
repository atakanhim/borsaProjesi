using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace borsaProjesi
{
    public class DataIslemleri
    {

        public readonly OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borsadatabase.accdb");
        OleDbCommand komut;

        // program calistiginda calisak olan kod
        public void SiparistenSatinAl()
        {
           
            OpenConnection();
            OleDbDataReader ReadSiparislerData = ReadDatabase("Select * from Siparisler Where SiparisDurumu='" + "Aranıyor" + "' ORDER BY siparisOlusturulmaTarihi ASC ");
            while (ReadSiparislerData.Read())
            {
                double siparisFiyati = Convert.ToDouble(ReadSiparislerData["KacParayaAlacak"].ToString());
                int adetSayisi = Convert.ToInt32(ReadSiparislerData["KacAdetAlacak"].ToString());
                double toplamFiyat = siparisFiyati * adetSayisi;
                double muhasebeciHarac = toplamFiyat / 100;
                double toplamCekilecekPara = toplamFiyat + muhasebeciHarac;
                double userHesapbakiyesi = 0;
                OleDbDataReader ReadUserBilgileri = ReadDatabase("Select * from Users Where UserName='" + ReadSiparislerData["siparisVerenKisi"].ToString()+ "'");
                if (ReadUserBilgileri.Read())// kullanıcının parası varmı yoksa hiç denemesin
                    userHesapbakiyesi = Convert.ToInt32(ReadUserBilgileri["hesapBakiye"].ToString());

                if (userHesapbakiyesi >= toplamCekilecekPara) { 

                    OleDbDataReader ReadUrunlerData = ReadDatabase("Select * from Uruns Where UrunName='" + ReadSiparislerData["urunAdi"].ToString() + "' AND UrunMiktari>0 AND urunOnay='"+ "Onaylandı" + "' AND NOT UrunSatici='" + ReadSiparislerData["siparisVerenKisi"].ToString() + "' ORDER BY UrunFiyati ASC");
                    if (ReadUrunlerData.Read())
                    {
                        int urunSayisi = Convert.ToInt32(ReadUrunlerData["UrunMiktari"].ToString());
                        double urunFiyati = Convert.ToInt32(ReadUrunlerData["UrunFiyati"].ToString());
                        if (siparisFiyati == urunFiyati && adetSayisi <= urunSayisi)//varsa
                        {
                            // para cegildi + komisyonda çekildi
                            ParaCekWithUserName(toplamCekilecekPara, ReadSiparislerData["siparisVerenKisi"].ToString());

                            // para saticinin hesaba geciyor
                            double newBakiye = Convert.ToDouble(ReadUserBilgileri["hesapBakiye"].ToString());
                            newBakiye += toplamFiyat;
                            AddOrUpdateDatabase("update Users set hesapBakiye='" + newBakiye + "' where UserName='" + ReadUrunlerData["UrunSatici"] + "'");

                            //Muhasebeci parasi yatirildi
                            MuhasebeHarac(muhasebeciHarac);

                            // urun sayisi azaltılıyor
                            int newAdetSayisi = Convert.ToInt32(ReadUrunlerData["UrunMiktari"].ToString());
                            newAdetSayisi -= adetSayisi;
                            AddOrUpdateDatabase("update Uruns set UrunMiktari='" + newAdetSayisi + "' where urunBarkodNo='" + ReadUrunlerData["urunBarkodNo"].ToString() + "'");

                            // satis veri tabanına kaydediliyor
                            AddOrUpdateDatabase("insert into Satislar(UrunAdi,SatisFiyati,SatisMiktari,UrunBirimi,SatisYapan,SatinAlan,SatisTarihi) values('" + ReadUrunlerData["UrunName"].ToString() + "','" + ReadUrunlerData["UrunFiyati"].ToString() + "','" + adetSayisi.ToString() + "','" + ReadUrunlerData["UrunBirimi"].ToString() + "','" + ReadUrunlerData["UrunSatici"].ToString() + "','" + ReadSiparislerData["siparisVerenKisi"].ToString() + "','" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString() + "')");

                            // Siparis satildigi için siparisşler tablosuna satildi yaziliyor
                            AddOrUpdateDatabase("update Siparisler set SiparisDurumu='" + "Satin alindi" + "' where urunAdi='" + ReadSiparislerData["urunAdi"].ToString() + "' ");

                            // otomatik satın alındı 
                        }
                    }
                }
            }
            CloseConnection();
            NoLoadRefresh();
        }
        //adamın hesabında para varmı ona bakılyır 
    
             //   int siparisDegeri = Convert.ToInt32(ReadSiparislerData["KacParayaAlacak"].ToString()) * Convert.ToInt32(ReadSiparislerData["KacAdetAlacak"].ToString());
        // **************************************************************---FONKSIYONLAR---**************************************************************
        // form içindeki texboxları temizliyen mühendislik harikası kod
        public void Temizle(Control ctr)
        {
            foreach (Control c in ctr.Controls)
            {
                if (c is TextBox box)
                    box.Clear();
                if (c.Controls.Count > 0)
                    Temizle(c);
            }

        }
        private void OpenConnection() => baglanti.Open();// baglantıyı açtırdık
        private void CloseConnection() => baglanti.Close();// bırdada kapattırıyoruz  2 side tek satır ama böylesi daha iyi
        private OleDbDataReader ReadDatabase(string sorgu)// executeReader işlemi burda
        {
            OleDbDataReader ReadData;
            komut = new OleDbCommand(sorgu, baglanti);
            ReadData = komut.ExecuteReader();
            return ReadData;
        }
        private string AddOrUpdateDatabase(string sorgu)// ExecuteNonquery işlemi burda
        {
            komut = new OleDbCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            return "İşlemi Başarılı";
        }
        // final kodları**********************
        // Siparis olusturuluyorrr
        public void MuhasebeHarac(double odenecekMiktar)
        {
            OleDbDataReader ReadData;
            ReadData = ReadDatabase("Select * from Muhasebeci WHERE ad='" + "Ferhat" + "'");
            if (ReadData.Read())
            {
                double x = Convert.ToDouble(ReadData["hesapBakiyesi"].ToString());
                x += odenecekMiktar;
                AddOrUpdateDatabase("update Muhasebeci set hesapBakiyesi='" + x + "' where ad='" + "Ferhat" + "'");
            }
        }
        public void SiparisControl(string urunAdi,string kacadet,string kacpara)// varmı yokmu
        {
            int urunFiyat = 0, urunAdet = 0;
            string saticiAdi = "", barkodNo = "";
            double toplamfiyat = Convert.ToDouble(kacadet) * Convert.ToDouble(kacpara);
            double muhasebeciparasi = toplamfiyat / 100;
            DialogResult eminmisin = MessageBox.Show("Urun Adı : "+urunAdi+"\nUrun Adedi : "+kacadet+"\nUrun Birim Fiyati : "+kacpara+"\nToplam fiyat : "+toplamfiyat.ToString() + "\nMuhasebeci Komisyonu icinde Kesilecek tutar : " + muhasebeciparasi.ToString() + " ₺ dir\n\n\n Uyarı ! : Belirlediğiniz fiyata ürün konana kadar hesabınızdan para çekilmeyecektir", "Siparişi onaylıyormusunuz ?", MessageBoxButtons.YesNo);
            if (eminmisin == DialogResult.Yes)
            {
                // kullanıcının girdigi fiyat tan varmı yokmu kontrol
                OpenConnection();
                OleDbDataReader ReadMinFiyatData = ReadDatabase("Select * from Uruns Where UrunName='" + urunAdi + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
                    if (ReadMinFiyatData.Read())
                    {
                        urunFiyat = Convert.ToInt32(ReadMinFiyatData["UrunFiyati"].ToString());
                        urunAdet = Convert.ToInt32(ReadMinFiyatData["UrunMiktari"].ToString());
                        saticiAdi = ReadMinFiyatData["UrunSatici"].ToString();
                        barkodNo = ReadMinFiyatData["urunBarkodNo"].ToString();
                    }
                CloseConnection();
                if (urunFiyat == 0 || urunAdet == 0)//Bu urunden yok demektir
                {
                    CreateSiparis(urunAdi, kacadet, kacpara);
                    MessageBox.Show("Bu fiyattan ne yazikki stokta kalmamış.\nSiparisiniz olusturuldu belirledidiginiz fiyattan satış olursa\nhesabınızda para varsa satin alma işlemi gerçekleşecektir", "Siparis Olusturulma Basarili !");
                }
                else if (Convert.ToInt32(kacpara) == urunFiyat && Convert.ToInt32(kacadet) <= urunAdet)
                {
                    // istediği ürünler zaten var
                    // satin al
                    UrunSatinAl(barkodNo,saticiAdi,Convert.ToInt32(kacadet),toplamfiyat, "İstediginiz fiyattan istediginiz ürünler var Satın alınıyor", muhasebeciparasi);//alınıyor
                }
                else
                {
                    CreateSiparis(urunAdi,kacadet,kacpara);
                    MessageBox.Show("Siparisiniz olusturuldu belirledidiginiz fiyattan satış olursa\nhesabınızda para varsa satin alma işlemi gerçekleşecektir", "Siparis Olusturulma Basarili !");
                }
                
            }
            else MessageBox.Show("Iptal Edildi", "Iptal Edildi !!");

        }
        public void CreateSiparis(string urunAdi, string kacadet, string kacpara)
        {
            OpenConnection();
            string sorgu = "insert into Siparisler(urunAdi,KacParayaAlacak,KacAdetAlacak,siparisVerenKisi,siparisOlusturulmaTarihi) values('" + urunAdi + "','" + kacpara + "','" + kacadet + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToString()).ToString() + "')";
            AddOrUpdateDatabase(sorgu);
            CloseConnection();
        } 
        
       
     
        //toplam aded çekiliyor
        public int GetUrunToplamAdet(string urunname)
        {
            int toplamurun = 0;
            OleDbDataReader ReadData;
            OpenConnection();
              ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
                while (ReadData.Read())
                 toplamurun += Convert.ToInt32(ReadData["UrunMiktari"].ToString());
            CloseConnection();
            return toplamurun;
        }
        // toplam tutar çekiliyor
        public int GetToplamPara(string urunname, int miktar)
        {
            int toplamPara = 0;

            OleDbDataReader ReadData;
            OpenConnection();
                ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
                while (ReadData.Read())
                {
                int sattigimmiktar;
                    if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) <= miktar)
                    {
                        sattigimmiktar = Convert.ToInt32(ReadData["UrunMiktari"].ToString());
                        miktar -= sattigimmiktar;
                        toplamPara += sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString());
                    }
                    else if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) > miktar && miktar > 0)
                    {
                        sattigimmiktar = miktar;
                        miktar -= sattigimmiktar;
                        toplamPara += sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString());
                    }
                }
            CloseConnection();
            return toplamPara;
        }
        // para current user dan çekiliyor
        public void ParaCek(double toplamfiyat)
        {
            OleDbDataReader ReadData;

            ReadData = ReadDatabase("Select * from Users WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
            {
                double x = Convert.ToDouble(ReadData["hesapBakiye"].ToString());
                x -= toplamfiyat;
                AddOrUpdateDatabase("update Users set hesapBakiye='" + x + "' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            }
        }
        // Belirli kullanıcıdan para çekiliyor
        public void ParaCekWithUserName(double toplamfiyat,string userName)
        {
            OleDbDataReader ReadData;

            ReadData = ReadDatabase("Select * from Users WHERE UserName='" + userName + "'");
            if (ReadData.Read())
            {
                double x = Convert.ToDouble(ReadData["hesapBakiye"].ToString());
                x -= toplamfiyat;
                AddOrUpdateDatabase("update Users set hesapBakiye='" + x + "' where UserName='" + userName + "'");
            }
        }
        // tüm satın alma işlemi
        public void Otosatinal(string urunname, int miktar,double muhasebeTutar)
        {
            int miktar2 = miktar;
            double toplamPara = 0;
            string mesaj = "";
            string urunbirimi = "";

            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            while (ReadData.Read())
            {
                urunbirimi = ReadData["UrunBirimi"].ToString();
                int sattigimmiktar;

                if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) <= miktar && Convert.ToInt32(ReadData["UrunMiktari"].ToString()) > 0)
                {
                    sattigimmiktar = Convert.ToInt32(ReadData["UrunMiktari"].ToString());
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString());
                    ParaCek( sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString()));
                    Satinal(ReadData, sattigimmiktar);

                    mesaj += sattigimmiktar + " " + urunbirimi + " --> Birim fiyati :" + Convert.ToInt32(ReadData["UrunFiyati"].ToString()) + " ₺ --> Toplam Fiyat :" + (sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString())).ToString() + " ₺ den alındı .\n";
                }
                else if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) > miktar && miktar > 0 && Convert.ToInt32(ReadData["UrunMiktari"].ToString()) > 0)
                {
                    sattigimmiktar = miktar;
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString());
                    ParaCek(sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString()));
                    Satinal(ReadData, sattigimmiktar);
                    mesaj += sattigimmiktar + " " + urunbirimi + " --> Birim fiyati :" + Convert.ToInt32(ReadData["UrunFiyati"].ToString()) + " ₺ --> Toplam Fiyat :" + (sattigimmiktar * Convert.ToInt32(ReadData["UrunFiyati"].ToString())).ToString() + " ₺ den alındı .\n";
                }
            }
            ParaCek(muhasebeTutar);//muhasebe tutarı da çekiliyor en son olarak
            MuhasebeHarac(muhasebeTutar);// muhasebeci parası yatırılıyor
            string topMesaj = "Toplamda " + miktar2.ToString() + " " + urunbirimi + " " + urunname + " Aldınız Toplam Fiyat: " + toplamPara.ToString() + " ₺ dir + Muhasebeci Komisyonu icinde Kesilecek tutar : " + muhasebeTutar.ToString()+ " ₺ dir. \n\n";
            string bottomMessage = "Paralar tek tek satıcıların hesabına geçmiştir Teşekürler";
            MessageBox.Show(topMesaj + mesaj + "\n\n" + bottomMessage, "Satin Alma Basarili");
            CloseConnection();
            Refresh();
        }
        // o anki kullanıcıdan satin alınıyor // database eklendi sırada sıralama var
        private void Satinal(OleDbDataReader ReadUrunData, int satismiktari)
        {
            int fiyat = Convert.ToInt32(ReadUrunData["UrunFiyati"].ToString()) * satismiktari;
            string saticiadi = ReadUrunData["UrunSatici"].ToString();

            OleDbDataReader ReadUserData;
            ReadUserData = ReadDatabase("Select * from Users WHERE UserName='" + saticiadi + "'");
            if (ReadUserData.Read())
            {
                int x = Convert.ToInt32(ReadUserData["hesapBakiye"].ToString());
                x += fiyat;
                int urunmiktari = Convert.ToInt32(ReadUrunData["UrunMiktari"].ToString());
                urunmiktari -= satismiktari;
                AddOrUpdateDatabase("update Users set hesapBakiye='" + x + "' where UserName='" + saticiadi + "'");
                AddOrUpdateDatabase("update Uruns set UrunMiktari='" + urunmiktari + "' where urunBarkodNo='" + ReadUrunData["urunBarkodNo"].ToString() + "'");

                //veri tabanına kaydediliyor
                AddOrUpdateDatabase("insert into Satislar(UrunAdi,SatisFiyati,SatisMiktari,UrunBirimi,SatisYapan,SatinAlan,SatisTarihi) values('" + ReadUrunData["UrunName"].ToString() + "','" + ReadUrunData["UrunFiyati"].ToString() + "','" + satismiktari.ToString() + "','" + ReadUrunData["UrunBirimi"].ToString() + "','" + saticiadi + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString() + "')");

            }
        }
        // list box doldurma
        public void ListBoxDoldur(ListBox list)
        {
            list.Items.Clear();
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunOnay='" + "Onaylandı" + "'AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'");
            while (ReadData.Read())
                list.Items.Add(ReadData["UrunName"].ToString());
            CloseConnection();
        }
        // Local Kullanıcı güncelleniyor
        public void Current_user_update(OleDbDataReader ReadUser)
        {
            Singleton.Instance.currentUser.UserID = Convert.ToInt32(ReadUser["UserID"].ToString());
            Singleton.Instance.currentUser.UserName = ReadUser["UserName"].ToString();
            Singleton.Instance.currentUser.UserPass = ReadUser["UserPassword"].ToString();
            Singleton.Instance.currentUser.Ad = ReadUser["ad"].ToString();
            Singleton.Instance.currentUser.SoyAd = ReadUser["soyad"].ToString();
            Singleton.Instance.currentUser.Adres = ReadUser["adres"].ToString();
            Singleton.Instance.currentUser.Eposta = ReadUser["email"].ToString();
            Singleton.Instance.currentUser.Unvan = ReadUser["unvan"].ToString();
            Singleton.Instance.currentUser.BakiyeOnay = ReadUser["bakiyeOnay"].ToString();
            Singleton.Instance.currentUser.Tc = Convert.ToInt64(ReadUser["tcno"].ToString());
            Singleton.Instance.currentUser.Telefon = Convert.ToInt64(ReadUser["telefonno"].ToString());
            Singleton.Instance.currentUser.Bakiye = Convert.ToDouble(ReadUser["hesapBakiye"].ToString());
            Singleton.Instance.currentUser.GeciciBakiye = Convert.ToDouble(ReadUser["geciciBakiye"].ToString());
            Singleton.Instance.currentUser.Cinsiyet = ReadUser["cinsiyet"].ToString();
            Singleton.Instance.currentUser.ParaBirimi = ReadUser["yuklemekistedigiparabirimi"].ToString();
        }
        // Deggistirilen bilgiler tekrar update ediliyor
        public void Refresh()
        {
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Users WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
                 Current_user_update(ReadData);
            CloseConnection();
           
            Singleton.Instance.main.MainScreenOnLoad();
        }
        public void NoLoadRefresh()
        {
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Users WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
                Current_user_update(ReadData);
            CloseConnection();
        }
        // Databaseler tek fonskyion altında güncelleniyor
        public DataTable Showdatabases(string sorgu)
        {
            OleDbDataAdapter da;
            OpenConnection();
            da = new OleDbDataAdapter(sorgu, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            CloseConnection();
            return tablo;
        }
        // Giriş işlemleri burda yapılıyor
        public void KullaniciGirisi(TextBox ad, TextBox parola, Form g)
        {
            OleDbDataReader ReadUserData;
            OpenConnection();
            ReadUserData = ReadDatabase("Select * from Users WHERE UserName='" + ad.Text + "' AND UserPassword='" + parola.Text + "'");
            if (ReadUserData.Read())
            {
                Current_user_update(ReadUserData);
                Temizle(g);
                CloseConnection();
                Singleton.Instance.main.MainScreenOnLoad();
                Singleton.Instance.ChangeScreen(g, Singleton.Instance.main);
            }
            else {
                MessageBox.Show("Giriş Başarısız");
                CloseConnection();
            }            
            CloseConnection();

        }
        public void AdminGirisi(TextBox adminname, TextBox adminpassword, Form g)
        {
            OleDbDataReader ReadAdminData;
            OpenConnection();
                ReadAdminData = ReadDatabase("Select * from Admins WHERE adminName='" + adminname.Text + "' AND adminPassword='" + adminpassword.Text + "'");
            if (ReadAdminData.Read())
            {
                CloseConnection();
                Singleton.Instance.adminForm.ClearTxts();
                Singleton.Instance.adminForm.AdminFormOnLoad();
                Singleton.Instance.ChangeScreen(g, Singleton.Instance.adminForm);
            }
            else {
                CloseConnection();
                MessageBox.Show("Giriş Başarısız");
            } 
           
            Temizle(g);
        }
        // ekleme (INSERT ) islemleri burda ypılıyor
        public void KullaniciEkle(TextBox username, TextBox userpass, TextBox ad, TextBox soyad, TextBox tc, TextBox tel, TextBox adres, TextBox email, string cinsiyet, Form g)
        {

            OleDbDataReader ReadUserData;
            OpenConnection();
            ReadUserData = ReadDatabase("Select * from Users WHERE UserName='" + username.Text + "'");     // kontrol ediyorum daha önce bu username alınmışmı
            if (ReadUserData.Read())
            {
                MessageBox.Show("Bu Username Daha Önce Alınmış");
            }
            else
            {
                AddOrUpdateDatabase("insert into Users(UserName,UserPassword,ad,soyad,tcno,telefonno,adres,email,cinsiyet) values('" + username.Text + "','" + userpass.Text + "','" + ad.Text + "','" + soyad.Text + "','" + tc.Text + "','" + tel.Text + "','" + adres.Text + "','" + email.Text + "','" + cinsiyet + "')");
                MessageBox.Show("Başarılı Bir şekilde üye oldunuz", "Üye Olma Başarılı");
                Temizle(g);
            }
            CloseConnection();
        }
        public void UrunEkle(TextBox urunbarkodno, ComboBox urunbirimi, TextBox urunfiyati, TextBox urunmiktari, TextBox urunname, TextBox urunturu, string UrunSatici, GroupBox g)
        {
            OleDbDataReader ReadUrunData;
            if (urunbarkodno.Text == "" || urunbirimi.Text == "" || urunfiyati.Text == "" || urunmiktari.Text == "" || urunname.Text == "" || urunturu.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
            else
            {
                OpenConnection();
                ReadUrunData = ReadDatabase("Select * from Uruns WHERE urunBarkodNo='" + urunbarkodno.Text + "'");// kontrol ediyorum daha önce bu barkod alınmışmı
                if (ReadUrunData.Read())MessageBox.Show("Bu Barkod Daha Önce Alınmış");
                else
                {
                    AddOrUpdateDatabase("insert into Uruns(UrunName,UrunMiktari,UrunFiyati,UrunTuru,UrunSatici,urunOnay,urunBirimi,urunBarkodNo) values('" + urunname.Text + "','" + Convert.ToInt32(urunmiktari.Text) + "','" + Convert.ToInt32(urunfiyati.Text) + "','" + urunturu.Text + "','" + UrunSatici + "','" + "Onaylanmadı" + "','" + urunbirimi.Text + "','" + urunbarkodno.Text + "')");
                    Temizle(g);
                }
                CloseConnection();
            }
        }

        //update işlemleri
        private void AccessUpdateIslemleri(string sorgu)//Sürekli kullanılan update komutu giderildi!!
        {
            OpenConnection();
            AddOrUpdateDatabase(sorgu);
            CloseConnection();
        }
        public void GecicibakiyeGuncelle(double gecicibakiye,string kullaniciParaBirimi)
        {
            string sorgu = ("update Users set geciciBakiye='" + gecicibakiye + "' ,bakiyeOnay='" + "Onaylanmadı" + "', yuklemekistedigiparabirimi='"+kullaniciParaBirimi+"',sonparayuklemetarihi='"+ DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString()+"' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            AccessUpdateIslemleri(sorgu);
            MessageBox.Show("Bakiye yükleme işlemi tamamlandı,admin onayı bekleniyor");
            Refresh();
        }
        public void BakiyeOnay(string username, double guncelbakiye)
        {
            string sorgu = ("update Users set geciciBakiye='" + 0 + "' ,hesapBakiye='" + guncelbakiye + "',bakiyeOnay='" + "Onaylandı" + "' where UserName='" + username + "'");
            AccessUpdateIslemleri(sorgu);
        }

        public void UserUpdate(TextBox userpass, TextBox email, TextBox adres, TextBox telefonno)
        {
            string sorgu = ("update Users set UserPassword='" + userpass.Text + "' ,email='" + email.Text + "',adres='" + adres.Text + "',telefonno='" + telefonno.Text + "' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            AccessUpdateIslemleri(sorgu);
            Refresh();
        }
        public void UrunUpdate(TextBox urunfiyati, TextBox urunmiktari, string urunbarkod, GroupBox g)
        {
            string sorgu = ("update Uruns set urunMiktari='" + Convert.ToInt32(urunmiktari.Text) + "' ,urunFiyati='" + Convert.ToInt32(urunfiyati.Text) + "',urunOnay='" + "Onaylanmadı" + "' where urunBarkodNo='" + urunbarkod + "'");
            AccessUpdateIslemleri(sorgu);
            Temizle(g);
        }
        public void UrunOnay(string barkodno)
        {
            string sorgu = ("update Uruns set urunOnay='" + "Onaylandı" + "' where urunBarkodNo='" + barkodno + "'");
            AccessUpdateIslemleri(sorgu);
        }

        // urun satin alma işlemi burda yapılıyor
        public void UrunSatinAl(string barkodno, string urunsatici, int kacadet, double toplamfiyat, string mesaj,double muhasebeciTutar)
        {
            // işlem 1 para hesaptan çekiliyor
            OpenConnection();
             ParaCek(toplamfiyat+muhasebeciTutar);
            CloseConnection();

            //işlem 2 para satıcın hesabına geçiyor
            OpenConnection();
            OleDbDataReader ReadUserData;
            ReadUserData = ReadDatabase("Select * from Users WHERE UserName='" + urunsatici + "'");
            if (ReadUserData.Read())
            {
                double newBakiye = Convert.ToInt32(ReadUserData["hesapBakiye"].ToString());
                newBakiye += toplamfiyat;
                AddOrUpdateDatabase("update Users set hesapBakiye='" + newBakiye + "' where UserName='" + urunsatici + "'");           
            }
            CloseConnection();

            //işlem 3 urun adeti azaltılıyor
            OpenConnection();
            OleDbDataReader ReadUrunData;
            ReadUrunData = ReadDatabase("Select * from Uruns WHERE urunBarkodNo='" + barkodno + "'");
            if (ReadUrunData.Read())
            {
                int newAdetSayisi = Convert.ToInt32(ReadUrunData["UrunMiktari"].ToString());
                newAdetSayisi -= kacadet;
                AddOrUpdateDatabase("update Uruns set UrunMiktari='" + newAdetSayisi + "' where urunBarkodNo='" + barkodno + "'");

               // satis veri tabanına kaydediliyor
                AddOrUpdateDatabase("insert into Satislar(UrunAdi,SatisFiyati,SatisMiktari,UrunBirimi,SatisYapan,SatinAlan,SatisTarihi) values('" + ReadUrunData["UrunName"].ToString() + "','" + ReadUrunData["UrunFiyati"].ToString() + "','" + kacadet.ToString() + "','" + ReadUrunData["UrunBirimi"].ToString() + "','" + urunsatici + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString() + "')");
            }
            CloseConnection();
          
            OpenConnection();
                
            CloseConnection();
            MessageBox.Show(mesaj, "Satın Alma İşlemi Onaylanı");
            Refresh();

        }


    }
}

