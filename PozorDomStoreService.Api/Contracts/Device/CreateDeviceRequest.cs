namespace PozorDomStoreService.Api.Contracts.Device
{
    public record CreateDeviceRequest(
        Guid DeviceTypeId,
        string Name,
        double Price
    );
}
