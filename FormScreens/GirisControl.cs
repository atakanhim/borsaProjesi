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
    public partial class GirisControl : Form
    {
        public GirisControl()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e) => Singleton.Instance.ExitTheApplication();

        private void Admin_Click(object sender, EventArgs e) => Singleton.Instance.ChangeScreen(this,Singleton.Instance.admingiris);
        private void User_Click(object sender, EventArgs e) => Singleton.Instance.ChangeScreen(this, Singleton.Instance.login);

    }
}
