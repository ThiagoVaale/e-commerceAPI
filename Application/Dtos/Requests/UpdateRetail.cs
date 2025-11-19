using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class UpdateRetail
    {
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
