namespace ECommerceWebsite.DTOs.OrderDto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
    }
}
