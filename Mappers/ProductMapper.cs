using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel, List<string> images)
        {
            return new ProductDto
            {
                ProductId = productModel.ProductId,
                Name = productModel.Name,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                ImageLinks = images

            };
        }

        public static Product FromCreatedToProductDto(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };
        }

        public static GetProductDto FromProductToGetProductDto(this Product product) 
        {
            return new GetProductDto
            { 
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Image.Select(x => x.ImageBase64).ToList(),
                //Categories = product.Category.Select(x => x.Category.Name).ToList()
            };
        }

    }

}

