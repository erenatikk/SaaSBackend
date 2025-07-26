using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSBackend.Domain.Entities
{
    public class Firma
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string?   Ad { get; set; }
        public string? VergiNo { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.UtcNow;
    }
}
