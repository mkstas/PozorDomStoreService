using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class OrderRepository(PozorDomStoreServiceDbContext context) : IOrderRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateOrderAsync(Guid userId, string address)
        {
            var order = new OrderEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Address = address
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderEntity>> GetOrderAllByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<OrderEntity?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<int> UpdateOrderStatusByIdAsync(Guid orderId, OrderStatus status)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.Status, status));
        }

        public async Task<int> DeleteOrderByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId)
                .ExecuteDeleteAsync();
        }
    }
}
