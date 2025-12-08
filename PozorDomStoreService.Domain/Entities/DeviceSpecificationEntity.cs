namespace PozorDomStoreService.Domain.Entities
{
    public class DeviceSpecificationEntity(
        Guid id,
        Guid deviceId,
        Guid specificationId,
        string value)
    {
        public Guid Id { get; set; } = id;
        public Guid DeviceId { get; set; } = deviceId;
        public Guid SpecificationId { get; set; } = specificationId;
        public string Value { get; set; } = value;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DeviceEntity? Device { get; set; }
        public SpecificationEntity? Specification { get; set; }
    }
}
