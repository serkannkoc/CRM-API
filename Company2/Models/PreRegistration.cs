using System;
using System.Collections.Generic;

#nullable disable

namespace Company2.Models
{
    public partial class PreRegistration 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Hash { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
