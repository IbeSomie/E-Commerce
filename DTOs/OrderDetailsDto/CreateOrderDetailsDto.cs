using ECommerceWebsite.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.DTOs.OrderDetailsDto
{
    public class CreateOrderDetailsDto
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

    }
}
