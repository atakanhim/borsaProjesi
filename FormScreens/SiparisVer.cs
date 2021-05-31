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
            Singleton.Instance.islem.SiparisOlustur(urun_adi_txt.Text, kacadet_txt.Text, kactl_txt.Text);
            TxtBoxTemizle();
        }
    }
}
