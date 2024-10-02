using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
