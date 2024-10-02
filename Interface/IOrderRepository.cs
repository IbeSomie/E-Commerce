using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order orderModel);
        void UpdateAsync(Order updateOrderDto);
        Task DeleteAsync(Order order);

    }
}
