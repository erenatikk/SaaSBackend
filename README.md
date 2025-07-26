# 🌐 SaaS Tabanlı ASP.NET Core Web API Projesi

Bu proje, çok kiracılı (multi-tenant) mimariye uygun, PostgreSQL veritabanı üzerinde çalışan ve JWT Authentication ile güvenliği sağlanan bir ASP.NET Core Web API uygulamasıdır.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code First)
- PostgreSQL (Docker)
- Swagger UI
- JWT Authentication

---

## 🔧 Proje Özellikleri

- Firma (Tenant) CRUD işlemleri
- Kullanıcı kaydı (register) ve giriş (login)
- Şifre hashleme
- JWT token üretimi ve doğrulama
- Rol bazlı yetkilendirme (Admin/Kullanıcı)
- `[Authorize]` attribute'ü ile korunan endpoint'ler
- Swagger UI üzerinden test edilebilir arayüz
- Docker ile kolay veritabanı kurulumu

---

## 📂 Proje Yapısı

```plaintext
SaaSBackend/
├── SaaSBackend.API/            # API Giriş Noktası, JWT, Swagger
├── SaaSBackend.Infrastructure/ # EF Core, DbContext, Migrations
├── SaaSBackend.Domain/         # Entity sınıfları
├── SaaSBackend.Shared/         # Ortak yapılar (opsiyonel)
└── docker-compose.yml          # PostgreSQL Docker servisi
```

⚙️ Kurulum ve Çalıştırma
Aşağıdaki adımları izleyerek projeyi lokal ortamınızda hızlıca çalıştırabilirsiniz:

1. PostgreSQL veritabanını başlat
Docker üzerinden PostgreSQL konteynerini ayağa kaldırmak için:

docker-compose up -d

---

2. Veritabanı tablolarını oluştur
Entity Framework Core migration işlemini veritabanına uygulayın:

dotnet ef database update -p SaaSBackend.Infrastructure -s SaaSBackend.API

---

3. API projesini çalıştır
Web API'yi başlatmak için:

dotnet run --project SaaSBackend.API

---

4. Swagger arayüzünü aç
Aşağıdaki adresi tarayıcıda açarak API'yi test edebilirsiniz:

http://localhost:5205/swagger
Buradan register, login ve token doğrulama işlemleri kolayca yapılabilir.
