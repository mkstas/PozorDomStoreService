using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceSpecificationRepository
    {
        Task<Guid> CreateAsync(Guid deviceId, Guid specificationId);
        Task<List<DeviceSpecificationEntity>> GetAllAsync();
        Task<DeviceSpecificationEntity?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Guid id, Guid deviceId, Guid specificationId);
        Task<int> DeleteAsync(Guid id);
    }
}
