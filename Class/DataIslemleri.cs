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

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ataka\\Desktop\\borsaProjesi\\database\\borsadatabase.accdb");
        OleDbCommand komut;
        
        // **************************************************************---FONKSIYONLAR---**************************************************************
        // form içindeki texboxları temizliyen mühendislik harikası kod.
        public void Temizle(Control ctr)
        {
            foreach (Control c in ctr.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                if (c.Controls.Count > 0)
                    Temizle(c);
            }

        }
        //toplam aded çekiliyor
        public int getUrunToplamAdet(string urunname)
        {
            int toplamurun = 0;
            OleDbDataReader oku;
                baglanti.Open();
                komut = new OleDbCommand();
                komut.Connection = baglanti;
            komut.CommandText = ("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            oku = komut.ExecuteReader();
                while(oku.Read())
                {
                  toplamurun += Convert.ToInt32(oku["UrunMiktari"].ToString());
                }
            baglanti.Close();
            return toplamurun;
        }
        // toplam tutar çekiliyor
        public int getToplamPara(string urunname,int miktar)
        {
            int toplamPara = 0;
           
            OleDbDataReader oku;
            baglanti.Open();
                komut = new OleDbCommand();
                komut.Connection = baglanti;
            komut.CommandText = ("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            oku = komut.ExecuteReader();
                while (oku.Read())
                {
                     int sattigimmiktar = 0;
                       if (Convert.ToInt32(oku["UrunMiktari"].ToString()) <= miktar)
                          {
                           sattigimmiktar = Convert.ToInt32(oku["UrunMiktari"].ToString());
                            miktar -= sattigimmiktar;
                             toplamPara += sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString());
                          }
                        else if (Convert.ToInt32(oku["UrunMiktari"].ToString()) > miktar && miktar>0)
                        {
                            sattigimmiktar =miktar;
                            miktar -= sattigimmiktar;
                            toplamPara += sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString());
                         }                                   
                 }
           
            baglanti.Close();
            return toplamPara;
        }
        // para current user dan çekiliyor
        public void paraCek(int toplamfiyat)
        {
           
            OleDbDataReader oku;
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Users WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                int x = Convert.ToInt32(oku["hesapBakiye"].ToString());
                x -= toplamfiyat;
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("update Users set hesapBakiye='" + x + "' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
                komut.ExecuteNonQuery();

            }
        }
        // tüm satın alma işlemi
        public void Otosatinal(string urunname, int miktar)
        {
            int miktar2 = miktar;
            int toplamPara = 0;
            string mesaj = "";    
            string urunbirimi = "";

            OleDbDataReader oku;
            baglanti.Open();
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
               urunbirimi= oku["UrunBirimi"].ToString();
                int sattigimmiktar;

                if (Convert.ToInt32(oku["UrunMiktari"].ToString()) <= miktar && Convert.ToInt32(oku["UrunMiktari"].ToString())>0)
                {
                    sattigimmiktar = Convert.ToInt32(oku["UrunMiktari"].ToString());
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString());
                    paraCek(sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString()));
                    satinal(oku, sattigimmiktar);

                    mesaj += sattigimmiktar + " " + urunbirimi + " --> Birim fiyati :"+ Convert.ToInt32(oku["UrunFiyati"].ToString()) + " ₺ --> Toplam Fiyat :" +  (sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString())).ToString() + " ₺ den alındı .\n";
                }
                else if (Convert.ToInt32(oku["UrunMiktari"].ToString()) > miktar && miktar > 0 && Convert.ToInt32(oku["UrunMiktari"].ToString()) > 0)
                {
                    sattigimmiktar = miktar;
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString());
                    paraCek(sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString()));
                    satinal(oku, sattigimmiktar);

                    mesaj += sattigimmiktar + " " + urunbirimi + " --> Birim fiyati :" + Convert.ToInt32(oku["UrunFiyati"].ToString()) + " ₺ --> Toplam Fiyat :" + (sattigimmiktar * Convert.ToInt32(oku["UrunFiyati"].ToString())).ToString() + " ₺ den alındı .\n";
                }


            }
            string topMesaj = "Toplamda " + miktar2.ToString() + " " + urunbirimi + " " + urunname + " Aldınız Toplam Fiyat: " + toplamPara.ToString() + " ₺ dir. \n\n";
            string bottomMessage = "Paralar tek tek satıcıların hesabına geçmiştir Teşekürler";
            MessageBox.Show(topMesaj + mesaj +"\n\n"+bottomMessage,"Satin Alma Basarili");
            baglanti.Close();
            Refresh();
        }
        // o anki kullanıcıdan satin alınıyor
        private void satinal(OleDbDataReader oku,int satismiktari)
        {
            int fiyat = Convert.ToInt32(oku["UrunFiyati"].ToString()) * satismiktari;
            string saticiadi = oku["UrunSatici"].ToString();

            OleDbDataReader oku2;
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Users WHERE UserName='" + saticiadi + "'");
            oku2 = komut.ExecuteReader();
            if (oku2.Read())
            {
                int x = Convert.ToInt32(oku2["hesapBakiye"].ToString());
                x += fiyat;
                int urunmiktari = Convert.ToInt32(oku["UrunMiktari"].ToString());
                urunmiktari -= satismiktari;
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("update Users set hesapBakiye='" + x + "' where UserName='" + saticiadi + "'");
                komut.ExecuteNonQuery();

                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("update Uruns set UrunMiktari='" + urunmiktari + "' where urunBarkodNo='" + oku["urunBarkodNo"].ToString() + "'");
                komut.ExecuteNonQuery();
            }
        }
        // list box doldurma
        public void listBoxDoldur(ListBox list)
        {
            list.Items.Clear();
            OleDbDataReader oku;
            baglanti.Open();
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select * from Uruns Where UrunOnay='"+"Onaylandı"+ "'AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'");
                oku = komut.ExecuteReader();
                while (oku.Read())
                list.Items.Add(oku["UrunName"].ToString());
                
            baglanti.Close();
        }
        // Local Kullanıcı güncelleniyor
        public void Current_user_update(OleDbDataReader oku)
        {
            Singleton.Instance.currentUser.UserID = Convert.ToInt32(oku["UserID"].ToString());
            Singleton.Instance.currentUser.UserName = oku["UserName"].ToString();
            Singleton.Instance.currentUser.UserPass = oku["UserPassword"].ToString();
            Singleton.Instance.currentUser.Ad = oku["ad"].ToString();
            Singleton.Instance.currentUser.SoyAd = oku["soyad"].ToString();
            Singleton.Instance.currentUser.Adres = oku["adres"].ToString();
            Singleton.Instance.currentUser.Eposta = oku["email"].ToString();
            Singleton.Instance.currentUser.Unvan = oku["unvan"].ToString();
            
            Singleton.Instance.currentUser.bakiyeOnay = oku["bakiyeOnay"].ToString();
            Singleton.Instance.currentUser.Tc = Convert.ToInt64(oku["tcno"].ToString());
            Singleton.Instance.currentUser.Telefon = Convert.ToInt64(oku["telefonno"].ToString());
            Singleton.Instance.currentUser.Bakiye = Convert.ToDouble(oku["hesapBakiye"].ToString());
            Singleton.Instance.currentUser.geciciBakiye = Convert.ToDouble(oku["geciciBakiye"].ToString());
            Singleton.Instance.currentUser.cinsiyet = oku["cinsiyet"].ToString();
        }
        // Deggistirilen bilgiler tekrar update ediliyor
        public void Refresh()
        {
            OleDbDataReader oku;
            baglanti.Open();
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Users WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Current_user_update(oku);
                Singleton.Instance.main.UpdateLabelTexts();
            }
            baglanti.Close();
        }
        // Databaseler tek fonskyion altında güncelleniyor
        public DataTable showdatabases(string sorgu, OleDbConnection baglanti)
        {
            OleDbDataAdapter da;
            baglanti.Open();
            da = new OleDbDataAdapter(sorgu, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        // Giriş işlemleri burda yapılıyor
        public void KullaniciGirisi(TextBox ad, TextBox parola,Form g)
        {
          
            OleDbDataReader oku;
            baglanti.Open();
                  komut= new OleDbCommand();
                  komut.Connection = baglanti;
                  komut.CommandText = ("Select * from Users WHERE UserName='" + ad.Text + "' AND UserPassword='" + parola.Text + "'");
                  oku = komut.ExecuteReader();
            if (oku.Read())
            {
              
                    Current_user_update(oku);
                    Temizle(g);
                    Singleton.Instance.login.Hide();
                    Singleton.Instance.main.UpdateLabelTexts();
                    Singleton.Instance.main.Show();
                
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
              
            };

            baglanti.Close();
          
        }
        public void AdminGirisi(TextBox adminname, TextBox adminpassword, Form g)
        {
            OleDbDataReader oku;
            baglanti.Open();
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Admins WHERE adminName='" + adminname.Text + "' AND adminPassword='" + adminpassword.Text + "'");
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                    
                    MessageBox.Show("Giriş Başarılı Hoşgeldiniz");
                Singleton.Instance.admingiris.Hide();
                Singleton.Instance.adminForm.Show();
                
            }
            else
                MessageBox.Show("Giriş Başarısız");
            baglanti.Close();
            Temizle(g);
        }
        // ekleme (INSERT ) islemleri burda ypılıyor
        public void KullaniciEkle(TextBox username, TextBox userpass, TextBox ad, TextBox soyad, TextBox tc, TextBox tel, TextBox adres, TextBox email, string cinsiyet, Form g)
        {
           
            OleDbDataReader oku;
          
            
                baglanti.Open();

                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select * from Users WHERE UserName='" + username.Text + "'"); // kontrol ediyorum daha önce bu username alınmışmı
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu Username Daha Önce Alınmış");
                }
                else
                {
                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = ("insert into Users(UserName,UserPassword,ad,soyad,tcno,telefonno,adres,email,cinsiyet) values('" + username.Text + "','" + userpass.Text + "','" + ad.Text + "','" + soyad.Text + "','" + tc.Text + "','" + tel.Text + "','" + adres.Text + "','" + email.Text + "','"+cinsiyet+"')");
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Başarılı Bir şekilde üye oldunuz","Üye Olma Başarılı");
                      Temizle(g);
                 }

                baglanti.Close();

            

        }
        public void UrunEkle(TextBox urunbarkodno, ComboBox urunbirimi, TextBox urunfiyati, TextBox urunmiktari, TextBox urunname, TextBox urunturu, string UrunSatici, GroupBox g)
        {
            OleDbDataReader oku;
            if (urunbarkodno.Text == "" || urunbirimi.Text == "" || urunfiyati.Text == "" || urunmiktari.Text == "" || urunname.Text == "" || urunturu.Text == "" )
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
            else
            {
                baglanti.Open();

                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = ("Select * from Uruns WHERE urunBarkodNo='" + urunbarkodno.Text + "'"); // kontrol ediyorum daha önce bu username alınmışmı
                    oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Bu Barkod Daha Önce Alınmış");
                    }
                    else
                    {
                        komut = new OleDbCommand();
                        komut.Connection = baglanti;
                        komut.CommandText = ("insert into Uruns(UrunName,UrunMiktari,UrunFiyati,UrunTuru,UrunSatici,urunOnay,urunBirimi,urunBarkodNo) values('" + urunname.Text + "','" + Convert.ToInt32(urunmiktari.Text) + "','" + Convert.ToInt32(urunfiyati.Text) + "','" + urunturu.Text + "','" + UrunSatici + "','" + "Onaylanmadı" + "','" + urunbirimi.Text + "','" + urunbarkodno.Text + "')");
                        komut.ExecuteNonQuery();
                    Temizle(g);
                }

                baglanti.Close();
            }
          
        }




        //update işlemleri
        private void AccessUpdateIslemleri(string sorgu)//Sürekli kullanılan update komutu giderildi!!
        {
            baglanti.Open();
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = sorgu;
                komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void GecicibakiyeGuncelle(int gecicibakiye)
        {
            string sorgu = ("update Users set geciciBakiye='" + gecicibakiye + "' ,bakiyeOnay='" + "Onaylanmadı" + "'where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            AccessUpdateIslemleri(sorgu);
            MessageBox.Show("Bakiye yükleme işlemi tamamlandı,admin onayı bekleniyor");
            Refresh();
        }
        public void BakiyeOnay(string username, int guncelbakiye)
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
        public void UrunSatinAl(string barkodno, string urunsatici, int kacadet, int toplamfiyat, string mesaj)
        {
            // işlem 1 para hesaptan çekiliyor
            baglanti.Open();
            paraCek(toplamfiyat);
            baglanti.Close();



            //işlem 2 para satıcın hesabına geçiyor
            baglanti.Open();
            OleDbDataReader oku2;
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Users WHERE UserName='" + urunsatici + "'");
            oku2 = komut.ExecuteReader();
            if (oku2.Read())
            {
                int x = Convert.ToInt32(oku2["hesapBakiye"].ToString());
                x += toplamfiyat;
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("update Users set hesapBakiye='" + x + "' where UserName='" + urunsatici + "'");
                komut.ExecuteNonQuery();

            }


            baglanti.Close();
            //işlem 3 urun adeti azaltılıyor
            baglanti.Open();

            OleDbDataReader oku3;
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from Uruns WHERE urunBarkodNo='" + barkodno + "'");
            oku3 = komut.ExecuteReader();
            if (oku3.Read())
            {
                int x = Convert.ToInt32(oku3["UrunMiktari"].ToString());
                x -= kacadet;
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("update Uruns set UrunMiktari='" + x + "' where urunBarkodNo='" + barkodno + "'");
                komut.ExecuteNonQuery();
            }
            baglanti.Close();
            MessageBox.Show(mesaj, "Satın Alma İşlemi Onaylanı");
            Refresh();

        }


    }
}

