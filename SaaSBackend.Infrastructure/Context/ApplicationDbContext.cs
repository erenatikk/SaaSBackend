using Microsoft.EntityFrameworkCore;
using SaaSBackend.Domain.Entities;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace SaaSBackend.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

    }
}
