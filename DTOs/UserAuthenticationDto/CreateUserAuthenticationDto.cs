using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECommerceWebsite.DTOs.UserAuthenticationDto
{
    public class CreateUserAuthenticationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&{8, }$", ErrorMessage = "Password must be at least 8 characters long and contain at least One letter, One number and one special character.")]
        [PasswordPropertyText(true)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
