using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSBackend.Domain.Entities
{
    public  class Kullanici
    {
        public Guid Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? SifreHash { get; set; }

        public string? Rol { get; set; } = "Kullanici"; // "Admin" olabilir
    }
}
