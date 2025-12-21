using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ISpecificationRepository
    {
        Task<Guid> CreateAsync(string name);
        Task<List<SpecificationEntity>> GetAllAsync();
        Task<SpecificationEntity?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Guid id, string name);
        Task<int> DeleteAsync(Guid id);
    }
}
