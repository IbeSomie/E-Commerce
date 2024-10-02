using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Interface;
using Microsoft.EntityFrameworkCore;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task DeleteAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string Email)
        {
            return await _context.User.FirstOrDefaultAsync(i => i.Email== Email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(i => i.UserId == id);
        }

        public async Task<IEnumerable<User?>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task UpdateAsync(User updateUserDto)
        {

            _context.Entry(updateUserDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
           
        }
    }
}
