namespace PozorDomStoreService.Domain.Entities
{
    public class OrderDeviceEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid DeviceId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public OrderEntity? Order { get; set; }
        public DeviceEntity? Device { get; set; }
    }
}
