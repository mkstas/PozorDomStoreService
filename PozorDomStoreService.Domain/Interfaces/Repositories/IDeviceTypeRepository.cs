using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceTypeRepository
    {
        Task<Guid> CreateAsync(string name);
        Task<List<DeviceTypeEntity>> GetAllAsync();
        Task<DeviceTypeEntity?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Guid id, string name);
        Task<int> DeleteAsync(Guid id);
    }
}
