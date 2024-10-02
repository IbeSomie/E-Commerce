using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetProductsAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task UpdateAsync(Product updateproductDto);
        void DeleteAsync(Product product);

    }
}
