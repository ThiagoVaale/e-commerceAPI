using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class WholesaleClient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClientId { get; set; }
        public Guid TierWholesaleId { get; set; }
        public string CompanyName { get; set; }
        public string Cuit { get; set; }
        public string BillingAddress { get; set; }
        public decimal CreditLimit { get; set; }
        

        public Client Client { get; set; }
        public TierWholesale TierWholesale { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
