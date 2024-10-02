using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using ECommerceWebsite.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        private readonly ICategoryService _categoryService;
        public CategoryController(ApplicationDBContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryAsync()
        {
            var category = await _categoryService.GetCategoryAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Category>> PostCategory(CreateCategoryDto categoryDto)
        {
            var data = await _categoryService.CreateAsync(categoryDto);

            if (data == null)
            {
                return NoContent();
            }
            return CreatedAtAction("GetCategory", new { id = data.CategoryId }, categoryDto);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<Category?>> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _categoryService.UpdateAsync(id, categoryDto);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id}")]
        //[Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _categoryService.DeleteAsync(id);
            if (category == false)
            {
                return NotFound();
            }
            return NoContent();

        }



    }
}

