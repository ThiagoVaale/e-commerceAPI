using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class UpdateUser
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
