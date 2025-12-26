using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> CreateOrderAsync(Guid userId, string address);
        Task<List<OrderEntity>> GetOrderAllByUserIdAsync(Guid userId);
        Task<OrderEntity?> GetOrderByIdAsync(Guid orderId);
        Task<int> UpdateOrderStatusByIdAsync(Guid orderId, OrderStatus status);
        Task<int> DeleteOrderByIdAsync(Guid orderId);
    }
}
