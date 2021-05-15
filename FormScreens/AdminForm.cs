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
    public partial class AdminForm : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ataka\\Desktop\\borsaProjesi\\database\\borsadatabase.accdb");

        private string sorgu = "";
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.ReadOnly = true;
            secenekler_combobox.Text = "Tüm Kullanıcılar";
            urunler_combobox.Text = "Tüm Ürünler";
            sorgu = "SELECT * FROM Sorgu2 ";
            dataGridView1.DataSource = Singleton.Instance.islem.showdatabases(sorgu, baglanti);
            sorgu = "SELECT * FROM showUruns ";
            dataGridView2.DataSource = Singleton.Instance.islem.showdatabases(sorgu, baglanti);
        }



        private void search_btn_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void listele()
        {
            clearTxts();
            baslik_label.Text = secenekler_combobox.Text;
            if (secenekler_combobox.Text == "Onay Bekleyen Bakiyeler")
                sorgu = "SELECT * FROM Sorgu2 WHERE bakiyeOnay='" + "Onaylanmadı" + "'";
            if (secenekler_combobox.Text == "Tüm Kullanıcılar")
                sorgu = "SELECT * FROM Sorgu2 ";
            dataGridView1.DataSource = Singleton.Instance.islem.showdatabases(sorgu, baglanti);
        }
     

        private void onayla_btn_Click(object sender, EventArgs e)
        {
            if (bakiyeonay_label.Text == "Onaylanmadı")
            {
                DialogResult dialogResult = MessageBox.Show("Bakiyeyi Onaylamak istediğinize eminmisiniz ?", "Bakiye Onaylansın mı ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //yes
                    int bakiye = Convert.ToInt32(hesapbakiyelabel.Text);
                    int artismiktari = Convert.ToInt32(gecicibakiye_label.Text);
                    bakiye += artismiktari;
                    Singleton.Instance.islem.BakiyeOnay(username_txt.Text, bakiye);                  
                    MessageBox.Show("Bakiye onaylama işlemi tamamlandı.", "Bakiye Onay");
                    listele();
                }
            }
            else if (bakiyeonay_label.Text == "Onaylandı")
            {
                MessageBox.Show("Seçtiğiniz kullanıcının bakiyesi zaten onaylanmış", "****");
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz", "****");
            }
          
        }

      
        public void clearTxts()
        {
            hesapbakiyelabel.Text = "";
            gecicibakiye_label.Text = "";
            bakiyeonay_label.Text = "";
            username_txt.Text = "";
        }

        private void urunlerlistele_btn_Click(object sender, EventArgs e)
        {
            uListele();        
        }
        private void uListele()
        {
            urunkodu_lbl.Text = "";
            onaycontrol_label.Text = ""; 

            tumurunler_label.Text = urunler_combobox.Text;
            if (urunler_combobox.Text == "Tüm Ürünler")
                sorgu = "SELECT * FROM showUruns";
            if (urunler_combobox.Text == "Onaylanan Ürünler")
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "'";
            if (urunler_combobox.Text == "Onay Bekleyen Ürünler")
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylanmadı" + "'";
            dataGridView2.DataSource = Singleton.Instance.islem.showdatabases(sorgu, baglanti);

        }
        private void urunonayla_btn_Click(object sender, EventArgs e)
        {
            if (onaycontrol_label.Text == "Onaylanmadı")
            {
                DialogResult dialogResult = MessageBox.Show("Urun Onaylamak istediğinize eminmisiniz ?", "Urun Onaylansın mı ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
          
                    Singleton.Instance.islem.UrunOnay(urunkodu_lbl.Text);
                    uListele();
                   
                    MessageBox.Show("Urun onaylama işlemi tamamlandı.", "Kullanıcı Onay");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //no

                }
            }
            else if (onaycontrol_label.Text == "Onaylandı")
            {
                MessageBox.Show("Seçtiğiniz kullanıcı zaten onaylanmış.", "****");
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün  seçiniz.", "****");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            onaycontrol_label.Text = dataGridView2.Rows[e.RowIndex].Cells["urunOnay"].FormattedValue.ToString();
            urunkodu_lbl.Text = dataGridView2.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();


        }

    
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            

                username_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                hesapbakiyelabel.Text = dataGridView1.Rows[e.RowIndex].Cells["hesapBakiye"].FormattedValue.ToString();
                gecicibakiye_label.Text = dataGridView1.Rows[e.RowIndex].Cells["geciciBakiye"].FormattedValue.ToString();         
                bakiyeonay_label.Text = dataGridView1.Rows[e.RowIndex].Cells["bakiyeOnay"].FormattedValue.ToString();

            


        }

        private void btn_gerii_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.login.temizle();
            Singleton.Instance.login.Show();
        }

        
    }
}
