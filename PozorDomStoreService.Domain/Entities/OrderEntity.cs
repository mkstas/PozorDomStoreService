using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Domain.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderDeviceEntity> OrderDevices { get; set; } = [];
    }
}
