using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Api.Contracts.Orders
{
    public record CreateOrderRequest(
        List<CartDeviceEntity> CartDevices);
}
