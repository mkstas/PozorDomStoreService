using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceTypeService
    {
        Task<Guid> CreateDeviceTypeAsync(string name);
        Task<List<DeviceTypeEntity>> GetDeviceTypeAllAsync();
        Task<DeviceTypeEntity> GetDeviceTypeByIdAsync(Guid devieTypeId);
        Task UpdateDeviceTypeByIdAsync(Guid devieTypeId, string name);
        Task DeleteDeviceTypeByIdAsync(Guid devieTypeId);
    }
}
