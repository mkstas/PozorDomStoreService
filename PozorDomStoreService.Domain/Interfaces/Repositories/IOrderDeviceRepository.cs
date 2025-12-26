using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IOrderDeviceRepository
    {
        Task<Guid> AddDeviceToOrderAsync(Guid orderId, Guid deviceId, int quantity, double price);
        Task<List<OrderDeviceEntity>> GetOrderDeviceAllByOrderIdAsync(Guid orderId);
    }
}
