using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Models
{
    public class LoginModel
    {
        [UIHint("email")]
        [Required]
        public string Email { get; set; }

        [UIHint("password")]
        [Required]
        public string Password { get; set; }
    }
}
