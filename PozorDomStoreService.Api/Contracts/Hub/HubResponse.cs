namespace PozorDomStoreService.Api.Contracts.Hub
{
    public record HubResponse(
        Guid Id,
        string Name,
        string Description,
        string ImageUrl,
        double Price
    );
}
