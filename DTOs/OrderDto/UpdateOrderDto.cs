namespace ECommerceWebsite.DTOs.OrderDto
{
    public class UpdateOrderDto
    {
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
    }
}
