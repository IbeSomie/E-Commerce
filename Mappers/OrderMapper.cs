using ECommerceWebsite.DTOs;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order OrderModel)
        {
            return new OrderDto
            {
                OrderId = OrderModel.OrderId,
                UserId = OrderModel.UserId,
                CreatedDate = DateTime.UtcNow.AddHours(1),

            };
        }

        public static OrderCalculationDto ToOrderCalculationsDto(this Order order, List<OrderDetails> orderDetails)
        {
            decimal totalCost = 0;
            var products = new List<OrderedProduct>();
            foreach (var product in orderDetails)
            {
                products.Add(new OrderedProduct
                {
                    Name = product.Product.Name,
                    Price = product.Product.Price,
                    Quantity = product.Product.Quantity,
                });
                totalCost += product.Product.Price * product.Product.Quantity;
            }
            return new OrderCalculationDto
            {
                OrderId = order.OrderId,
                CustomerId = order.UserId,
                TotalCost = totalCost,
                Products = products
            };
        }

        public static Order FromCreatedToOrderDto(this CreateOrderDto orderDto)
        {
            return new Order
            {
                UserId = orderDto.UsertId,
                CreatedDate = DateTime.UtcNow.AddHours(1),
            };
        }

    }
}
