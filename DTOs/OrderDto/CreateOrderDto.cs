using ECommerceWebsite.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.DTOs.OrderDto
{
    public class CreateOrderDto
    {
        public int UsertId { get; set; }
        public List<Details> Details { get; set; }
    }

    public class Details
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
