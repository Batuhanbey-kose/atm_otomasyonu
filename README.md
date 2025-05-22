# 💳 ATM Otomasyon Sistemi  
Bu proje, **.NET 8.0** ile geliştirilmiş bir **Windows Form App** uygulamasıdır.  
Kullanıcıların temel bankacılık işlemlerini kolayca yapabileceği, kullanıcı dostu arayüze sahip bir **ATM otomasyon sistemidir**.  
Arka planda **SQL Server** kullanılarak veriler yönetilmekte ve **ADO.NET** ile veritabanı bağlantısı sağlanmaktadır.

---

## 📋 İçerik Tablosu
- [🌟 Özellikler](#-özellikler)  
- [🛠️ Kullanılan Teknolojiler](#%EF%B8%8F-kullan%C4%B1lan-teknolojiler)    
- [📝 Kurulum ve Kullanım](#-kurulum-ve-kullanım)
  - [⚙️ Gereksinimler](#%EF%B8%8F-gereksinimler)
  - [🚀 Adımlar](#-adımlar)
- [🤝 İletişim ve Katkıda Bulunma](#-iletişim-ve-katkıda-bulunma)



---

## 🌟 Özellikler
- 💰 Para yatırma, çekme ve transfer işlemleri  
- 📊 Hesap hareketlerini izleme  
- 🔍 Bakiye sorgulama  
- 🆕 Yeni hesap oluşturma  
- 🔐 Kullanıcı girişi ve şifre değiştirme  
- 🖥️ Kullanıcı dostu Windows Forms arayüzü  

---

## 🛠️ Kullanılan Teknolojiler
- 👨‍💻 Programlama Dili: C# (.NET 8.0)  
- 🪟 Arayüz: Windows Forms (Form Ekranları)  
- 🗄️ Veritabanı: SQL Server (Microsoft SQL Server Management Studio ile)  
- 🔌 Veritabanı Bağlantısı: ADO.NET  
- 🖥️ Geliştirme Ortamı: Visual Studio Code  

---

## 📝 Kurulum ve Kullanım 

### ⚙️ Gereksinimler
- .NET 8.0 SDK  
- Microsoft SQL Server ve SQL Server Management Studio (SSMS)  
- Visual Studio 2022  

### 🚀 Adımlar

#### 0️⃣ Projeyi İndirin  
Aşağıdaki kodu terminalde çalıştırdıktan sonra github repomu bilgisayarınıza indirmiş olucaksınız.
``` bash
git clone https://github.com/kullaniciadi/atm-otomasyon.git
```

#### 1️⃣ Visual Studio 2022 ile Açın (🟪)

- Visual Studio’yu açın.  
- `Open a project or solution` seçeneğine tıklayın.  
- Klonladığınız klasördeki `atm_otomasyonu.csproj` dosyasını seçin.  
- Üst menüden sırasıyla `Build > Clean Solution` ardından `Build > Rebuild Solution` yapın.  
- Projeyi başlatmak için `F5` tuşuna basın.


#### 2️⃣ Veritabanını Oluşturun

`Hesaplar`, `Transfera` gibi png leri takip ederek SQL Server üzerinde bir veritabanı oluşturun.

1. SQL Server Management Studio (SSMS)'yi açın.  
2. `ATM_Database` adında yeni bir veritabanı oluşturun.

#### 3️⃣ Bağlantı Dizesini Ekleyin

 `DatabaseHelper.cs` dosyasındaki bağlantı dizesi alanını kendi veritabanı bilgilerinize göre güncelleyin.

   📌 **Bağlantı dizesi konumu:**
   `DatabaseHelper` sınıfı içindeki `SqlConnection` nesnesinin tanımlandığı yer.

![Image](https://github.com/user-attachments/assets/3e94bfa2-e1ff-4b21-a157-ada3913b6296)

#### 4️⃣ Projeyi Açın ve Çalıştırın

- Tüm adımlar tamamlandıktan sonra F5 tuşuna basarak projeyi başlatabilirsiniz.
Proje üzerinden testler yapabilir ya da geliştirme yapabilirsiniz.

---
## 🤝 İletişim ve Katkıda Bulunma

* 🐛 Hata bildirimleri için [Issues](https://github.com/Batuhanbey-kose/atm_otomasyonu/issues) sayfasını kullanın

* 💡 Yeni özellik önerileri için [Pull Request](https://github.com/Batuhanbey-kose/atm_otomasyonu/pulls) gönderin

* 📧 İletişim: kosebatuhanbey@gmail.com

---
<p align="center">
  <small>Built with ❤️ by <strong>Batuhanbey Köse</strong>
</p>
