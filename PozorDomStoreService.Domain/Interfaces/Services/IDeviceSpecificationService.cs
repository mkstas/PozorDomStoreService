using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceSpecificationService
    {
        Task<Guid> CreateDeviceSpecificationAsync(Guid deviceId, Guid specificationId);
        Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync();
        Task<DeviceSpecificationEntity> GetDeviceSpecificationByIdAsync(Guid id);
        Task UpdateDeviceSpecificationAsync(Guid id, Guid deviceId, Guid specificationId);
        Task DeleteDeviceSpecificationAsync(Guid id);
    }
}
