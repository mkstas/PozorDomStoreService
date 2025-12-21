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
            var device = await _deviceRepository.GetByIdAsync(deviceId)
                ?? throw new NotFoundException("Device not found");

            var specification = await _specificationRepository.GetByIdAsync(specificationId)
                ?? throw new NotFoundException("Specification not found");

            return await _deviceSpecificationRepository.CreateAsync(device.Id, specification.Id);
        }

        public async Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync()
        {
            var deviceSpecifications = await _deviceSpecificationRepository.GetAllAsync();

            if (deviceSpecifications.Count == 0)
                throw new NotFoundException("Device specifications not found");

            return deviceSpecifications;
        }

        public async Task<DeviceSpecificationEntity> GetDeviceSpecificationByIdAsync(Guid id)
        {
            return await _deviceSpecificationRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Device specification not found");
        }

        public async Task UpdateDeviceSpecificationAsync(Guid id, Guid deviceId, Guid specificationId)
        {
            var device = await _deviceRepository.GetByIdAsync(deviceId)
                ?? throw new NotFoundException("Device not found");

            var specification = await _specificationRepository.GetByIdAsync(specificationId)
                ?? throw new NotFoundException("Specification not found");

            var rows = await _deviceSpecificationRepository.UpdateAsync(id, device.Id, specification.Id);

            if (rows == 0)
                throw new NotFoundException("Device specification not found");
        }

        public async Task DeleteDeviceSpecificationAsync(Guid id)
        {
            var rows = await _deviceSpecificationRepository.DeleteAsync(id);

            if (rows == 0)
                throw new NotFoundException("Device specification not found");
        }
    }
}
