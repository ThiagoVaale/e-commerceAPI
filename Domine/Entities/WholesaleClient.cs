using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class WholesaleClient : BaseEntity
    {

        public Guid ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Cuit { get; set; }
        public string BillingAddress { get; set; }
        public decimal CreditLimit { get; set; }

        public TierWholesale TierWholesale { get; set; }
        public Client Client { get; set; }
    }
}
