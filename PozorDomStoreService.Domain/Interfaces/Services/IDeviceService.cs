using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceService
    {
        Task<Guid> CreateDeviceAsync(Guid deviceTypeId, string name, string description, string imageUrl, double price);
        Task<List<DeviceEntity>> GetAllDeviceAsync();
        Task<DeviceEntity> GetDeviceByIdAsync(Guid id);
        Task UpdateDeviceAsync(Guid id, Guid deviceTypeId, string name, string description, string imageUrl, double price);
        Task DeleteDeviceAsync(Guid id);
    }
}
