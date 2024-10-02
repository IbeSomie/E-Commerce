using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Product.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async void DeleteAsync(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Product.Include(x => x.Image)
                .Include(x => x.Category).FirstOrDefaultAsync(i => i.ProductId == id);
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            return await _context.Product.Include(x => x.Image).Include(x => x.Category).ToListAsync();
        }

        public async Task UpdateAsync(Product updateProductDto)
        {
            _context.Entry(updateProductDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
