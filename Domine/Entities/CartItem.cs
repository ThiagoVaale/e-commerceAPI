using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class CartItem : BaseEntity
    {

        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [NotMapped]
        public decimal SubTotal => Quantity * UnitPrice;

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
