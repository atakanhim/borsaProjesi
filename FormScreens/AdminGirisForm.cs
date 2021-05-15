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
    public partial class AdminGirisForm : Form
    {
        public AdminGirisForm()
        {
            InitializeComponent();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.girisctr.Show();
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.islem.AdminGirisi(username_admin,password_admin,this);
           
        }
       
    }
}
