using Domine.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Client : BaseEntity
    {
        
        public Guid UserID { get; set; }
        public Guid MembershipId { get; set; }
        public string Address { get; set; }
        public RetailClient RetailClient { get; set; }
        public WholesaleClient WholesaleClient { get; set; }

        public User User { get; set; }
        public Membership Membership { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
