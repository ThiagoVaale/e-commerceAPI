using Domine.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class CreateUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [MaxLength(64, ErrorMessage = "Password cannot exceed 64 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&]).+$",
            ErrorMessage = "Password must contain at least one letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
