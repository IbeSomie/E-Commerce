using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services.IService
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoryAsync();
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<ProductCategory?> CreateAsync(CreateProductCategoryDto productCategoryDto);
        Task<ProductCategory?> UpdateAsync(int id, UpdateProductCategoryDto productCategoryDto);
        Task<bool> DeleteAsync(int id);

    }
}
