namespace PozorDomStoreService.Domain.Entities
{
    public class DeviceTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DeviceEntity> Devices { get; set; } = [];
    }
}
