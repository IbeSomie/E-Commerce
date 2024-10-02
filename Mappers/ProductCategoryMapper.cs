using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryDto ToProductCategoryDto(this ProductCategory productCategoryModel)
        {
            return new ProductCategoryDto
            {
                ProductCategoryId = productCategoryModel.ProductCategoryId,
                ProductId = productCategoryModel.ProductId,
                CategoryId = productCategoryModel.CategoryId

            };
        }

        public static ProductCategory FromCreatedToProductCategoryDto(this CreateProductCategoryDto productCategoryDto)
        {
            return new ProductCategory
            {
                ProductId = productCategoryDto.ProductId,
                CategoryId = productCategoryDto.CategoryId
            };
        }

    }

}

