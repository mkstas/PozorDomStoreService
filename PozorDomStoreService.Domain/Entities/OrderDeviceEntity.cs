namespace PozorDomStoreService.Domain.Entities
{
    public class OrderDeviceEntity(Guid id, Guid orderId, Guid deviceId, int quantity, double price)
    {
        public Guid Id { get; set; } = id;
        public Guid OrderId { get; set; } = orderId;
        public Guid DeviceId { get; set; } = deviceId;
        public int Quantity { get; set; } = quantity;
        public double Price { get; set; } = price;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public OrderEntity? Order { get; set; }
        public DeviceEntity? Device { get; set; }
    }
}
