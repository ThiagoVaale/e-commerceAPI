using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Responses
{
    public class UserResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public RoleType Role { get; set; }
    }
}
