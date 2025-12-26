namespace PozorDomStoreService.Domain.Entities
{
    public class CartEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartDeviceEntity> CartDevices { get; set; } = [];
    }
}
