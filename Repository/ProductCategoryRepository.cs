using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductCategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> CreateAsync(ProductCategory productCategoryModel)
        {
            await _context.ProductCategory.AddAsync(productCategoryModel);
            await _context.SaveChangesAsync();
            return productCategoryModel;
        }

        public async void DeleteAsync(ProductCategory ProductCategory)
        {
             _context.ProductCategory.Remove(ProductCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategory.Include(x => x.Category).FirstOrDefaultAsync(i => i.ProductCategoryId == id);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryAsync()
        {
            return await _context.ProductCategory.Include(x => x.Category).ToListAsync();
        }

        public async void UpdateAsync(ProductCategory updateproductCategoryDto)
        {
            _context.Entry(updateproductCategoryDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
