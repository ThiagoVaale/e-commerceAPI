using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class RetailClient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClientId { get; set; }
        public string Dni { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
