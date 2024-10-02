using ECommerceWebsite.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.OrderDetailsDto
{
    public class OrderDetailsDto
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

    }
}
