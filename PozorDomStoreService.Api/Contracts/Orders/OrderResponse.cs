using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Api.Contracts.Orders
{
    public record OrderResponse(
        Guid Id,
        Guid UserId,
        OrderStatus Status);
}
