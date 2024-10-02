using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Category.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public void DeleteAsync(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();

        }

        public async Task<Category?> GetByIdAsync(int id)
        {
           return await _context.Category.FirstOrDefaultAsync(i => i.CategoryId == id);

        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task UpdateAsync(Category updateCategoryDto)
        {
            _context.Entry(updateCategoryDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
