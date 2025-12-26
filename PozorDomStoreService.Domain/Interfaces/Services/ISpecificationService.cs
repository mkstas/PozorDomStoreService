using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface ISpecificationService
    {
        Task<Guid> CreateSpecificationAsync(string name);
        Task<List<SpecificationEntity>> GetSpecificationAllAsync();
        Task<SpecificationEntity> GetSpecificationByIdAsync(Guid specificationId);
        Task UpdateSpecificationByIdAsync(Guid specificationId, string name);
        Task DeleteSpecificationByIdAsync(Guid specificationId);
    }
}
