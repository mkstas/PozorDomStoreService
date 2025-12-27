using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ICartDeviceRepository
    {
        Task AddDeviceToCartAsync(Guid cartId, Guid deviceId, int quantity = 1);
        Task<List<CartDeviceEntity>> GetCartDeviceAllByCartIdAsync(Guid cartId);
        Task<int> UpdateCartDeviceQuantityByIdAsync(Guid cartDeviceId, int quantity);
        Task<int> RemoveCartDeviceFromCartByIdAsync(Guid cartDeviceId);
    }
}
