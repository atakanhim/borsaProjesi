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

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.admingiris.Show();
        }

        private void user_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.login.Show();
        }
    }
}
