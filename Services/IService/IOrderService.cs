using ECommerceWebsite.DTOs;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services.IService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderCalculationDto?>> GetOrderAsync();
        Task<OrderCalculationDto?> GetByIdAsync(int id);
        Task<Order?> CreateAsync(CreateOrderDto orderDto);
        //Task<Order?> UpdateAsync(int id, UpdateOrderDto orderDto);
        Task<bool> DeleteAsync(int id);

    }
}
