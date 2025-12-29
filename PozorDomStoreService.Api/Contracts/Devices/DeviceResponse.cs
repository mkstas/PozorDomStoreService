namespace PozorDomStoreService.Api.Contracts.Devices
{
    public record DeviceResponse(
        Guid Id,
        Guid DeviceTypeId,
        string Name,
        string Description,
        string ImageUrl,
        double Price);
}
