namespace PozorDomStoreService.Api.Contracts.Hub
{
    public record UpdateHubRequest(
        string Name,
        double Price
    );
}
