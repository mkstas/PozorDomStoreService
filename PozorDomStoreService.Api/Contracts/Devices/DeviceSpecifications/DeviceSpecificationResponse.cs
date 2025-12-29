namespace PozorDomStoreService.Api.Contracts.Devices.DeviceSpecifications
{
    public record DeviceSpecificationResponse(
        Guid Id,
        Guid DeviceId,
        Guid SpecificationId);
}
