using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<Guid> CreateDeviceAsync(
            Guid deviceTypeId, string name, string description, double price);
        Task<List<DeviceEntity>> GetDeviceAllAsync();
        Task<DeviceEntity?> GetDeviceByIdAsync(Guid deviceId);
        Task<int> UpdateDeviceByIdAsync(
            Guid deviceId, Guid deviceTypeId, string name, string description, double price);
        Task<int> UpdateDeviceImageByIdAsync(Guid deviceId, string imageUrl);
        Task<int> DeleteDeviceByIdAsync(Guid deviceId);
    }
}
