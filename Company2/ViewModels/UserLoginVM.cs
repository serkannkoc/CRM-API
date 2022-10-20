using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.ViewModels
{
    public class UserLoginVM
    {
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+",
            ErrorMessage = "Enter proper email")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
