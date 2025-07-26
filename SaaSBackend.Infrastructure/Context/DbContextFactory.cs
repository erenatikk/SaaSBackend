using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SaaSBackend.Infrastructure.Context;

namespace SaaSBackend.Infrastructure.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Bağlantı cümlesi burada sabit olarak veriliyor çünkü design time'da appsettings okunmaz
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=saasdb;Username=admin;Password=admin123");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
