using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class OrderDeviceRepository(PozorDomStoreServiceDbContext context) : IOrderDeviceRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> AddDeviceToOrderAsync(Guid orderId, Guid deviceId, int quantity, double price)
        {
            var orderDevice = new OrderDeviceEntity
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                DeviceId = deviceId,
                Quantity = quantity,
                Price = price
            };

            await _context.OrderDevices.AddAsync(orderDevice);
            await _context.SaveChangesAsync();

            return orderDevice.Id;
        }

        public async Task<List<OrderDeviceEntity>> GetOrderDeviceAllByOrderIdAsync(Guid orderId)
        {
            return await _context.OrderDevices
                .AsNoTracking()
                .Where(od =>  od.OrderId == orderId)
                .ToListAsync();
        }
    }
}
