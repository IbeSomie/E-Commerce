using ECommerceWebsite.Data;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context) => _context = context;

        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Order.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Order.Include(x => x.Details).FirstOrDefaultAsync(i =>i.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            return await _context.Order.Include(x => x.Details).ToListAsync();
        }

        public async void UpdateAsync(Order updateOrderDto)
        {
            _context.Entry(updateOrderDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
