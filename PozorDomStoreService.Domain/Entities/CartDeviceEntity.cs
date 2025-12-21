namespace PozorDomStoreService.Domain.Entities
{
    public class CartDeviceEntity
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid DeviceId { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CartEntity? Cart { get; set; }
        public DeviceEntity? Device { get; set; }
    }
}
