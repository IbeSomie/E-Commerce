using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductService _productService;
        public ProductController(ApplicationDBContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductAsync()
        {
            var product = await _productService.GetProductAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> PostProduct(CreateProductDto productDto)
        {
            var data = await _productService.CreateAsync(productDto);

            if (data == null)
            {
                return NoContent();
            }
            return CreatedAtAction("GetProduct", new { id = data.ProductId }, productDto);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<Product?>> UpdateAsync(int id, UpdateProductDto productDto)
        {
            var product = await _productService.UpdateAsync(id, productDto);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }
        [HttpDelete]
        [Route ("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var product = await _productService.DeleteAsync(id);
            if (product == false)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
