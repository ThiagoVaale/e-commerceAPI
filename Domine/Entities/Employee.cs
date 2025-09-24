using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserID { get; set; }
        public User User { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedAt { get; set; }
    }
}
