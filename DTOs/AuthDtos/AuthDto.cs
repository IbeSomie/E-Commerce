using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.AuthDtos
{
    public class AuthDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
