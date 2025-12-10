namespace PozorDomStoreService.Api.Contracts.Device
{
    public record UpdateDeviceRequest(
        Guid DeviceTypeId,
        string Name,
        double Price
    );
}
