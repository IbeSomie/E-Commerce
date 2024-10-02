using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.UserDto
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }        
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least One letter, One number and one special character.")]
        public string Password { get; set; }
        [RegularExpression(@"^\d{11}$")]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
