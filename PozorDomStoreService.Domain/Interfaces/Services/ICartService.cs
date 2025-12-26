using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface ICartService
    {
        Task AddDeviceToCartAsync(Guid userId, Guid deviceId);
        Task<List<CartDeviceEntity>> GetCartDeviceAllByUserIdAsync(Guid userId);
        Task UpdateCartDeviceQuantityAsync(Guid cartDeviceId, int quantity);
        Task RemoveCartDeviceFromCartAsync(Guid cartDeviceId);
    }
}
