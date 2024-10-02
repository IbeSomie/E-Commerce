using ECommerceWebsite.Models;
using ECommerceWebsite.DTOs.UserDto;
namespace ECommerceWebsite.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User?>> GetUsersAsync();
        Task<User?>GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string Email);
        Task<User> CreateAsync(User userModel);
        Task UpdateAsync( User updateuserDto);
        Task DeleteAsync(User user);   

    }
}
