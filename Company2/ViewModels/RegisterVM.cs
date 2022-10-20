using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.ViewModels
{
    public class RegisterVM
    {
        public string Hash { get; set; }
        [RegularExpression(@"^(?!\\d+$)\\w{8,20}$",ErrorMessage ="Enter proper UserPermissionId")]
        public int? UserPermissionId { get; set; }
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+",
            ErrorMessage = "Enter proper email")]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",ErrorMessage = "Minimum eight characters, at least one upper case English letter, one lower case English letter, one number and one special character")]
        public string Password { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage ="Enter proper name")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Enter proper surname")]
        public string Surname { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
