namespace PozorDomStoreService.Domain.Entities
{
    public class DeviceEntity(Guid id, Guid deviceTypeId, string name, double price)
    {
        public Guid Id { get; set; } = id;
        public Guid DeviceTypeId { get; set; } = deviceTypeId;
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DeviceTypeEntity? DeviceType { get; set; }
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
        public List<CartDeviceEntity> CartDevices { get; set; } = [];
    }
}
