using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECommerceWebsite.DTOs.UserAuthenticationDto
{
    public class UserAuthenticationDto
    {
        [Key]
        public int UserAuthenticationId { get; set; }
        public string Email { get; set; }

    }
}
