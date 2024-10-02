using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services.IService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto?>> GetUsersAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<User?> CreateAsync(CreateUserDto userDto);
        Task<User?> UpdateAsync(int id, UpdateUserDto userDto);
        Task<bool> DeleteAsync(int id);
    }
}
