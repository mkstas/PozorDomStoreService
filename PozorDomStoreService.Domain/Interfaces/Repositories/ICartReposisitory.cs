using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Guid> CreateAsync(Guid userId);
        Task<CartEntity?> GetByUserIdAsync(Guid userId);
        Task<int> DeleteAsync(Guid id);
    }
}
