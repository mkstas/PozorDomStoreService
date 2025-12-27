using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceSpecificationRepository(
        PozorDomStoreServiceDbContext context) : IDeviceSpecificationRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateDeviceSpecificationAsync(Guid deviceId, Guid specificationId)
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

        public async Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync(Guid deviceId)
        {
            return await _context.DeviceSpecifications
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeviceSpecificationEntity?> GetDeviceSpecificationByIdAsync(Guid deviceSpecificationId)
        {
            return await _context.DeviceSpecifications
                .AsNoTracking()
                .FirstOrDefaultAsync(ds => ds.Id == deviceSpecificationId);
        }

        public async Task<int> UpdateDeviceSpecificationByIdAsync(Guid deviceSpecificationId, Guid deviceId, Guid specificationId)
        {
            return await _context.DeviceSpecifications
                .Where(ds => ds.Id == deviceSpecificationId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(ds => ds.DeviceId, deviceId)
                    .SetProperty(ds => ds.SpecificationId, specificationId));
        }

        public async Task<int> DeleteDeviceSpecificationByIdAsync(Guid deviceSpecificationId)
        {
            return await _context.DeviceSpecifications
                .Where(ds => ds.Id == deviceSpecificationId)
                .ExecuteDeleteAsync();
        }
    }
}
