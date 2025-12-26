using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceSpecificationRepository
    {
        Task<Guid> CreateDeviceSpecificationAsync(Guid deviceId, Guid specificationId);
        Task<List<DeviceSpecificationEntity>> GetDeviceSpecificationAllAsync(Guid deviceId);
        Task<DeviceSpecificationEntity?> GetDeviceSpecificationByIdAsync(Guid deviceSpecificationId);
        Task<int> UpdateDeviceSpecificationByIdAsync(Guid deviceSpecificationId, Guid deviceId, Guid specificationId);
        Task<int> DeleteDeviceSpecificationByIdAsync(Guid deviceSpecificationId);
    }
}
