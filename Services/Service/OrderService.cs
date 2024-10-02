using ECommerceWebsite.DTOs;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.DTOs.ProductDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Mappers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.ProductService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderService(IOrderRepository orderRepository,
            IOrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }   

        public async Task<Order?> CreateAsync(CreateOrderDto orderDto)
        {
            var data = OrderMapper.FromCreatedToOrderDto(orderDto);
            var order = await _orderRepository.CreateAsync(data);
            foreach (var item in orderDto.Details)
            {
                var detail = OrderDetailsMapper.FromCreatedToOrderDetailsDto(item, order.OrderId);
                await _orderDetailsRepository.CreateAsync(detail);
            }

            return order;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return false;
            }
            _orderRepository.DeleteAsync(order);
            return true;
        }

        public async Task<OrderCalculationDto?> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            var orderDetails = _orderDetailsRepository.GetByOrderIdAsync(id);
            if (order == null || orderDetails == null)
            {
                return null;
            }

            return OrderMapper.ToOrderCalculationsDto(order, orderDetails);
        }

        public async Task<IEnumerable<OrderCalculationDto?>> GetOrderAsync()
        {
            var result = new List<OrderCalculationDto>();
            var orders = await _orderRepository.GetOrderAsync();
            
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    var orderDetails = _orderDetailsRepository.GetByOrderIdAsync(order.OrderId);
                    result.Add(OrderMapper.ToOrderCalculationsDto(order, orderDetails));
                }
            }
            
            return result;

        }

        /*public async Task<Order?> UpdateAsync(int id, UpdateOrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }

            order.UserId = orderDto.UserId;
            order.CreatedDate = orderDto.CreatedDate;
            order.Quantity = orderDto.Quantity;


            _orderRepository.UpdateAsync(order);
            return order;

        }*/
    }
}
