using ECommerceWebsite.Data;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderDetailsRepository(ApplicationDBContext context) => _context = context;

        public async Task<OrderDetails> CreateAsync(OrderDetails orderDetailsModel)
        {
            await _context.OrderDetails.AddAsync(orderDetailsModel);
            await _context.SaveChangesAsync();
            return orderDetailsModel;
        }

        public void DeleteAsync(OrderDetails orderDetails)
        {
            _context.OrderDetails.Remove(orderDetails);
            _context.SaveChanges();
        }

        public async Task<OrderDetails?> GetByIdAsync(int id)
        {
            return await _context.OrderDetails.Include(x => x.Product).FirstOrDefaultAsync(i=> i.OrderDetailsId == id);
        }

        public List<OrderDetails>? GetByOrderIdAsync(int id)
        {
            return _context.OrderDetails.Include(x => x.Product).Where(i => i.OrderId == id).ToList();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync()
        {
            return await _context.OrderDetails.Include(x => x.Product).ToListAsync();
        }

        public async void UpdateAsync(OrderDetails updateOrderDetailsDto)
        {
            _context.Entry(updateOrderDetailsDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
