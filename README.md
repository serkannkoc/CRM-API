
# Company API

Bu projeyi DGPays'te altı haftalık backend stajımın sonunda bitirme projesi olarak Ağustos 2022'de yaptım.
Projeyi yaparken ASP.Net Core 5.0, Entity Framework Core, MS Sql Server, Postman, JWT ve Middleware kullandım.


## Database Şeması


![Uygulama Ekran Görüntüsü](https://github.com/serkannkoc/Company-API/blob/master/ss/Database%20Diagram.png?raw=true)

  
## Projenin İşleyiş Süreci

* Kullanıcı sisteme ön kayıt olurken email ve ip adresini endpointle gönderiyor. Bu iki veriyi kullanarak bir adet hash string oluşturuluyor. Oluşturulan hash string kullanıcının girdiği mail adresine NETCore.MailKit paketi kullanılarak gönderiliyor. 
* Oluşturulan hash stringin 7 günlük süresi var. Kullanıcı sisteme bu süre içinde kayıt olmamışsa ön kayıt verileri soft delete ile siliniyor.  
![Uygulama Ekran Görüntüsü](https://github.com/serkannkoc/Company-API/blob/master/ss/ss1.png?raw=true)  
  
 

* Kullanıcı sisteme kayıt olurken hash string ve email adresini giriyor. Sistemdeki verilerle girilenler eşleşirse kullanıcı kayıt oluyor.  
  
* API'deki endpointlerden preRegister, register ve login olanlar public olarak açık. 
  Diğerlerinde erişim engeli var. Kullanıcının erişim sağlaması için login endpointine
  email ve şifresini girmesi gerekiyor. Girilen veriler sistemdeki verilerle eşleşiyorsa
  JWT oluşturuluyor. Kısıtlı endpoinlterde authorization için Postman'da Bearer Token olarak girilmesi gerekiyor.  
  
  ![Uygulama Ekran Görüntüsü](https://github.com/serkannkoc/Company-API/blob/master/ss/ss2.png?raw=true)
  ![Uygulama Ekran Görüntüsü](https://github.com/serkannkoc/Company-API/blob/master/ss/ss3.png?raw=true)

* API'deki endpointler aşağıdaki ekran görüntüsünde vardır.
![Uygulama Ekran Görüntüsü](https://github.com/serkannkoc/Company-API/blob/master/ss/ss4.png?raw=true)

* Id girilmesi gereken endpointlerde girilen Id ile JWT deki id eşleşiyorsa kullanıcı o endpointi kullanabiliyor. 

* Veritabanındaki DeletedAt sütunları başlangıçta null olarak girilmektedir. Soft delete ile veri silindikten sonra bu kısma silinme tarihi giriliyor.

* API'ye custom exception middleware ekledim. Oluşan hataların kodlarına göre postmanda output olarak hatanın türü, hata mesajı ve kodu gözüküyor.

* Validation için RegExleri kullandım. Yanlış türde veri girilirse hata mesajı döndürülüyor.




  
