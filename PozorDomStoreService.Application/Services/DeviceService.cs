using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Application.Services
{
    public class DeviceService(
        IDeviceTypeRepository deviceTypeRepository,
        IDeviceRepository deviceRepository) : IDeviceService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository = deviceTypeRepository;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public async Task<Guid> CreateDeviceAsync(Guid deviceTypeId, string name, string description, string imageUrl, double price)
        {
            var deviceType = await _deviceTypeRepository.GetByIdAsync(deviceTypeId)
                ?? throw new NotFoundException("Device type does not existing.");

            return await _deviceRepository.CreateAsync(deviceType.Id, name, description, imageUrl, price);
        }

        public async Task<List<DeviceEntity>> GetAllDeviceAsync()
        {
            var devices = await _deviceRepository.GetAllAsync();

            if (devices.Count == 0)
                throw new NotFoundException("Devices not found.");

            return devices;
        }

        public async Task<DeviceEntity> GetDeviceByIdAsync(Guid id)
        {
            return await _deviceRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Device not found.");
        }

        public async Task UpdateDeviceAsync(Guid id, Guid deviceTypeId, string name, string description, string imageUrl, double price)
        {
            var deviceType = await _deviceTypeRepository.GetByIdAsync(deviceTypeId)
                ?? throw new NotFoundException("Device type does not existing.");

            var rows = await _deviceRepository.UpdateAsync(id, deviceType.Id, name, description, imageUrl, price);

            if (rows == 0)
                throw new NotFoundException("Device not found.");
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            var rows = await _deviceRepository.DeleteAsync(id);

            if (rows == 0)
                throw new NotFoundException("Device not found.");
        }
    }
}
