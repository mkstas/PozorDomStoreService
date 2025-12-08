namespace PozorDomStoreService.Domain.Entities
{
    public class SpecificationEntity(Guid id, string name)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
    }
}
