using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Responses
{
    public class EmployeeResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string? Phone { get; set; }
    }
}
