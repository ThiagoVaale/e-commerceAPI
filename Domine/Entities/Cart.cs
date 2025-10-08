using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Cart : BaseEntity
    {
        
        public Guid UserId { get; set; }

        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
