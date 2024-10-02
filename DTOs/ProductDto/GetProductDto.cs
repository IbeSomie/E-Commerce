using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.ProductDto
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string>? Images { get; set; }
        //public List<string?>? Categories { get; set; }
    }
}
