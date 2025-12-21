using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceSpecificationRepository(
        PozorDomStoreServiceDbContext context) : IDeviceSpecificationRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(Guid deviceId, Guid specificationId)
        {
            var deviceSpecification = new DeviceSpecificationEntity
            {
                Id = Guid.NewGuid(),
                DeviceId = deviceId,
                SpecificationId = specificationId
            };

            await _context.DeviceSpecifications.AddAsync(deviceSpecification);
            await _context.SaveChangesAsync();

            return deviceSpecification.Id;
        }

        public Task<List<DeviceSpecificationEntity>> GetAllAsync()
        {
            return _context.DeviceSpecifications
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<DeviceSpecificationEntity?> GetByIdAsync(Guid id)
        {
            return _context.DeviceSpecifications
                .AsNoTracking()
                .FirstOrDefaultAsync(ds => ds.Id == id);    
        }

        public async Task<int> UpdateAsync(Guid id, Guid deviceId, Guid specificationId)
        {
            return await _context.DeviceSpecifications
                .Where(ds => ds.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(ds => ds.DeviceId, deviceId)
                    .SetProperty(ds => ds.SpecificationId, specificationId));
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return _context.DeviceSpecifications
                .Where(ds => ds.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
