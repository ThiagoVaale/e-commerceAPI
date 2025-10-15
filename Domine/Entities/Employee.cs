using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Employee : BaseEntity
    {

        public Guid UserID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public User User { get; set; }

    }
}
