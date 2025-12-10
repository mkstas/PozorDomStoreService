namespace PozorDomStoreService.Api.Contracts.Hub
{
    public record CreateHubRequest(
        string Name,
        double Price
    );
}
