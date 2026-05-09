# 📚 Kütüphane Yönetim Sistemi

Bu proje, modern bir kütüphanenin temel ihtiyaçlarını karşılamak üzere tasarlanmış, **ASP.NET Core MVC** mimarisi kullanılarak geliştirilmiş kapsamlı bir web uygulamasıdır. Kitap, yazar ve kategori yönetimi gibi temel CRUD işlemlerini merkezi bir platformda toplar.

## 🚀 Özellikler

Uygulama aşağıdaki temel işlevleri sunmaktadır:

- **Kitap Yönetimi**: Kitap ekleme, listeleme, güncelleme ve silme (CRUD) işlemleri.
- **Yazar Yönetimi**: Yazarların bilgilerini yönetme ve kitaplarla ilişkilendirme.
- **Kategori Yönetimi**: Kitapları kategorize ederek daha kolay erişim sağlama.
- **İlişkisel Veri Yapısı**: Kitaplar, yazarlar ve kategoriler arasında Entity Framework Core ile sağlanan güçlü ilişkisel yapı.
- **Dinamik Arayüz**: Kullanıcı dostu, duyarlı (responsive) ve modern bir tasarım.
- **Veri Doğrulama**: Sunucu ve istemci taraflı gelişmiş form doğrulama mekanizmaları.

## 🛠️ Kullanılan Teknolojiler

Bu projede kullanılan ana teknolojiler ve kütüphaneler:

- **Framework**: ASP.NET Core 9.0 (MVC)
- **ORM**: Entity Framework Core
- **Veritabanı**: Microsoft SQL Server (LocalDB)
- **Frontend**: 
  - HTML5 & CSS3
  - Bootstrap 5
  - JavaScript / jQuery
- **Tasarım**: Modern UI/UX yaklaşımları

## 💻 Kurulum ve Çalıştırma

Projeyi yerel bilgisayarınızda çalıştırmak için şu adımları izleyebilirsiniz:

1. **Depoyu Klonlayın**:
   ```bash
   git clone https://github.com/Seyma12408/KutuphaneYonetimSistemi.git
   ```

2. **Veritabanı Yapılandırması**:
   `appsettings.json` dosyasındaki bağlantı dizesini (Connection String) kendi SQL Server ayarlarınıza göre güncelleyin:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=KutuphaneDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Migration Uygulama**:
   Paket Yöneticisi Konsolu'nu (Package Manager Console) açın ve veritabanını oluşturmak için şu komutu çalıştırın:
   ```powershell
   Update-Database
   ```

4. **Projeyi Çalıştırın**:
   Visual Studio üzerinden `F5` tuşuna basarak veya terminalden `dotnet run` komutu ile uygulamayı başlatabilirsiniz.

## 📂 Proje Yapısı

- **Controllers**: İş mantığının ve yönlendirmelerin yönetildiği katman.
- **Models**: Veritabanı tablolarını ve veri modellerini temsil eden sınıflar.
- **Views**: Kullanıcı arayüzü dosyaları (Razor Pages).
- **Data**: `DbContext` yapılandırması ve veritabanı bağlantı ayarları.
- **wwwroot**: CSS, JavaScript ve görsel dosyalar gibi statik içerikler.

## 📸 Ekran Görüntüleri

*(Buraya uygulamanın ekran görüntülerini ekleyebilirsiniz)*

---

Bu proje, **Şeyma** tarafından eğitim ve portfolyo amaçlı geliştirilmiştir. Geliştirme sürecinde temiz kod prensipleri ve MVC mimarisi temel alınmıştır.
