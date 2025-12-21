namespace PozorDomStoreService.Api.Contracts.DeviceSpecification
{
    public record DeviceSpecificationResponse(
        Guid Id,
        Guid DeviceId,
        Guid SpecificationId
    );
}
