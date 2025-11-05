using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }

        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? PaidAt { get; set; }

        public Order Order { get; set; }

    }
}
