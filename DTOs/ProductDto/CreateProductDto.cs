using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.ProductDto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> ImageLink {  get; set; }
        public List<int> Categories { get; set; }
    }
}
