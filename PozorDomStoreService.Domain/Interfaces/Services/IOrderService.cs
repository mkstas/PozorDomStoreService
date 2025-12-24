using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Guid> AddDevicesToOrderAsync(Guid userId, List<CartDeviceEntity> cartDevices);
        Task<List<OrderEntity>> GetOrdersByUserIdAsync(Guid userId);
        Task<OrderEntity> GetOrderByOrderIdAsync(Guid orderId);
    }
}