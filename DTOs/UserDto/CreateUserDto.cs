using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.UserDto
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A valid email is Required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least One letter, One number and one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$")]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
