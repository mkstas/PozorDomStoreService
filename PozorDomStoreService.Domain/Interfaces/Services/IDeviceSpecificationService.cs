using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceSpecificationService
    {
        Task<Guid> CreateDeviceSpecificationAsync(Guid deviceId, Guid specificationId);
        Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync(Guid deviceId);
        Task<DeviceSpecificationEntity> GetDeviceSpecificationByIdAsync(Guid deviceSpecificationId);
        Task UpdateDeviceSpecificationByIdAsync(Guid deviceSpecificationId, Guid deviceId, Guid specificationId);
        Task DeleteDeviceSpecificationByIdAsync(Guid deviceSpecificationId);
    }
}
