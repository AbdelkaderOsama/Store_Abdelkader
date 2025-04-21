using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController (IServiceManager serviceManager): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await serviceManager.productService.GetAllProductsAsync();
            if (result == null) return BadRequest();
            return Ok(result);
        }

    }
}
