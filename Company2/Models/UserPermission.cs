using System;
using System.Collections.Generic;

#nullable disable

namespace Company2.Models
{
    public partial class UserPermission
    {
        public UserPermission()
        {
            ProductUserPermissions = new HashSet<ProductUserPermission>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProductUserPermission> ProductUserPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
