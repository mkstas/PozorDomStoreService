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
}
