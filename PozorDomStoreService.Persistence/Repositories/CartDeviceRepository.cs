using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class CartDeviceRepository(PozorDomStoreServiceDbContext context) : ICartDeviceRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task AddDeviceToCartAsync(Guid cartId, Guid deviceId, int quantity = 1)
        {
            var cartDevice = new CartDeviceEntity
            {
                CartId = cartId,
                DeviceId = deviceId,
                Quantity = quantity
            };

            await _context.CartDevices.AddAsync(cartDevice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartDeviceEntity>> GetDevicesByCartIdAsync(Guid cartId)
        {
            return await _context.CartDevices
                .AsNoTracking()
                .Where(cd => cd.CartId == cartId)
                .ToListAsync();
        }

        public async Task<int> UpdateDeviceQuantityAsync(Guid id, int quantity)
        {
            return await _context.CartDevices
                .Where(cd => cd.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(cd => cd.Quantity, quantity));
        }

        public async Task<int> RemoveDeviceFromCartAsync(Guid id)
        {
            return await _context.CartDevices
                .Where(cd => cd.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
