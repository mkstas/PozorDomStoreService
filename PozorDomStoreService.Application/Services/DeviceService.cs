using Microsoft.AspNetCore.Http;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Infrastructure.Providers;

namespace PozorDomStoreService.Application.Services
{
    public class DeviceService(
        IDeviceTypeRepository deviceTypeRepository,
        IDeviceRepository deviceRepository,
        IImageProvider imageProvider) : IDeviceService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository = deviceTypeRepository;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;
        private readonly IImageProvider _imageProvider = imageProvider;

        public async Task<Guid> CreateDeviceAsync(Guid deviceTypeId, string name, string description, double price)
        {
            var deviceType = await _deviceTypeRepository.GetDeviceTypeByIdAsync(deviceTypeId)
                ?? throw new NotFoundException("Device type does not exists."); ;

            return await _deviceRepository.CreateDeviceAsync(deviceType.Id, name, description, price);
        }

        public async Task<List<DeviceEntity>> GetDeviceAllAsync()
        {
            var devices = await _deviceRepository.GetDeviceAllAsync();

            if (devices.Count == 0)
                throw new NotFoundException("Devices do not exist.");

            return devices;
        }

        public async Task<DeviceEntity> GetDeviceByIdAsync(Guid deviceId)
        {
            return await _deviceRepository.GetDeviceByIdAsync(deviceId)
                ?? throw new NotFoundException($"Device with id {deviceId} does not exist.");
        }

        public async Task UpdateDeviceByIdAsync(Guid deviceId, Guid deviceTypeId, string name, string description, double price)
        {
            var rows = await _deviceRepository.UpdateDeviceByIdAsync(
                deviceId, deviceTypeId, name, description, price);

            if (rows == 0)
                throw new NotFoundException($"Device with id {deviceId} does not exist.");
        }

        public async Task UpdateDeviceImageByIdAsync(Guid deviceId, IFormFile image)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(deviceId)
                ?? throw new NotFoundException($"Device with id {deviceId} does not exist.");

            var imageUrl = await _imageProvider.SaveSingleImage(image.OpenReadStream(), image.FileName);

            await _deviceRepository.UpdateDeviceImageByIdAsync(device.Id, imageUrl);
        }

        public async Task DeleteDeviceByIdAsync(Guid deviceId)
        {
            var rows = await _deviceRepository.DeleteDeviceByIdAsync(deviceId);

            if (rows == 0)
                throw new NotFoundException($"Device with id {deviceId} does not exist.");
        }
    }
}
