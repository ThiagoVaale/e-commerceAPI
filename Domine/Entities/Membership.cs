using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Membership : BaseEntity
    {

        public Guid ClientId { get; set; }
        public MembershipType MembershipType { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Client Client { get; set; }


    }
}
