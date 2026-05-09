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

<img width="1897" height="870" alt="Ekran görüntüsü 2026-05-09 162601" src="https://github.com/user-attachments/assets/c38c60cb-3786-403e-ac74-22a279b54726" />
<img width="1914" height="855" alt="Ekran görüntüsü 2026-05-09 162647" src="https://github.com/user-attachments/assets/f723ad6e-b31e-46b6-8cfe-c10acba847a1" />
<img width="1913" height="839" alt="Ekran görüntüsü 2026-05-09 162711" src="https://github.com/user-attachments/assets/4c1d30fa-4487-46b5-a24d-78ad53ff9f9f" />
<img width="1915" height="842" alt="Ekran görüntüsü 2026-05-09 162739" src="https://github.com/user-attachments/assets/99def7f3-3529-4f2d-9dbb-b516cc7df4e1" />


---


