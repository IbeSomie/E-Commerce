using ECommerceWebsite.DTOs.OrderDetailsDto;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class OrderDetailsMapper
    {
        public static OrderDetailsDto ToOrderDetailsDto(this OrderDetails orderDetailsModel)
        {
            return new OrderDetailsDto
            {
                OrderDetailsId = orderDetailsModel.OrderDetailsId,
                Quantity = orderDetailsModel.Quantity,
                OrderId = orderDetailsModel.OrderId,
                ProductId = orderDetailsModel.ProductId,



            };
        }

        public static OrderDetails FromCreatedToOrderDetailsDto(this Details orderDetailsDto, int orderId)
        {
            return new OrderDetails
            {
                Quantity = orderDetailsDto.Quantity,
                OrderId = orderId,
                ProductId = orderDetailsDto.ProductId
            };
        }


    }
}
