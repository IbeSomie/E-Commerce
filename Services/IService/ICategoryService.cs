using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category?>> GetCategoryAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(CreateCategoryDto categoryDto);
        Task<Category?> UpdateAsync(int id, UpdateCategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);

    }
}
