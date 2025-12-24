using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class OrderRepository(PozorDomStoreServiceDbContext context) : IOrderRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> AddOrderAsync(Guid userId)
        {
            var order = new OrderEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderEntity>> GetOrdersByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<OrderEntity?> GetOrderByOrderIdAsync(Guid orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<OrderEntity?> GetOrderByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.UserId == userId);
        }

        public async Task<int> ChangeOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId)
                .ExecuteUpdateAsync(setters => setters
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
