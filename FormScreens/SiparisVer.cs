using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsaProjesi.FormScreens
{
    public partial class SiparisVer : Form
    {
        public SiparisVer()
        {
            InitializeComponent();
        }

        private void Cikis_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.main.MainScreenOnLoad();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.main);
        }

        private void SiparisVer_Load(object sender, EventArgs e)
        {
            SiparisVerOnLoad();         
        }
        public void SiparisVerOnLoad()
        {
            TxtBoxTemizle();
        }
        private void TxtBoxTemizle()
        {
            hesap_bakiyesi_label.Text ="Hesap Bakiyem : "+ Singleton.Instance.currentUser.Bakiye.ToString();
            kacadet_txt.Text = "";
            kactl_txt.Text = "";
            urun_adi_txt.Text = "";
        }
        private void Siparis_ver_btn_Click(object sender, EventArgs e)
        {
          
            try
            {
                double toplamtutar = Convert.ToDouble(kacadet_txt.Text) * Convert.ToDouble(kactl_txt.Text);
                double muhasebeciParasi = toplamtutar / 100;
                double olmasiGerekenBakiye = toplamtutar + muhasebeciParasi;

                if (olmasiGerekenBakiye <= Singleton.Instance.currentUser.Bakiye)
                    Singleton.Instance.islem.SiparisControl(urun_adi_txt.Text, kacadet_txt.Text, kactl_txt.Text);
                else
                    MessageBox.Show("Bakiye Yetersiz");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: "+ex.ToString());
            }         
            TxtBoxTemizle();
        }

        private void Siparislerim_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.listeleSiparisler.SiparislerimListeleOnLoad();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.listeleSiparisler);
        }
    }
}
