namespace PozorDomStoreService.Api.Contracts.Carts
{
    public record CartDeviceResponse(
        Guid Id,
        Guid CartId,
        Guid DeviceId,
        int Quantity);
}
