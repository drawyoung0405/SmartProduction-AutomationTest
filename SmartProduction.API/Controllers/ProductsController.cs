using Microsoft.AspNetCore.Mvc;
using SmartProduction.API.DTOs;
using SmartProduction.API.Interfaces;
using System.Threading.Tasks;

namespace SmartProduction.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService _productService;
            public ProductsController(IProductService productService) { 
            _productService = productService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAllProducts()
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
             [HttpPost]
             public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
             {
                 if (!ModelState.IsValid)
                     return BadRequest(ModelState);
                 var createdProduct = await _productService.CreateProductAsync(dto);
                 return CreatedAtAction(nameof(GetAllProducts), new { id = createdProduct.Id }, createdProduct);
            }
    }
}
