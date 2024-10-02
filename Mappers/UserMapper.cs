using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUSerDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Phone = userModel.Phone,
                Address = userModel.Address,
            };
        }

        public static User FromCreatedToUserDto(this CreateUserDto userDto) 
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                Phone = userDto.Phone,
                Address = userDto.Address,
            };
        }

    }
}
