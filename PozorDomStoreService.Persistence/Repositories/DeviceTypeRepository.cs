using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceTypeRepository(PozorDomStoreServiceDbContext context) : IDeviceTypeRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(string name)
        {
            var deviceType = new DeviceTypeEntity(
                Guid.NewGuid(), name);

            await _context.DeviceTypes.AddAsync(deviceType);
            await _context.SaveChangesAsync();

            return deviceType.Id;
        }

        public async Task<List<DeviceTypeEntity>> GetAllAsync()
        {
            return await _context.DeviceTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeviceTypeEntity?> GetByIdAsync(Guid id)
        {
            return await _context.DeviceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(dt => dt.Id == id);
        }

        public async Task<int> UpdateAsync(Guid id, string name)
        {
            return await _context.DeviceTypes
                .Where(dt => dt.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(dt => dt.Name, name));
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.DeviceTypes
                .Where(dt => dt.Id == id)
                .ExecuteDeleteAsync();
        }
    }

    public class DeviceRepository(PozorDomStoreServiceDbContext context) : IDeviceRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(Guid deviceTypeId, string name, double price)
        {
            var device = new DeviceEntity(
                Guid.NewGuid(), deviceTypeId, name, price);

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

        public async Task<int> UpdateAsync(Guid id, Guid deviceTypeId, string name, double price)
        {
            return await _context.Devices
                .Where(d => d.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.Name, name));
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.DeviceTypes
                .Where(dt => dt.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
