using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ICartDeviceRepository
    {
        Task AddDeviceToCartAsync(Guid cartId, Guid deviceId, int quantity = 1);
        Task<List<CartDeviceEntity>> GetDevicesByCartIdAsync(Guid cartId);
        Task<int> UpdateDeviceQuantityAsync(Guid id, int quantity);
        Task<int> RemoveDeviceFromCartAsync(Guid id);
    }
}
