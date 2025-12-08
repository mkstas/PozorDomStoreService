using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Domain.Entities
{
    public class OrderEntity(Guid id, Guid userId)
    {
        public Guid Id { get; set; } = id;
        public Guid UserId { get; set; } = userId;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
