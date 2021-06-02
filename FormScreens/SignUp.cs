using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsaProjesi
{
    public partial class SignUp : Form
    {

        public SignUp()
        {
            InitializeComponent();
        }

        private void Kullanici_ekle_btn_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";

            if (username_txt.Text == "" || password_txt.Text == "" || adres_txt.Text == "" || ad_txt.Text == "" || soyad_txt.Text == "" || tc_txt.Text == "" || telefon_txt.Text == "" || adres_txt.Text == "" || email_txt.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurun");
            else if (SayiMi(tc_txt.Text) == false)
                MessageBox.Show("Lütfen Geçerli Tc No Giriniz");
            else if (SayiMi(telefon_txt.Text) == false)
                MessageBox.Show("Lütfen Geçerli Telefon Numarası giriniz");
            else if (password_txt.Text == passagain_txt.Text)
            {
                if (erkek_radio.Checked == true)
                    cinsiyet = "Erkek";
                if (kadi_radio.Checked == true)
                    cinsiyet = "Kadın";
                Singleton.Instance.islem.KullaniciEkle(username_txt, password_txt, ad_txt, soyad_txt, tc_txt, telefon_txt, adres_txt, email_txt, cinsiyet,this);

            }
            else
                MessageBox.Show("Şifreler uyuşmuyor", "Hata");
        }

        private void Cikis_btn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Singleton.Instance.login.Show();


        }
        static bool SayiMi(string deger)
        {
            try
            {
                long.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
