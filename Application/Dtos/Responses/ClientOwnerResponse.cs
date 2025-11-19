using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Responses
{
    public class ClientOwnerResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ClientType { get; set; }


        public string? Dni { get; set; }
        public MembershipType? MembershipType { get; set; }
        public decimal? DiscountRate { get; set; }
        public DateTime? MembershipValidTo { get; set; }

        public string? CompanyName { get; set; }
        public string? Cuit { get; set; }
        public string? BillingAddress { get; set; }
        public TierWholesale? TierWholesale { get; set; }

    }
}
