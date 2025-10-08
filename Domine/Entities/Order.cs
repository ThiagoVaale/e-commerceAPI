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

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
