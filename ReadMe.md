# SaaS Tabanlı ASP.NET Core Web API Projesi

Bu proje, çok kiracılı (multi-tenant) mimariye uygun, JWT kimlik doğrulama sistemi bulunan ve PostgreSQL veritabanı ile çalışan bir SaaS Web API uygulamasıdır.

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- PostgreSQL (Docker)
- Swagger UI
- JWT Authentication (Rol bazlı yetkilendirme)

## 🔧 Proje Özellikleri

- Firma yönetimi – CRUD işlemleri
- Kullanıcı kaydı ve JWT ile giriş
- Rol bazlı yetkilendirme (Admin / Kullanıcı)
- Token doğrulama ve korumalı endpoint'ler
- Docker ile PostgreSQL kurulumu
- Swagger üzerinden test edilebilir API arayüzü

## 📂 Proje Mimarisi

SaaSBackend/
├── SaaSBackend.API/ → Controller'lar, JWT, Swagger, Startup
├── SaaSBackend.Infrastructure/→ EF Core, DbContext, Migrations
├── SaaSBackend.Domain/ → Entity modelleri
├── SaaSBackend.Shared/ → Ortak yapılar
└── docker-compose.yml → PostgreSQL servisi



```bash
# PostgreSQL başlat (Docker)
docker-compose up -d

# Veritabanını oluştur
dotnet ef database update -p SaaSBackend.Infrastructure -s SaaSBackend.API

# API projesini çalıştır
dotnet run --project SaaSBackend.API

http://localhost:5205/swagger
