using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace ECommerceWebsite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<ProductImage> Image { get; set; }
        public ICollection<ProductCategory> Category { get; set; }
    }
}
