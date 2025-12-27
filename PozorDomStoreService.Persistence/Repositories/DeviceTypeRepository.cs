using Microsoft.EntityFrameworkCore;
using Npgsql;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Persistence.Extensions;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class DeviceTypeRepository(PozorDomStoreServiceDbContext context) : IDeviceTypeRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateDeviceTypeAsync(string name)
        {
            var deviceType = new DeviceTypeEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
            };

            await _context.DeviceTypes.AddAsync(deviceType);

            try
            {
                await _context.SaveChangesAsync();

                return deviceType.Id;
            }
            catch (DbUpdateException ex) when (ex.IsUniqueCreateConstraintViolation("IX_DeviceTypes_Name"))
            {
                throw new ConflictException($"Device type with name ${name} is already exists.");
            }
        }

        public async Task<List<DeviceTypeEntity>> GetDeviceTypeAllAsync()
        {
            return await _context.DeviceTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeviceTypeEntity?> GetDeviceTypeByIdAsync(Guid devieTypeId)
        {
            return await _context.DeviceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(dt => dt.Id == devieTypeId);
        }

        public async Task<int> UpdateDeviceTypeByIdAsync(Guid devieTypeId, string name)
        {
            try
            {
                return await _context.DeviceTypes
                    .Where(dt => dt.Id == devieTypeId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(dt => dt.Name, name));
            }
            catch (PostgresException ex) when (ex.IsUniqueUpdateKeyViolation("IX_DeviceTypes_Name"))
            {
                throw new ConflictException($"Device type with name ${name} is already exists.");
            }
        }

        public async Task<int> DeleteDeviceTypeByIdAsync(Guid devieTypeId)
        {
            return await _context.DeviceTypes
                .Where(dt => dt.Id == devieTypeId)
                .ExecuteDeleteAsync();
        }
    }
}
