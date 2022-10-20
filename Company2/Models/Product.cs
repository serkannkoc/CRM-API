using System;
using System.Collections.Generic;

#nullable disable

namespace Company2.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductUserPermissions = new HashSet<ProductUserPermission>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int? DetailId { get; set; }
        public int? CategoryId { get; set; }
        public double? Price { get; set; }
        public double? PaidPrice { get; set; }
        public double? Tax { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductDetail Detail { get; set; }
        public virtual ICollection<ProductUserPermission> ProductUserPermissions { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
