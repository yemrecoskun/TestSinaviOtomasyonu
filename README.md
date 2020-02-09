# TestSinaviOtomasyonu
## Projemizde Kullanılan Programlar 
- ASP.NET MVC
- MySQL Workbech
## Projemizin Amacı

 <b> 1. Otomasyon sisteminde Admin ve diğer kullanıcılar olmak üzere iki tip kullanıcı vardır.</b>
- Admin kullanıcısı, sistemdeki tüm işlemleri yapabilir
- Diğer kullanıcılar, ilgili bölümün ilgili döneminde yer alan ve kendine atanan dersin
vize, final ve bütünleme sınavlarını değerlendirme hakkına sahiptir.
##
  <b>2. İşlemler</b>
- Kullanıcı ekleme, kullanıcıların (öğretim elemanları) sicil numarası, adı soyadı,
şifresi olmalıdır. (Güncelleme, silme ve listeme yapılabilmektedir.)
- Fakülte ekleme, güncelleme, silme işlemleri yapar.
- Bölüm ekleme, programda herhangi bir bölüm tanımlanabilir. Bölüm eklenirken
program kazanımları eklenir. Örneğin, Teknoloji fakültesi altında bilişim sistemleri müh,
biyomedikal müh, vb. (Güncelleme, silme ve listeme yapılabilmektedir.)
- Dönem adı ekleme, sisteme 2019-2020 Güz Yarıyılı, 2019-2020 Bahar Yarıyılı vb
isimlendirme yöntemi ile tanımlama yapılabilmelidir. (Güncelleme, silme ve listeme
yapılabilmelidir. Özellikle silme işlemlerinde bağlantılara dikkat ediniz.)
- Ders ekleme, programa ders eklenir. Ders ekleme işlemi yapılırken, dersin adı,
kodu, dersin öğrenme kazanımları (öğrenme çıktıları) eklenir.(Güncelleme, silme ve listeme
yapılabilmelidir.)
- Ders atama işlemi, kullanıcılara yani öğretim elemanlarına ders atama işlemidir.
Bölüm, yarıyıl, ders ve kullanıcı sicil no (hoca) seçilerek yapılır.
- Listeleme işlemleri, admin kullanıcısı her türlü listeme (kullanıcılar listelemeleri, ders
atamaları, bölümler listesi, ilgili bölümde açılan dersler listesi vb...) işlemlerini
gerçekleştirebilir. Okutulan sınavlar veya dersleri bölüm, dönemsel olarak
listeleyip yanında vize, final ve bütünleme sınav türleri olmalı ve okutulmuş olanlara
link verilmelidir.(Excel dosyası açar.)
- Test sınavı okutma işlemi, ilgili kullanıcı (öğretim elemanı) sisteme giriş yaptıktan
sonra sınavını okutmak istediği bölümü, yarıyılı, dersi ve sınav türünü (vize,final,büt)
seçmelidir. Elinde yer alan metin dosyasını * sisteme yüklemelidir. (örnek [sınav.txt](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/sinavsonuclari.txt).)
Sonrasında cevap anahtarı* sisteme yüklenmelidir.(örnek [cevap.txt](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/cevapanahtari.txt)
Değerlendir düğmesi ile öğrencilerin sınav sonuçları listelenmelidir. Aynı zamanda bu sonuçlar excel dosyasına kaydedilmelidir.
- Soru bazlı değerlendirme işlemi, test okuma işleminden her öğrencinin hangi
sorudan kaç puan aldığını gösteren bir liste oluşturur. Ayrıca sınıfın her
sorudaki ortalaması hesaplanır. Bu oluşturulan değerler excelin 2.alanına kaydedilir.
- Kazanım bazlı değerlendirme işlemi, ders ekleme işleminde eklenmiş olan
kazanımlar listelenmelidir. Aynı zamanda sorularda listelenmelidir. Herbir kazanıma
ait sorular seçilmelidir. Seçilmiş olan sorulara göre kazanım ortalama puanı ve kazanım
başarı puanları hesaplanmalıdır. Sorulara kazanımı seçilenleri excelin 3.alanına kaydeder, değerlendirmeyi 4.alana kaydeder.
## Programın Kullanımı
Programın kullanımı için [buraya](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/help.pdf) gözatınız.
## Programdaki Kodların Kullanımı
<b> Program C# Katmanlı Mimari ile çalışmaktadır.</b>
- [TestSinaviOtomasyon.Common](https://github.com/yemrecoskun/TestSinaviOtomasyonu/tree/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Common) katmanı ile DataTransferObjects oluşturdum. DTOName.cs kısmında ilgili alanda yer alabilecek değişkenleri tanımladım. ([örnek](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Common/DataTransferObjects/DTOBolum.cs))
- [TestSinaviOtomasyon.Entity](https://github.com/yemrecoskun/TestSinaviOtomasyonu/tree/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Entity)  katmanı ile veritabanı ile alakalı tüm işlemleri gerçekleştirir. Common Katmanını bu katmana çağırarak ilgili alandaki verileri çekerek işlemler yapar.([örnek](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Entity/EBolum.cs))
- [TestSinaviOtomasyon.Service](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Service/Service.cs) bu katman ile Entity katmanında yapılan işlemleri maine servis eder.
- [TestSinaviOtomasyon.Globals](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Globals/Globals.cs) bu katman ile geçici global değişkenler tanımlanır. Bu katman diğer katmandan bağımsız çalışır
- [TestSinaviOtomasyon](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon/Controllers/HomeController.cs) bu katman ana katmandır. Buraya Service code tanımlayarak serviste bulunan işlemleri çağırıyoruz. 
