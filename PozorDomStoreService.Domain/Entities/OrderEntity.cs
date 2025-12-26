using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Domain.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderDeviceEntity> OrderDevices { get; set; } = [];
    }
}
