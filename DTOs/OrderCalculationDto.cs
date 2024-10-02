namespace ECommerceWebsite.DTOs
{
    public class OrderCalculationDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalCost { get; set; }
        public List<OrderedProduct>? Products { get; set; }
    }

    public class OrderedProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
