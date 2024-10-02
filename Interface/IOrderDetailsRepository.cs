using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Interface
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync();
        Task<OrderDetails?> GetByIdAsync(int id);
        Task<OrderDetails> CreateAsync(OrderDetails orderDetailsModel);
        void UpdateAsync(OrderDetails updateOrderDetailsDto);
        void DeleteAsync(OrderDetails orderDetails);
        List<OrderDetails>? GetByOrderIdAsync(int id);

    }
}
