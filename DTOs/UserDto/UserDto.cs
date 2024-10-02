using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.UserDto
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
