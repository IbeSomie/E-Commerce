using ECommerceWebsite.Data;
using Microsoft.EntityFrameworkCore;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using ECommerceWebsite.DTOs.ProductDto;

namespace ECommerceWebsite.Repository 
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductImageRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ProductImage> CreateAsync(ProductImage productImageModel)
        {
            await _context.ProductImage.AddAsync(productImageModel);
            await _context.SaveChangesAsync();
            return productImageModel;
        }

        public async void DeleteAsync(ProductImage productImage)
        {
            _context.ProductImage.Remove(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _context.ProductImage.FirstOrDefaultAsync(i => i.ProductImageId == id);
        }

        public async Task<IEnumerable<ProductImage?>> GetProductImagesAsync()
        {
            return await _context.ProductImage.ToListAsync();
        }

        public async void UpdateAsync(ProductImage updateproductImageDto)
        {
            _context.Entry(updateproductImageDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
