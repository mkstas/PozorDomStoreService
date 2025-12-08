namespace PozorDomStoreService.Domain.Entities
{
    public class CartEntity(Guid id, Guid userId)
    {
        public Guid Id { get; set; } = id;
        public Guid UserId { get; set; } = userId;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CartDeviceEntity> CartDevices { get; set; } = [];
    }
}
