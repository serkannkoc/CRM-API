using Company2.Services;
using Company2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Company2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class sales : ControllerBase
    {
        public SalesService _salesService { get; set; }
        public sales(SalesService salesService)
        {
            _salesService = salesService;
        }
        [HttpPost("add-sale")]
        public IActionResult AddSale([FromBody] SalesVM sale)
        {
           

            _salesService.AddSale(sale);
            return Ok();
        }
    }
}
