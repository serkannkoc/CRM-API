using Company2.Models;
using Company2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.Services
{
    public class ProductService
    {
        public Company2Context _context;
        public ProductService(Company2Context context)
        {
            _context = context;
        }
        public void AddProduct(ProductAddVM product)
        {
            if (_context.ProductCategories.Where(p => p.Name == product.CategoryName).FirstOrDefault() != null)
            {
                var categoryId = _context.ProductCategories.Where(p => p.Name == product.CategoryName).Select(u => u.Id).FirstOrDefault();
                var _productDetails = new ProductDetail()
                {
                    Name = product.Name,
                    Description = product.Description,
                    CreatedAt = DateTime.Now
                };
                _context.ProductDetails.Add(_productDetails);
                _context.SaveChanges();
                var _product = new Product()
                {
                    Price = product.Price,
                    PaidPrice = product.PaidPrice,
                    Tax = product.Tax,
                    CreatedAt = DateTime.Now,
                    DetailId = _productDetails.Id,
                    CategoryId = categoryId
                };
                _context.Products.Add(_product);
                _context.SaveChanges();
                var _productUserPermissions = new ProductUserPermission()
                {
                    UserPermissionId = product.UserPermissionId,
                    ProductId = _product.Id,
                    CreatedAt = DateTime.Now
                };
                _context.ProductUserPermissions.Add(_productUserPermissions);
                _context.SaveChanges();

            }
            else
            {
                var _productCategory = new ProductCategory()
                            {
                                Name = product.CategoryName,
                                CreatedAt = DateTime.Now,
                            };
                        _context.ProductCategories.Add(_productCategory);
                        _context.SaveChanges();
                var _productDetails = new ProductDetail()
                {
                    Name = product.Name,
                    Description = product.Description,
                    CreatedAt = DateTime.Now
                };
                _context.ProductDetails.Add(_productDetails);
                _context.SaveChanges();
                var _product = new Product()
                {
                    Price = product.Price,
                    PaidPrice = product.PaidPrice,
                    Tax = product.Tax,
                    CreatedAt = DateTime.Now,
                    DetailId = _productDetails.Id,
                    CategoryId = _productCategory.Id
                };
                _context.Products.Add(_product);
                _context.SaveChanges();
                var _productUserPermissions = new ProductUserPermission()
                {
                    UserPermissionId = product.UserPermissionId,
                    ProductId = _product.Id,
                    CreatedAt = DateTime.Now
                };
                _context.ProductUserPermissions.Add(_productUserPermissions);
                _context.SaveChanges();
            }
            
        }
        public List<ProductGetVM> GetAllProducts()
        {
            List<ProductGetVM> productList = new List<ProductGetVM>();
            foreach (var pro in _context.Products.ToList())
            {
                var _product = _context.Products.Where(p => p.Id == pro.Id).Select(product => new ProductGetVM()
                {
                    Id = product.Id,
                    DetailId = product.DetailId,
                    ProductName = product.Detail.Name,
                    Description = product.Detail.Description,
                    Price = product.Price,
                    PaidPrice = product.PaidPrice,
                    Tax = product.Tax,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    CreatedAt = product.CreatedAt,
                    DeletedAt = product.DeletedAt,
                    UpdatedAt = product.UpdatedAt
                }).FirstOrDefault();
                productList.Add(_product);
            }
            return productList;
        }

        public ProductsWithPermissionId GetProductByPermissionId(int userId)
        {
            var userPermissionId = _context.Users.Where(u => u.Id == userId).Select(permissionId => permissionId.UserPermissionId).FirstOrDefault();
            List<int> productIdList = new List<int>();               
            foreach (var product in _context.ProductUserPermissions.ToList())
            {
                if (product.UserPermissionId == userPermissionId)
                    productIdList.Add((int)product.ProductId);
            }
            var productsWithPermissionId = new ProductsWithPermissionId()
            {
            ProductIds = productIdList
            };
            return productsWithPermissionId;
        }
    }
}
