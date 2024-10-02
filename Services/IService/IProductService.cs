using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto?>> GetProductAsync();
        Task<GetProductDto?> GetByIdAsync(int id);
        Task<Product?> CreateAsync(CreateProductDto productDto);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productDto);
        Task<bool> DeleteAsync(int id);

    }
}
