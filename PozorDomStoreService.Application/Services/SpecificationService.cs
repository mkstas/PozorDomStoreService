using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Infrastructure.Exceptions;

namespace PozorDomStoreService.Application.Services
{
    public class SpecificationService
        (ISpecificationRepository specificationRepository): ISpecificationService
    {
        private readonly ISpecificationRepository _specificationRepository = specificationRepository;

        public async Task<Guid> CreateSpecificationAsync(string name)
        {
            return await _specificationRepository.CreateSpecificationAsync(name);
        }

        public async Task<List<SpecificationEntity>> GetSpecificationAllAsync()
        {
            var specifications = await _specificationRepository.GetSpecificationAllAsync();

            if (specifications.Count == 0)
                throw new NotFoundException("Specifications do not exist.");

            return specifications;
        }

        public async Task<SpecificationEntity> GetSpecificationByIdAsync(Guid specificationId)
        {
            return await _specificationRepository.GetSpecificationByIdAsync(specificationId)
                ?? throw new NotFoundException($"Specification with id {specificationId} does not exist.");
        }

        public async Task UpdateSpecificationByIdAsync(Guid specificationId, string name)
        {
            var rows = await _specificationRepository.UpdateSpecificationByIdAsync(specificationId, name);

            if (rows == 0)
                throw new NotFoundException($"Specification with id {specificationId} does not exist.");
        }

        public async Task DeleteSpecificationByIdAsync(Guid specificationId)
        {
            var rows = await _specificationRepository.DeleteSpecificationByIdAsync(specificationId);

            if (rows == 0)
                throw new NotFoundException($"Specification with id {specificationId} does not exist.");
        }
    }
}
