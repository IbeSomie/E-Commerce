using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category categoryModel);
        Task UpdateAsync(Category updateCategoryDto);
        void DeleteAsync(Category category);

    }
}
