using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Account
{
    public class LoginDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [MinLength(12, ErrorMessage = "Password should be atleast of 12 characters")]
        public string? Password {get; set;}
    }
}