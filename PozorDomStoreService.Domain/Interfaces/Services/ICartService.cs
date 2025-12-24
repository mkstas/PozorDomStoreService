using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface ICartService
    {
        Task AddDeviceToCartAsync(Guid userId, Guid deviceId);
        Task<List<CartDeviceEntity>> GetCartDevicesByUserIdAsync(Guid userId);
        Task UpdateDeviceQuantityInCartAsync(Guid cartDeviceId, int quantity);
        Task RemoveDeviceFromCartAsync(Guid cartDeviceId);
    }
}
