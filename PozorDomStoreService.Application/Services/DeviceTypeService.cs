using PozorDomAuthService.Infrastructure.Exceptions;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Application.Services
{
    public class DeviceTypeService(
        IDeviceTypeRepository deviceTypeRepository) : IDeviceTypeService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository = deviceTypeRepository;

        public async Task<Guid> CreateDeviceTypeAsync(string name)
        {
            return await _deviceTypeRepository.CreateAsync(name);
        }

        public async Task<List<DeviceTypeEntity>> GetAllDeviceTypeAsync()
        {
            var deviceTypes = await _deviceTypeRepository.GetAllAsync();

            if (deviceTypes.Count == 0)
            {
                throw new NotFoundException("Device types not found.");
            }

            return deviceTypes;
        }

        public Task<DeviceTypeEntity> GetDeviceTypeByIdAsync(Guid id)
        {
            return _deviceTypeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Device type not found.");
        }

        public async Task UpdateDeviceTypeAsync(Guid id, string name)
        {
            var rows = await _deviceTypeRepository.UpdateAsync(id, name);

            if (rows == 0)
            {
                throw new NotFoundException("Device type not found.");
            }
        }

        public async Task DeleteDeviceTypeAsync(Guid id)
        {
            var rows = await _deviceTypeRepository.DeleteAsync(id);

            if (rows == 0)
            {
                throw new NotFoundException("Device type not found.");
            }
        }
    }
}
