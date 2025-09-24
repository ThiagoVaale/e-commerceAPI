using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserID { get; set; }
        public Guid MembershipId { get; set; }
        public string Address { get; set; }
        public RetailClient RetailClient { get; set; }
        public WholesaleClient WholesaleClient { get; set; }

        public User User { get; set; }
        public Membership Membership { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
