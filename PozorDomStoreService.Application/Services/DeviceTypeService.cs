using PozorDomStoreService.Infrastructure.Exceptions;
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
            return await _deviceTypeRepository.CreateDeviceTypeAsync(name);
        }

        public async Task<List<DeviceTypeEntity>> GetDeviceTypeAllAsync()
        {
            var deviceTypes = await _deviceTypeRepository.GetDeviceTypeAllAsync();

            if (deviceTypes.Count == 0)
                throw new NotFoundException("Device types do not exist.");

            return deviceTypes;
        }

        public async Task<DeviceTypeEntity> GetDeviceTypeByIdAsync(Guid devieTypeId)
        {
            return await _deviceTypeRepository.GetDeviceTypeByIdAsync(devieTypeId)
                ?? throw new NotFoundException($"Device type with id {devieTypeId} does not exist.");
        }

        public async Task UpdateDeviceTypeByIdAsync(Guid devieTypeId, string name)
        {
            var rows = await _deviceTypeRepository.UpdateDeviceTypeByIdAsync(devieTypeId, name);

            if (rows == 0)
                throw new NotFoundException($"Device type with id {devieTypeId} does not exist.");
        }

        public async Task DeleteDeviceTypeByIdAsync(Guid devieTypeId)
        {
            var rows = await _deviceTypeRepository.DeleteDeviceTypeByIdAsync(devieTypeId);

            if (rows == 0)
                throw new NotFoundException($"Device type with id {devieTypeId} does not exist.");
        }
    }
}
