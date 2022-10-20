using Company2.Models;
using Company2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.Services
{
    public class SalesService
    {
        public Company2Context _context { get; set; }
        public SalesService(Company2Context context)
        {
            _context = context;
        }

        public void AddSale(SalesVM sale)
        {
            var _sale = new Sale()
            {
                UserId = sale.UserId,
                ProductId = sale.ProductId,
                CreatedAt = DateTime.Now,
                
            };
            _context.Sales.Add(_sale);
            _context.SaveChanges();
        }
    }
}
