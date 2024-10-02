using ECommerceWebsite.DTOs.UserDto;
using System.Text.RegularExpressions;

namespace ECommerceWebsite.Helpers
{
    public static class UserValidator
    {
        public static bool ValidateCreateUserDto(CreateUserDto createUserDto)
        {
            if (string.IsNullOrEmpty(createUserDto.FirstName) || createUserDto.FirstName.Length < 3)
            {
                return false;
            }

            if (string.IsNullOrEmpty(createUserDto.LastName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(createUserDto.Email)) 
            { 
                return false;
            }

            if (string.IsNullOrEmpty(createUserDto.Password) || createUserDto.Password.Length < 8)
            { 
                return false;
            }

            if (IsValidPhone(createUserDto.Phone))
            {
                return false;
            }

            if (string.IsNullOrEmpty(createUserDto.Address))
            {
                return false;
            }
           
            //


            return true;
        }

        private static bool IsValidPhone(string Phone)
        {
            return Regex.IsMatch(Phone, @"^\d{11}$");
        }
    }
}
