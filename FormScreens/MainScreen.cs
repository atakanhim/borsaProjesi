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
    public partial class MainScreen : Form
    {
      
        private string sorgu = "";
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ataka\\Desktop\\borsaProjesi\\database\\borsadatabase.accdb");

        public MainScreen()
        {
            InitializeComponent();    
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            listeleCombo.Text = "Tüm Satışlarım";
            checkBox1.Checked = true;
            UpdateLabelTexts();
            
        }
        // list box doldururuluyor
        private void otosatinalPageLoad()
        {
            ListBoxDoldur();
            ListBoxControlEt();
        }
        public void ListBoxDoldur() => Singleton.Instance.islem.listBoxDoldur(urunler_listbox);
        public void ListBoxControlEt()//Eğer aynı ürün isminden birden fazla varsa teke indiriyor
        {
            int x;
            do
            {
              x = 0;
                for (int i = 0; i < urunler_listbox.Items.Count; i++)
                {
                    for (int j = i + 1; j < urunler_listbox.Items.Count; j++)
                    {
                        if (urunler_listbox.Items[i].ToString().ToLower() == urunler_listbox.Items[j].ToString().ToLower())
                        {
                            urunler_listbox.Items.RemoveAt(i);
                            x++;
                        }

                    }
                }
            } while (x >0);
            
        }

        // Anasayfa İşlemleri Page-1
        private void urunler_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (satinalgrpbox.Visible == false)
                satinalgrpbox.Visible = true;
            kacadetalmak_txt.Text = "";
            sorgu = "SELECT * FROM UrunGoster WHERE UrunName='" + urunler_listbox.SelectedItem.ToString() + "'  AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
            ShowDataGridView(urunusatanlar_datagrid, sorgu);
            adet_lbl.Text = urunusatanlar_datagrid.Rows[0].Cells["urunBirimi"].FormattedValue.ToString();
        }

        private void otosatinal_btn_Click(object sender, EventArgs e)
        {
            if (sayiMi(kacadetalmak_txt.Text))
            {
                int toplampara = Singleton.Instance.islem.getToplamPara(urunler_listbox.SelectedItem.ToString(), Convert.ToInt32(kacadetalmak_txt.Text));
                int toplamadet = Singleton.Instance.islem.getUrunToplamAdet(urunler_listbox.SelectedItem.ToString());
                if (Convert.ToInt32(kacadetalmak_txt.Text) > toplamadet)
                {
                    MessageBox.Show("Magazının toplam stogunda bu kadar ürün yok,girebileceginiz maksimum deger:" + toplamadet + " " + adet_lbl.Text + " dir");
                }
                else if (Singleton.Instance.currentUser.Bakiye < toplampara)
                {
                    MessageBox.Show("Bu üründen " + kacadetalmak_txt.Text + " " + adet_lbl.Text + " almak için yeterli bakiyeniz bulunmamaktaıdır", "Bakiye Yetmiyorr");
                }
                else if (Singleton.Instance.currentUser.Bakiye >= toplampara)
                {
                    Singleton.Instance.islem.Otosatinal(urunler_listbox.SelectedItem.ToString(), Convert.ToInt32(kacadetalmak_txt.Text));
                }

            }
            else if (kacadetalmak_txt.Text == "")
                MessageBox.Show("Lütfen Kac Adet Almak istediginizi giriniz", "Tüm alanları doldurun");
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Deger Giriniz", "Syntax hata ");
            }

        }

        private void hangiurunu_listele_Click(object sender, EventArgs e) => otosatinalPageLoad();
        private void cikis_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.login.Show();
        }
        private void titlebakiye_label_MouseHover(object sender, EventArgs e)
        {
            geciciBakiye_label.Visible = true;
            unonay_label.Visible = true;
        }

        private void Titlebakiye_label_MouseLeave(object sender, EventArgs e)
        {
            geciciBakiye_label.Visible = false;
            unonay_label.Visible = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) => checkBoxcontrol();
        private void btn_arttir_Click(object sender, EventArgs e) => increaseOrDecrease(true);    
        private void btn_azalt_Click(object sender, EventArgs e) => increaseOrDecrease(false);
        private void increaseOrDecrease(bool arttir)
        {
            int x = Convert.ToInt32(adetarttir_label.Text);
            int fiyat = Convert.ToInt32(fiyat_label.Text);
            int odecenecektutar = Convert.ToInt32(odenecekttutar_label.Text);
            if (arttir == false && x > 0)
                x--;    
            else if (arttir == true && x < Convert.ToInt32(adetsayisi_label.Text))
                x++;
            else if(x == Convert.ToInt32(adetsayisi_label.Text))
                MessageBox.Show("Bu SATICI için maksimum adet sayısına ulaştınız", "Stok Yetmezligi");
            
            odecenecektutar = fiyat * x;
            adetarttir_label.Text = x.ToString();
            odenecekttutar_label.Text = odecenecektutar.ToString();
        }

        private void satinal_btn_Click(object sender, EventArgs e)
        {

            string x = "";
            if (urunsaticilabel.Text == Singleton.Instance.currentUser.UserName)
            {
                MessageBox.Show("Kendi Ürününüzü Satın Alamazsınız", "Hatalı ürün seçimi");
            }
            else
            {
                DialogResult eminmisin = MessageBox.Show("Bu ürünü almak için istedigine eminmisin Toplam Fiyat:" + odenecekttutar_label.Text + " ₺", "Emin misin ?", MessageBoxButtons.YesNo);
                if (eminmisin == DialogResult.Yes)
                {
                    if (Convert.ToInt32(odenecekttutar_label.Text) > Singleton.Instance.currentUser.Bakiye)
                    {
                        int eksikbakiye = Convert.ToInt32(odenecekttutar_label.Text) - Convert.ToInt32(Singleton.Instance.currentUser.Bakiye);
                        DialogResult dialogResult = MessageBox.Show("Bu ürünü almak için bakiyeniz yetersiz bu ürün için eksik bakiyeniz :" + eksikbakiye.ToString() + "₺ dir. Eksik Bakiyeyi Yüklemek istermisiniz", "Bakiye Yetersizliği !!!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (Singleton.Instance.currentUser.geciciBakiye > 0)
                            {
                                MessageBox.Show("Henüz onaylanmamış bakiyeniz oldugu için bakiye yükleme işlemi gerçekleştirilemiyor", "Bakiye Yükleme Hata");
                            }
                            else
                            {
                                // Bakiye yükle
                                Singleton.Instance.islem.GecicibakiyeGuncelle(eksikbakiye);

                            }
                        }
                    }
                    else if (Convert.ToInt32(odenecekttutar_label.Text) > 0 && adetsayisi_label.Text != "0")
                    {
                        x = adetarttir_label.Text + " " + urunbirimilabel.Text + " " + urunadilabel.Text + " vermiş oldugunuz sipariş yola çıkmıştır en yakın zamanda adresinizde olacaktır  ADRES:  " + Singleton.Instance.currentUser.Adres;
                        Singleton.Instance.islem.UrunSatinAl(barkodno_label.Text, urunsaticilabel.Text, Convert.ToInt32(adetarttir_label.Text), Convert.ToInt32(odenecekttutar_label.Text), x);

                    }
                    else if (adetsayisi_label.Text == "0")
                    {
                        MessageBox.Show("Bu urunden," + urunsaticilabel.Text + " SATICISINDA malesef kalmamış", "Stok Hata");
                    }
                    UpdateLabelTexts();

                }
                else
                {
                    MessageBox.Show("İşlem iptal edildi");
                }
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            barkodno_label.Text = dataGridView1.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();
            fiyat_label.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunFiyati"].FormattedValue.ToString();
            adetsayisi_label.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunMiktari"].FormattedValue.ToString();
            urunsaticilabel.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunSatici"].FormattedValue.ToString();
            odenecekttutar_label.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunFiyati"].FormattedValue.ToString();
            urunbirimilabel.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunBirimi"].FormattedValue.ToString();
            urunadilabel.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();
            if (Convert.ToInt32(adetsayisi_label.Text) > 0)
                adetarttir_label.Text = "1";
            else
                adetarttir_label.Text = "0";
            btn_arttir.Visible = true;
            btn_azalt.Visible = true;
        }

        // Profil İşlemleri Page-2*---------------------------------------------------------------------------------------------------------------------
        private void bakiye_ekle_btn_Click(object sender, EventArgs e)
        {

            if (bakiyeekle_ext.Text == "")
            {
                MessageBox.Show("Lütfen Eklemek istediginiz tutarı giriniz");
            }
            else
            {
                if (Singleton.Instance.currentUser.geciciBakiye == 0)
                {
                    Singleton.Instance.islem.GecicibakiyeGuncelle(Convert.ToInt32(bakiyeekle_ext.Text));
                    bakiyeekle_ext.Text = "";
                    UpdateLabelTexts();
                }
                else
                {
                    MessageBox.Show("Bir Onceki bakiye yükleme işleminiz henüz onaylanmadıgı için işleminizi gerçekleştiremiyoruz", "Bakiye Yükleme Hata");
                }
            }


        }
       
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (puserpass_txt.Text == ""||p_emailtxt.Text==""||padres_txt.Text==""||ptelefonno_txt.Text=="")
            {
                MessageBox.Show("Guncellenek alanlar boş bırakılamaz");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Güncellemek istediginize eminmisiniz  ?", "Kullanıcı Güncellensin mi ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //yes

                    Singleton.Instance.islem.UserUpdate(puserpass_txt, p_emailtxt, padres_txt, ptelefonno_txt);
                   
                    MessageBox.Show("Güncelleme işlemi tamamlandı.");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //no
                    MessageBox.Show("Güncelleme işlemi iptal edildi.");

                }
            }
            guncelProfil();
        }

        // Urun İşlemleri Page -3 *---------------------------------------------------------------------------------------------------------------------


        private void nmsattiklarim_btn_Click(object sender, EventArgs e) => ListeleComboBoxControl();
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           
                dataGridView2.CurrentRow.Selected = true;
                g_urunid.Text = dataGridView2.Rows[e.RowIndex].Cells["UrunID"].FormattedValue.ToString();
                g_urunname.Text = dataGridView2.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();
                g_urunmiktari.Text = dataGridView2.Rows[e.RowIndex].Cells["UrunMiktari"].FormattedValue.ToString();
                g_urunbirimi.Text = dataGridView2.Rows[e.RowIndex].Cells["urunBirimi"].FormattedValue.ToString();
                g_urunfiyati.Text = dataGridView2.Rows[e.RowIndex].Cells["UrunFiyati"].FormattedValue.ToString();
                g_urunturu.Text = dataGridView2.Rows[e.RowIndex].Cells["UrunTuru"].FormattedValue.ToString();
                g_urunbarkod.Text = dataGridView2.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();
          
        }
        private void add_urun_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.islem.UrunEkle(add_barkodno, urunbirimibox, add_urunfiyati, add_urunmiktari, add_urunname, add_urunturu, Singleton.Instance.currentUser.UserName, groupBox1);
            MessageBox.Show("Urun eklendi admin onayı bekleniyor", "Urun ekleme Başarılı");
            ListeleComboBoxControl();
      
        }

        private void urun_guncelle_btn_Click(object sender, EventArgs e)
        {
            if (sayiMi(g_urunfiyati.Text) && sayiMi(g_urunmiktari.Text))
            {
             
                if (Convert.ToInt32(g_urunfiyati.Text) <= 0 || Convert.ToInt32(g_urunmiktari.Text) <= 0)
                {
                    MessageBox.Show("Lütfen 0 dan farklı pozitif sayılar giriniz.", "Hatalı urun güncellemesi");
                }
                else
                {
                   
                    Singleton.Instance.islem.UrunUpdate(g_urunfiyati, g_urunmiktari, g_urunbarkod.Text,groupBox1);
                    MessageBox.Show("Urun guncellendi admin onayı bekleniyor","Urun güncelleme Başarılı");
               
                }
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir deger girin");
            }
            ListeleComboBoxControl();
        }

        // Timer Kayan Yazı
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(1) + this.Text.Substring(0, 1);

            textBox5.Text = textBox5.Text.Substring(1) + textBox5.Text.Substring(0, 1);
            textBox4.Text = textBox4.Text.Substring(1) + textBox4.Text.Substring(0, 1);
        }
        // Bool Sayimi 
        static bool sayiMi(string deger)
        {
            try
            {
                int.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Fonksiyonlar
        private void ShowDataGridView(DataGridView x, string sorgu) => x.DataSource = Singleton.Instance.islem.showdatabases(sorgu, baglanti);
        public void UpdateLabelTexts()
        {            
            if (Singleton.Instance.currentUser.cinsiyet == "Kadın")
            {
                kadinimage.Visible = true; 
                kadinimage2.Visible = true;
            }
            else
            {
                kadinimage.Visible = false;
                kadinimage2.Visible = false;
            }
            urunler_listbox.Items.Clear();
            satinalgrpbox.Visible = false;
            ButonVisibleControl();
            guncelProfil();
        }
        public void guncelProfil()
        {
            puserid_label.Text = Singleton.Instance.currentUser.UserID.ToString();
            pusername_label.Text = Singleton.Instance.currentUser.UserName;
            puserpass_txt.Text = Singleton.Instance.currentUser.UserPass;

            profilad_label.Text = Singleton.Instance.currentUser.Ad;
            psoyad_label.Text = Singleton.Instance.currentUser.SoyAd;
            ptcno.Text = Singleton.Instance.currentUser.Tc.ToString();
            ptelefonno_txt.Text = Singleton.Instance.currentUser.Telefon.ToString();
            padres_txt.Text = Singleton.Instance.currentUser.Adres;
            p_emailtxt.Text = Singleton.Instance.currentUser.Eposta;
            p_unvan.Text = Singleton.Instance.currentUser.Unvan;
            uyelik_turu.Text= Singleton.Instance.currentUser.Unvan;

            //***********
            main_ad.Text = Singleton.Instance.currentUser.Ad;
            main_soyad.Text = Singleton.Instance.currentUser.SoyAd + "";
            bakiye_label.Text = Singleton.Instance.currentUser.Bakiye + "₺";
            geciciBakiye_label.Text = Singleton.Instance.currentUser.geciciBakiye + "₺";
            bakiyelabel2_txt.Text = Singleton.Instance.currentUser.Bakiye + "₺"; ;
            gecicibakiye2label_txt.Text = Singleton.Instance.currentUser.geciciBakiye + "₺";
            kacadetalmak_txt.Text = "";
        }

        private void ButonVisibleControl()
        {
            if (Singleton.Instance.currentUser.Unvan == "SATICI")
            {
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
                ShowDataGridView(dataGridView2, sorgu);         
                checkBox1.Visible = true;
                checkBoxcontrol();
                TxtDuzenle(false);
            }
            else
            {
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "' AND UrunMiktari>0 ";
                ShowDataGridView(dataGridView1, sorgu);
                checkBox1.Visible = false;              
                TxtDuzenle(true);
            }
           
        }
        private void TxtDuzenle(bool x)
        {
            // 1213; 498

            if (x == true)
            {
                txt_control.Visible = true;
                txt_control.Dock = DockStyle.Fill;
            }
            if (x == false)
                txt_control.Visible = false;
        }
        private void checkBoxcontrol()
        {

            if (checkBox1.Checked == true)
            {           
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "' AND UrunMiktari>0 ";
                ShowDataGridView(dataGridView1, sorgu);
            }

            if (checkBox1.Checked == false)
            {
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
                ShowDataGridView(dataGridView1, sorgu);
               
            }
        }
        private void ListeleComboBoxControl()
        {
            sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.Ad + "'";
            tumsatislarim_label.Text = listeleCombo.Text;
            if (listeleCombo.Text == "Tüm Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.Ad + "'";

            if (listeleCombo.Text == "Onaylanmış Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.Ad + "' AND urunonay='" + "Onaylandı" + "'";

            if (listeleCombo.Text == "Onaylanmamış Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.Ad + "' AND urunonay='" + "Onaylanmadı" + "'";
            ShowDataGridView(dataGridView2, sorgu);
        }

       
    }
}
