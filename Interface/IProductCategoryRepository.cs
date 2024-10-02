using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoryAsync();
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<ProductCategory> CreateAsync(ProductCategory productCategoryModel);
        void UpdateAsync(ProductCategory updateproductCategoryDto);
        void DeleteAsync(ProductCategory ProductCategory);

    }
}
