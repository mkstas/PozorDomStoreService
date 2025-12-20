using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface IHubRepository
    {
        Task<Guid> CreateAsync(string name, string description, string imageUrl, double price);
        Task<List<HubEntity>> GetAllAsync();
        Task<HubEntity?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Guid id, string name, string description, string imageUrl, double price);
        Task<int> DeleteAsync(Guid id);
    }
}
