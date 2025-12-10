using PozorDomAuthService.Infrastructure.Exceptions;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Application.Services
{
    public class DeviceService(
        IDeviceRepository deviceRepository) : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public async Task<Guid> CreateDeviceAsync(Guid deviceTypeId, string name, double price)
        {
            return await _deviceRepository.CreateAsync(deviceTypeId, name, price);
        }

        public async Task<List<DeviceEntity>> GetAllDeviceAsync()
        {
            var devices = await _deviceRepository.GetAllAsync();

            if (devices.Count == 0)
            {
                throw new NotFoundException("Devices not found.");
            }

            return devices;
        }

        public async Task<DeviceEntity?> GetDeviceByIdAsync(Guid id)
        {
            return await _deviceRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Device not found.");
        }

        public async Task UpdateDeviceAsync(Guid id, Guid deviceTypeId, string name, double price)
        {
            var rows = await _deviceRepository.UpdateAsync(id, deviceTypeId, name, price);

            if (rows == 0)
            {
                throw new NotFoundException("Device not found.");
            }
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            var rows = await _deviceRepository.DeleteAsync(id);

            if (rows == 0)
            {
                throw new NotFoundException("Device not found.");
            }
        }
    }
}
