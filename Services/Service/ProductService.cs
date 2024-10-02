using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Helpers;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using Microsoft.AspNetCore.Identity;

namespace ECommerceWebsite.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
            IProductImageRepository productImageRepository,
            IProductCategoryRepository productCategoryRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product?> CreateAsync(CreateProductDto productDto)
        {
            foreach (var id in productDto.Categories)
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return null;
                }
            }

            var product =  ProductMapper.FromCreatedToProductDto(productDto);
            var data =  await _productRepository.CreateAsync(product);
            foreach (var link in productDto.ImageLink)
            {
                var image = await ImageConverter.ImageTobase64(link);
                var productImage = ProductImageMapper.CreateProductImage(image, data);
                await _productImageRepository.CreateAsync(productImage);
            }

            foreach (var id in productDto.Categories)
            {
                await _productCategoryRepository.CreateAsync(new ProductCategory()
                {
                    CategoryId = id,
                    ProductId = product.ProductId
                });
            }

            return data;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync (id);
            if (product == null)
            {
                return false;
            }
            _productRepository.DeleteAsync(product);
            return true;
        }

        public async  Task<GetProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return ProductMapper.FromProductToGetProductDto(product);
        }

         public async Task<IEnumerable<GetProductDto?>> GetProductAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            var result = new List<GetProductDto>();
            foreach (var product in products)
            {
                result.Add(ProductMapper.FromProductToGetProductDto(product));
            }
            return result;
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductDto productDto)
        {
             var  product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(productDto.Name))
                
            {
                product.Name = productDto.Name;

            }

            if (productDto.Price >= 0)
            {
                product.Price = productDto.Price;
            }



                
            product.Quantity = productDto.Quantity;

            _productRepository.UpdateAsync(product);
            return product;

        }
    }
}
