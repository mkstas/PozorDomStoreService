using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Api.Contracts.Orders
{
    public record OrderResponse(
        Guid Id,
        Guid UserId,
        string Address,
        string Status,
        List<OrderDeviceEntity> OrderDevices);
}
