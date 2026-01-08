using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IDeviceService
    {
        Task<Guid> CreateDeviceAsync(
            Guid deviceTypeId, string name, string description, double price);
        Task<List<DeviceEntity>> GetDeviceAllAsync();
        Task<DeviceEntity> GetDeviceByIdAsync(Guid deviceId);
        Task UpdateDeviceByIdAsync(
            Guid deviceId, Guid deviceTypeId, string name, string description, double price);
        Task UpdateDeviceImageByIdAsync(Guid deviceId, Stream imageStream, string originalName);
        Task DeleteDeviceByIdAsync(Guid deviceId);
    }
}
