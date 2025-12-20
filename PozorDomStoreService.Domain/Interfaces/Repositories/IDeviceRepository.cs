using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<Guid> CreateAsync(Guid deviceTypeId, string name, string description, string imageUrl, double price);
        Task<List<DeviceEntity>> GetAllAsync();
        Task<DeviceEntity?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Guid id, Guid deviceTypeId, string name, string description, string imageUrl, double price);
        Task<int> DeleteAsync(Guid id);
    }
}
