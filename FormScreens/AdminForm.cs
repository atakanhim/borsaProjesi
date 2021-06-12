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
using System.Xml;

namespace borsaProjesi
{
    public partial class AdminForm : Form
    {
        private string sorgu = "";
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Kullanicilar_datagridview.ColumnHeadersVisible = false;
            Kullanicilar_datagridview.ReadOnly = true;
            Urunler_datagridview.ColumnHeadersVisible = false;
            Urunler_datagridview.ReadOnly = true;
            AdminFormOnLoad();
        }
        public void AdminFormOnLoad()
        {
            Kullanicikontrol_tarih_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih anasayfa
            Tarihurunkontrol_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih profilim

            SeceneklercomboDoldur();
            UrunlerComboDoldur();
            ClearTxts();
        }
        private void SeceneklercomboDoldur()
        {
            secenekler_combobox.Items.Clear();
            secenekler_combobox.Text="Tüm Kullanıcılar";
            secenekler_combobox.Items.Add("Tüm Kullanıcılar");
            secenekler_combobox.Items.Add("Onay Bekleyen Bakiyeler");

            sorgu = "SELECT * FROM Sorgu2 ";
            Kullanicilar_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }
        private void UrunlerComboDoldur()
        {    
            urunler_combobox.Items.Clear();
            urunler_combobox.Text = "Tüm Ürünler";
            urunler_combobox.Items.Add("Tüm Ürünler");
            urunler_combobox.Items.Add("Onaylanan Ürünler");
            urunler_combobox.Items.Add("Onay Bekleyen Ürünler");

            sorgu = "SELECT * FROM showUruns ";
            Urunler_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            ClearTxts();
         
            baslik_label.Text = secenekler_combobox.Text;
            if (secenekler_combobox.Text == "Onay Bekleyen Bakiyeler")
                sorgu = "SELECT * FROM Sorgu2 WHERE bakiyeOnay='" + "Onaylanmadı" + "'";
            if (secenekler_combobox.Text == "Tüm Kullanıcılar" || secenekler_combobox.Text=="")
               sorgu = "SELECT * FROM Sorgu2 ";
           
            Kullanicilar_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }
     

        private void Onayla_btn_Click(object sender, EventArgs e)
        {
            if (bakiyeonay_label.Text == "Onaylanmadı" && parabirimi_label.Text=="TL")
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
                    secenekler_combobox.Text = "Tüm Kullanıcılar";
                    Listele();
                }
            }
            else if (bakiyeonay_label.Text == "Onaylandı")
            {
                MessageBox.Show("Seçtiğiniz kullanıcının bakiyesi zaten onaylanmış", "Zeten onaylanmış");
            }
            else if (parabirimi_label.Text != "TL")
            {
                MessageBox.Show("Lütfen ilk önce paranızı Türk Parasına Çeviriniz (TL)", "Para birimi hatası");
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz", "Kullanıcı seçilmedi");
            }
          
        }

      
        public void ClearTxts()
        {
            hesapbakiyelabel.Text = "";
            gecicibakiye_label.Text = "";
            bakiyeonay_label.Text = "";
            username_txt.Text = "";
            parabirimi_label.Text = "";
            ParaBirimiVisibleControl(false);
        }

        private void Urunlerlistele_btn_Click(object sender, EventArgs e)
        {
            UrunListele();
        }
        private void UrunListele()
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
            Urunler_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

        }
        private void Urunonayla_btn_Click(object sender, EventArgs e)
        {
            if (onaycontrol_label.Text == "Onaylanmadı")
            {
                DialogResult dialogResult = MessageBox.Show("Urun Onaylamak istediğinize eminmisiniz ?", "Urun Onaylansın mı ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Singleton.Instance.islem.UrunOnay(urunkodu_lbl.Text);
                    UrunListele();
                    MessageBox.Show("Urun onaylama işlemi tamamlandı.", "Kullanıcı Onay");
                }
                else if (dialogResult == DialogResult.No) MessageBox.Show("Urun onaylama işlemi tamamlandı.", "Kullanıcı Onay");
            }
            else if (onaycontrol_label.Text == "Onaylandı")MessageBox.Show("Seçtiğiniz kullanıcı zaten onaylanmış.", "****");         
            else MessageBox.Show("Lütfen bir ürün  seçiniz.", "****");       
        }

        private void Btn_gerii_Click(object sender, EventArgs e)
        {
            Singleton.Instance.login.LoginArayüzTemizle();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.girisctr);  
        }

        private void Kullanicilar_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Kullanicilar_datagridview.CurrentRow.Selected = true;
            username_txt.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
            hesapbakiyelabel.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["hesapBakiye"].FormattedValue.ToString();
           gecicibakiye_label.Text =  Kullanicilar_datagridview.Rows[e.RowIndex].Cells["geciciBakiye"].FormattedValue.ToString();
            bakiyeonay_label.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["bakiyeOnay"].FormattedValue.ToString();  
            parabirimi_label.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["yuklemekistedigiparabirimi"].FormattedValue.ToString();

            if (Convert.ToInt32(Kullanicilar_datagridview.Rows[e.RowIndex].Cells["geciciBakiye"].FormattedValue.ToString()) > 0) ParaBirimiVisibleControl(true);
            else ParaBirimiVisibleControl(false);




        }
        private void ParaBirimiVisibleControl(bool deger)
        {
            if (deger)
            {
                parabirimibaslik.Visible = true;
                parabirimi_label.Visible = true;
                exchange_rate_btn.Visible = true;
            }
            else
            {
                parabirimi_label.Visible = false;
                parabirimibaslik.Visible = false;
                exchange_rate_btn.Visible = false;
            }
        }

        private void Urunler_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Urunler_datagridview.CurrentRow.Selected = true;
            onaycontrol_label.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunOnay"].FormattedValue.ToString();
            urunkodu_lbl.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();
        }

        private void Exchange_rate_btn_Click(object sender, EventArgs e)
        {
            // burdan para dönüştürülcekkk o kadar
            try { 
                if(parabirimi_label.Text != "TL")
                {                  
                    // url olsuturuyoruz ve veriyi ceikyior
                    string url= "https://www.tcmb.gov.tr/kurlar/today.xml";
                    var xml = new XmlDocument();
                    xml.Load(url);
                    DateTime tarih = Convert.ToDateTime(xml.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
                    string conversionRate = xml.SelectSingleNode("Tarih_Date/Currency [@Kod='"+ parabirimi_label.Text +"']/BanknoteSelling").InnerXml;
                    // ardından yeni gecicibakiyeyiolusturuyoruz
                    double onayBekleyenHesapBakiyesi = Convert.ToDouble(gecicibakiye_label.Text);       
                    double virgulluakiye = onayBekleyenHesapBakiyesi * Convert.ToDouble(conversionRate.Replace(".",","));
                    double newBekleyenBakiye = Math.Round(virgulluakiye, 2);
                    // veri tabanından degistiriyoruz verileri
                    Singleton.Instance.islem.GeciciBakiyeDegistirWithUsurname(username_txt.Text, newBekleyenBakiye);                  
                    MessageBox.Show(tarih.ToShortDateString() + " Tarihindeki kur bilgilerine göre paranız  donusturuldu .\n\n"+ onayBekleyenHesapBakiyesi.ToString()+" "+ parabirimi_label.Text +" --> "+newBekleyenBakiye.ToString()+" TL ." );
                    AdminFormOnLoad();
                }
                else
                {
                    MessageBox.Show("Para Biriminiz Zaten Tl");
                }
            }
            catch(Exception ex){
                MessageBox.Show("Hata kod: " + ex.ToString());
            }
        }
    }
}
