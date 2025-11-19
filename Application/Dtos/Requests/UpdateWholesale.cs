using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class UpdateWholesale
    {
        public string? CompanyName { get; set; }
        public string? BillingAddress { get; set; }
        public string? Phone { get; set; }
    }
}
