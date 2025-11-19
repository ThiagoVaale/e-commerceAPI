using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class RetailClient : BaseEntity
    {
        public Guid ClientId { get; set; }
        public string Dni { get; set; }

        public Client Client { get; set; }  
        public Membership? Membership { get; set; }
    }
}
