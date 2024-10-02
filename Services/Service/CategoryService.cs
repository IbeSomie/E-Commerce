using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.DTOs.ProductCategoryDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.ProductService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = CategoryMapper.FromCreatedToCategoryDto(categoryDto);
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            _categoryRepository.DeleteAsync(category);
            return true;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category;
        }

        public async Task<IEnumerable<Category?>> GetCategoryAsync()
        {
            var category = await _categoryRepository.GetCategoryAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            _categoryRepository.UpdateAsync(category);
            return category;
        }
    }
}
