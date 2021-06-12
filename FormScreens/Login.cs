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


namespace borsaProjesi
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Giris_yap_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.islem.KullaniciGirisi(kadi_txt, password_txt, this);
        } 

        private void Sign_up_btn_Click(object sender, EventArgs e) => Singleton.Instance.ChangeScreen(this, Singleton.Instance.signUp);
        private void Geri_btn_Click(object sender, EventArgs e) => Singleton.Instance.ChangeScreen(this, Singleton.Instance.girisctr);
        public void LoginArayüzTemizle() => Singleton.Instance.islem.Temizle(this);
        private void Login_Load(object sender, EventArgs e) => LoginArayüzTemizle();
    }
}
