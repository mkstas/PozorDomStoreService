using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Guid> CreateCartAsync(Guid userId);
        Task<CartEntity?> GetCartByUserIdAsync(Guid userId);
        Task<int> DeleteCartByIdAsync(Guid cartId);
    }
}
