namespace PozorDomStoreService.Domain.Entities
{
    public class DeviceSpecificationEntity
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid SpecificationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DeviceEntity? Device { get; set; }
        public SpecificationEntity? Specification { get; set; }
    }
}
