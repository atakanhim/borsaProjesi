# *Borsa Projesi*

## **Yapanlar**
*Atakan Him - 182805004 - II.Ogretim*<br/>
## **Youtube Videosu**
 [Borsa Projem Youtube Videosu](https://www.youtube.com/watch?v=VnqjoPU8pjY)<br/>
## **Proje Açıklaması**
 *C# ve Access database kullanılmış  Otomatik Alım Satın Yapabilen,Admin Onayı,Urun; ekle,güncelle,kullanıcı ekle, güncelle gibi seçenekleri bulunan Market Otomasyonu projem*<br/><br/><br/>
## **Proje Detaylı Açıklaması**
*Projemde ilk olarak bahsetmek istedigim Singleton tasarım desenini kullandığım,bu
desen sayesinde projemde tanımlayacağım nesneleri tek bir sayfada tanımlayıp 
gerektiği yerlerde çağırdım.Projenin Niteliklerinden bahsedecek olursam proje de,Urun Satın Al,Urun 
Guncelle,Urun Ekle,Kullanıcı Ekle,Kullanıcı Güncelle gibi fonksiyonlar vardır.
Admin Paneli Tarafında ise ,Bakiye Onay Fonksiyonu ; müşteri/satici tarafından 
hesap bakiye yükleme işlemlerini onaylayıp geçicibakiyelerini ana hesap bakiyelerine 
aktarıyor.Urun Onay Fonksyonu ; Saticinin eklemek/güncellemek istedigi ürünü 
onaylayarak satışa hazır hale gelmesini saglıyoruz.<br/>
**Projenin En iyi kısmı** ise konumuzlada Alakalı olan kısmı User Story 4;
Bu aşamada ilk önce Otomatik Satın Al TabPageini açıp Listele Deyip hali hazırda 
olan urunleri listeliyoruz,ardından almak istedigimiz ürünün ismine tıklıyoruz açılan 
DataGridView tablosunda hangi satici ne kadar ne fiyata satıyor 
görebiliyoruz.Otomatik Satın Al butonuna bastıgımızda ilk önce ne kadar almak 
istedigimize bakıyor istedigimiz miktar toplam stokta var ise birde paramız yetiyormu 
diye bakıyor,paramızda yetiyor ise OTOMATİK Olarak En düşük fiyattan satılan malı 
almaya başlıyor ve işlem bittiginde kimden ne aldıysak parasını ona göre dagıtıyor.
Bu arada dikkat çeken şey kullanıcı eger müşteri ise tüm onaylanmış satışları 
görebilir fakat kullanıcı eğer satıcılardan biri ise o kişi kendi satışını listeliyemez veya 
alamaz otomatik fiyatlandırma dışında kalır kalan satıcılar arasından en düşük 
fiyattan almaya başlar.*<br/>

# **User Storys**
## User Story 1 ( Kullanıcı Ekleme )
![user_story_1(kullanici üye olll)](https://user-images.githubusercontent.com/52455771/118190032-3afae480-b44b-11eb-92a5-ac14698edd10.png)<br/>
## User Story 2.1 ( Urun Ekleme )
![user_story_2 1(urun ekleniyor)](https://user-images.githubusercontent.com/52455771/118190039-3cc4a800-b44b-11eb-9979-742c29c2c724.png)<br/>
## User Story 2.2 ( Urun Onaylama )
![user_story_2 2(urun onaylanıyorr)](https://user-images.githubusercontent.com/52455771/118190043-3d5d3e80-b44b-11eb-97e1-7de9aca5d691.png)<br/>
## User Story 3.1 ( Bakiye Ekleme )
![user_story_3 1(bakiye ekliyoruz)](https://user-images.githubusercontent.com/52455771/118190047-3df5d500-b44b-11eb-86ee-4a4692dbc8ed.png)<br/>
## User Story 3.2 ( Bakiye Onaylama )
![user_story_3 2(bakiye onaylama)](https://user-images.githubusercontent.com/52455771/118190051-3e8e6b80-b44b-11eb-8a74-53e8683bd676.png)<br/>
## User Story 4 ( Otomatik Satış İşlemi ) 
![user_story_4(satin alma gerceklesti)](https://user-images.githubusercontent.com/52455771/118190053-3fbf9880-b44b-11eb-993f-77797f1a569c.png)<br/>
