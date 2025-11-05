using Domine.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class Client : BaseEntity
    {
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
