using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Repositories
{
    public interface ISpecificationRepository
    {
        Task<Guid> CreateSpecificationAsync(string name);
        Task<List<SpecificationEntity>> GetSpecificationAllAsync();
        Task<SpecificationEntity?> GetSpecificationByIdAsync(Guid specificationId);
        Task<int> UpdateSpecificationByIdAsync(Guid specificationId, string name);
        Task<int> DeleteSpecificationByIdAsync(Guid specificationId);
    }
}
