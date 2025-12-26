namespace PozorDomStoreService.Domain.Entities
{
    public class DeviceEntity
    {
        public Guid Id { get; set; }
        public Guid DeviceTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;
        public DeviceTypeEntity? DeviceType { get; set; }
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
        public List<CartDeviceEntity> CartDevices { get; set; } = [];
        public List<OrderDeviceEntity> OrderDevices { get; set; } = [];
    }
}
