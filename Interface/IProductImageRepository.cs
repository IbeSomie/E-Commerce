using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage?>> GetProductImagesAsync();
        Task<ProductImage?> GetByIdAsync(int id);
        Task<ProductImage> CreateAsync(ProductImage productImageModel);
        void UpdateAsync(ProductImage UpdateproductImageDto);
        void DeleteAsync(ProductImage productImage);


    }
}
