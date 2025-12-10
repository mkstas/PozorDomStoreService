namespace PozorDomStoreService.Api.Contracts.Hub
{
    public record HubResponse(
        Guid Id,
        string Name,
        double Price
    );
}
