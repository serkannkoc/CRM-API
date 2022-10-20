using System;
using System.Collections.Generic;

#nullable disable

namespace Company2.Models
{
    public partial class User
    {
        public User()
        {
            Sales = new HashSet<Sale>();
            UserInformations = new HashSet<UserInformation>();
        }

        public int Id { get; set; }
        public int? UserPermissionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual ICollection<UserInformation> UserInformations { get; set; }
        public virtual UserPermission UserPermission { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        
    }
}
