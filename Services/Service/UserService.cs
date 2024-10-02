using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Helpers;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using Microsoft.AspNetCore.Identity;

namespace ECommerceWebsite.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<User?> CreateAsync(CreateUserDto userDto)
        {
            var TOMIWA = await _userRepository.GetByEmailAsync(userDto.Email);
            if (TOMIWA == null)
            {
                return null;
            }
            var user = UserMapper.FromCreatedToUserDto(userDto);

            return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }

           _userRepository.DeleteAsync(user);
            return true;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return UserMapper.ToUSerDto(user);
        }

        public async Task<IEnumerable<UserDto?>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            if (users == null)
            {
                return null;
            }

            var userDto = new List<UserDto>();
            foreach (var user in users)
            {
                userDto.Add(UserMapper.ToUSerDto(user));
            }
            return userDto;
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(userDto.FirstName))
            {
                user.FirstName = userDto.FirstName;
            }

            if (!string.IsNullOrEmpty(userDto.LastName))
            {
                user.LastName = userDto.LastName;
            }
            if (!string.IsNullOrEmpty(userDto.Email))
            {
                user.Email = userDto.Email;
            }

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.Password = userDto.Password;
            }

            if (!string.IsNullOrEmpty(userDto.Address))
            {
                user.Address = userDto.Address;

            }

            if (!string.IsNullOrEmpty(userDto.Phone))
            {
                user.Phone = userDto.Phone;
            }                

            _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
