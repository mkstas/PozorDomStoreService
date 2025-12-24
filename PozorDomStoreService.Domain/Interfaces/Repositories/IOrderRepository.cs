using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> AddOrderAsync(Guid userId);
        Task<List<OrderEntity>> GetOrdersByUserIdAsync(Guid userId);
        Task<OrderEntity?> GetOrderByOrderIdAsync(Guid orderId);
        Task<int> ChangeOrderStatusAsync(Guid orderId, OrderStatus status);
        Task<int> DeleteOrderByIdAsync(Guid orderId);
    }
}