using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.ViewModels
{
    public class ProductAddVM
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Enter proper Category name")]
        public string CategoryName { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Enter proper product name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double PaidPrice { get; set; }
        public double Tax { get; set; }
        public int UserPermissionId { get; set; }
    }
}
