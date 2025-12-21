using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface ISpecificationService
    {
        Task<Guid> CreateSpecificationAsync(string name);
        Task<List<SpecificationEntity>> GetSpecificationAllAsync();
        Task<SpecificationEntity> GetSpecificationByIdAsync(Guid id);
        Task UpdateSpecificationAsync(Guid id, string name);
        Task DeleteSpecificationAsync(Guid id);
    }
}
