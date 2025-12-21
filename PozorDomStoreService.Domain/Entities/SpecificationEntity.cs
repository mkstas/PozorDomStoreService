namespace PozorDomStoreService.Domain.Entities
{
    public class SpecificationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
    }
}
