using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Infrastructure.Exceptions;

namespace PozorDomStoreService.Application.Services
{
    public class DeviceSpecificationService(
        IDeviceRepository deviceRepository,
        ISpecificationRepository specificationRepository,
        IDeviceSpecificationRepository deviceSpecificationRepository) : IDeviceSpecificationService
    {
        private readonly IDeviceRepository _deviceRepository = deviceRepository;
        private readonly ISpecificationRepository _specificationRepository = specificationRepository;
        private readonly IDeviceSpecificationRepository _deviceSpecificationRepository = deviceSpecificationRepository;

        public async Task<Guid> CreateDeviceSpecificationAsync(Guid deviceId, Guid specificationId)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(deviceId)
                ?? throw new NotFoundException($"Device with id {deviceId} does not exist.");

            var specification = await _specificationRepository.GetSpecificationByIdAsync(specificationId)
                ?? throw new NotFoundException($"Specification with id {specificationId} does not exist.");

            return await _deviceSpecificationRepository.CreateDeviceSpecificationAsync(device.Id, specification.Id);
        }

        public async Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync(Guid deviceId)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(deviceId)
                ?? throw new NotFoundException($"Device with id {deviceId} does not exist.");

            var deviceSpecifications = await _deviceSpecificationRepository.GetDeviceSpecificationAllAsync(device.Id);

            if (deviceSpecifications.Count == 0)
                throw new NotFoundException($"Specifcations for device with id {device.Id} do not exist.");

            return deviceSpecifications;
        }

        public async Task<DeviceSpecificationEntity> GetDeviceSpecificationByIdAsync(Guid deviceSpecificationId)
        {
            return await _deviceSpecificationRepository.GetDeviceSpecificationByIdAsync(deviceSpecificationId)
                ?? throw new NotFoundException($"Specifcation with id {deviceSpecificationId} does not exist.");
        }

        public async Task UpdateDeviceSpecificationByIdAsync(Guid deviceSpecificationId, Guid deviceId, Guid specificationId)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(deviceId)
                ?? throw new NotFoundException($"Device with id {deviceId} does not exist.");

            var specification = await _specificationRepository.GetSpecificationByIdAsync(specificationId)
                ?? throw new NotFoundException($"Specification with id {specificationId} does not exist.");

            var rows = await _deviceSpecificationRepository
                .UpdateDeviceSpecificationByIdAsync(deviceSpecificationId, device.Id, specification.Id);

            if (rows == 0)
                throw new NotFoundException($"Specifcation with id {deviceSpecificationId} does not exist.");
        }

        public async Task DeleteDeviceSpecificationByIdAsync(Guid deviceSpecificationId)
        {
            var rows = await _deviceSpecificationRepository.DeleteDeviceSpecificationByIdAsync(deviceSpecificationId);

            if (rows == 0)
                throw new NotFoundException($"Specifcation with id {deviceSpecificationId} does not exist.");
        }
    }
}
