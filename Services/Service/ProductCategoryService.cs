using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.ProductService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<ProductCategory?> CreateAsync(CreateProductCategoryDto productCategoryDto)
        {
            var productCategory = ProductCategoryMapper.FromCreatedToProductCategoryDto(productCategoryDto);
            return await _productCategoryRepository.CreateAsync(productCategory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(id);
            if (productCategory == null)
            {
                return false;
            }
            _productCategoryRepository.DeleteAsync(productCategory);
            return true;
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(id);
            return productCategory;

        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryAsync()
        {
            var productCategory = await _productCategoryRepository.GetProductCategoryAsync();
            return productCategory;
        }

        public async Task<ProductCategory?> UpdateAsync(int id, UpdateProductCategoryDto productCategoryDto)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(id);
            if (productCategory == null)
            {
                return null;
            }

            productCategory.ProductId = productCategoryDto.ProductId;
            productCategory.CategoryId = productCategoryDto.CategoryId;

            _productCategoryRepository.UpdateAsync(productCategory);
            return productCategory;
        }
    }
}
