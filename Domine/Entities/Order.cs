using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Order : BaseEntity
    {
        public Guid ClientId { get; set; }
        public Guid EmployeeId { get; set; }
        public string ShippingAddress { get; set; } 
        public decimal TotalAmount { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
