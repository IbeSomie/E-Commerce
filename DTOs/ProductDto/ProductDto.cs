using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.ProductDto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Price")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public List<string> ImageLinks { get; set; }

    }
}
