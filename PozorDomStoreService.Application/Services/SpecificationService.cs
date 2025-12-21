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
            return await _specificationRepository.CreateAsync(name);
        }

        public async Task<List<SpecificationEntity>> GetSpecificationAllAsync()
        {
            var specifications = await _specificationRepository.GetAllAsync();

            if (specifications.Count == 0)
                throw new NotFoundException("Specifications not found.");

            return specifications;
        }

        public async Task<SpecificationEntity> GetSpecificationByIdAsync(Guid id)
        {
            return await _specificationRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Specification not found.");
        }

        public async Task UpdateSpecificationAsync(Guid id, string name)
        {
            var rows = await _specificationRepository.UpdateAsync(id, name);

            if (rows == 0)
                throw new NotFoundException("Specification not found.");
        }

        public async Task DeleteSpecificationAsync(Guid id)
        {
            var rows = await  _specificationRepository.DeleteAsync(id);

            if (rows == 0)
                throw new NotFoundException("Specification not found.");
        }
    }
}
