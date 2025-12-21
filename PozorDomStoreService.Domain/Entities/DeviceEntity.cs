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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DeviceTypeEntity? DeviceType { get; set; }
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
    }
}
