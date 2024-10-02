using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class ProductImageMapper
    {
        public static ProductImage CreateProductImage(this string image, Product product)
        {
            return new ProductImage
            {
                ImageBase64 = image,
                CreatedDate = DateTime.UtcNow.AddHours(1),
                ProductId = product.ProductId
            };
        }
    }
}
