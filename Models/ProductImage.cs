using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public string ImageBase64 { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
