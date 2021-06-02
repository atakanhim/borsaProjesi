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
    public partial class SiparislerimListele : Form
    {
        public SiparislerimListele()
        {
            InitializeComponent();
        }

        private void Cikis_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.main);
        }

        private void SiparislerimListele_Load(object sender, EventArgs e)
        {
            SiparislerimListeleOnLoad();
        }
        public void SiparislerimListeleOnLoad()
        {
            Siparislistele_datagird.DataSource = null;
        }

        private void Aktifsip_listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from Siparisler Where siparisDurumu='" + "Aranıyor" + "'";
            Siparislistele_datagird.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }

        private void Tamamsip_listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from Siparisler Where siparisDurumu='" + "Satin alindi" + "'";
            Siparislistele_datagird.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }
       
    }
}
