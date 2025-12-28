using Microsoft.EntityFrameworkCore;
using Npgsql;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Persistence.Extensions;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceRepository(PozorDomStoreServiceDbContext context) : IDeviceRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateDeviceAsync(Guid deviceTypeId, string name, string description, double price)
        {
            var device = new DeviceEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price
            };

            await _context.Devices.AddAsync(device);

            try
            {
                await _context.SaveChangesAsync();

                return device.Id;
            }
            catch (DbUpdateException ex) when (ex.IsUniqueCreateConstraintViolation("IX_Devices_Name"))
            {
                throw new ConflictException($"Device with name ${name} is already exists.");
            }
        }

        public async Task<List<DeviceEntity>> GetDeviceAllAsync()
        {
            return await _context.Devices
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeviceEntity?> GetDeviceByIdAsync(Guid deviceId)
        {
            return await _context.Devices
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == deviceId);
        }

        public async Task<int> UpdateDeviceByIdAsync(Guid deviceId, Guid deviceTypeId, string name, string description, double price)
        {
            try
            {
                return await _context.Devices
                    .Where(d => d.Id == deviceId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(d => d.DeviceTypeId, deviceTypeId)
                        .SetProperty(d => d.Name, name)
                        .SetProperty(d => d.Description, description)
                        .SetProperty(d => d.Price, price));
            }
            catch (PostgresException ex) when (ex.IsUniqueUpdateKeyViolation("IX_Devices_Name"))
            {
                throw new ConflictException($"Device with name ${name} is already exists.");
            }
        }

        public async Task<int> UpdateDeviceImageByIdAsync(Guid deviceId, string imageUrl)
        {
            return await _context.Devices
                .Where(d => d.Id == deviceId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(s => s.ImageUrl, imageUrl));
        }

        public async Task<int> DeleteDeviceByIdAsync(Guid deviceId)
        {
            return await _context.Devices
                .Where(d => d.Id == deviceId)
                .ExecuteDeleteAsync();
        }
    }
}
