using ECommerceWebsite.DTOs.OrderDetailsDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.ProductService
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        /** public async Task<OrderDetails?> CreateAsync(CreateOrderDetailsDto orderDetailsDto)
        {
            var orderDetails = OrderDetailsMapper.FromCreatedToOrderDetailsDto(orderDetailsDto);
            return await _orderDetailsRepository.CreateAsync(orderDetails);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
            if (orderDetails == null)
            {
                return false;
            }
            _orderDetailsRepository.DeleteAsync(orderDetails);
            return true;
        }

        public async Task<OrderDetails?> GetByIdAsync(int id)
        {
            var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetails?>> GetOrderDetailsAsync()
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetailsAsync();
            return orderDetails;
        }

        public async Task<OrderDetails?> UpdateAsync(int id, UpdateOrderDetatailsDto orderDetailsDto)
        {
            var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
            if (orderDetails == null)
            {
                return null;
            }

            orderDetails.Quantity = orderDetailsDto.Quantity;
            orderDetails.OrderId = orderDetailsDto.OrderId;
            orderDetails.ProductId = orderDetailsDto.ProductId;
            orderDetails.CategoryId = orderDetailsDto.CategoryId;


            _orderDetailsRepository.UpdateAsync(orderDetails);
            return orderDetails;
        } **/
    }
}
