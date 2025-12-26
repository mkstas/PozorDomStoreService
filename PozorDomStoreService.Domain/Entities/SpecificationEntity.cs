namespace PozorDomStoreService.Domain.Entities
{
    public class SpecificationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DeviceSpecificationEntity> DeviceSpecifications { get; set; } = [];
    }
}
