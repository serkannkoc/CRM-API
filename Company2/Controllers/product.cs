using Company2.Services;
using Company2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Company2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class product : ControllerBase
    {
        public ProductService _productService;
        public product(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] ProductAddVM product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var data = _productService.GetAllProducts();
            return Ok(data);
        }
        [HttpGet("get-products-by-permission-id/{id}")]
        public IActionResult GetProductsByPermissionId(int id)
        {
            var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
            if (!id.ToString().Equals(userId))
            {
                return BadRequest("Tokendaki kullanıcıyla girilen ID aynı değil!!!");
            }
            else
            {
                var data = _productService.GetProductByPermissionId(id);
                return Ok(data);
            }
            
        }
    }
}
