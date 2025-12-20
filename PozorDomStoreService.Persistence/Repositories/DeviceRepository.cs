using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceRepository(PozorDomStoreServiceDbContext context) : IDeviceRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(Guid deviceTypeId, string name, string description, string imageUrl, double price)
        {
            var device = new DeviceEntity
            {
                Id = Guid.NewGuid(),
                DeviceTypeId = deviceTypeId,
                Name = name,
                Description = description,
                Price = price,
                ImageUrl = imageUrl
            };

            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();

            return device.Id;
        }

        public async Task<List<DeviceEntity>> GetAllAsync()
        {
            return await _context.Devices
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeviceEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Devices
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> UpdateAsync(Guid id, Guid deviceTypeId, string name, string description, string imageUrl, double price)
        {
            return await _context.Devices
                .Where(d => d.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.DeviceTypeId, deviceTypeId)
                    .SetProperty(d => d.Name, name)
                    .SetProperty(d => d.Description, description)
                    .SetProperty(d => d.ImageUrl, imageUrl)
                    .SetProperty(d => d.Price, price));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.Devices
                .Where(dt => dt.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
