using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(Guid userId, List<CartDeviceEntity> cartDevices, string address);
        Task<List<OrderEntity>> GetOrderAllByUserIdAsync(Guid userId);
        Task<OrderEntity> GetOrderByOrderIdAsync(Guid orderId);
    }
}
