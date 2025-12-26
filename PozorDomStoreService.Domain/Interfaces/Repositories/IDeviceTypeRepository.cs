using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceTypeRepository
    {
        Task<Guid> CreateDeviceTypeAsync(string name);
        Task<List<DeviceTypeEntity>> GetDeviceTypeAllAsync();
        Task<DeviceTypeEntity?> GetDeviceTypeByIdAsync(Guid devieTypeId);
        Task<int> UpdateDeviceTypeByIdAsync(Guid devieTypeId, string name);
        Task<int> DeleteDeviceTypeByIdAsync(Guid devieTypeId);
    }
}
