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
