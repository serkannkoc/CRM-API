using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.ViewModels
{
    public class PreRegistrationVM
    {
        [RegularExpression (@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+",
            ErrorMessage ="Enter proper email")]
        public string Email { get; set; }
        [RegularExpression(@"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}",
            ErrorMessage = "Enter proper ipv4 address")]
        public string Ip { get; set; }
    }
}
