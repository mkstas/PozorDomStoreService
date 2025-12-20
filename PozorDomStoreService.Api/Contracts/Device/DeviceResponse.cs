namespace PozorDomStoreService.Api.Contracts.Device
{
    public record DeviceResponse(
        Guid Id,
        Guid DeviceTypeId,
        string Name,
        string Description,
        string ImageUrl,
        double Price
    );
}
