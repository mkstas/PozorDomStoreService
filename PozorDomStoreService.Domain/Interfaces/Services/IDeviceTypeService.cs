using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceTypeService
    {
        Task<Guid> CreateDeviceTypeAsync(string name);
        Task<List<DeviceTypeEntity>> GetAllDeviceTypeAsync();
        Task<DeviceTypeEntity> GetDeviceTypeByIdAsync(Guid id);
        Task UpdateDeviceTypeAsync(Guid id, string name);
        Task DeleteDeviceTypeAsync(Guid id);
    }
}
