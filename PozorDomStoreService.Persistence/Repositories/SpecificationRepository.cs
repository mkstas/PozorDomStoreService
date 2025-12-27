using Microsoft.EntityFrameworkCore;
using Npgsql;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Persistence.Extensions;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class SpecificationRepository(PozorDomStoreServiceDbContext context) : ISpecificationRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateSpecificationAsync(string name)
        {
            var specification = new SpecificationEntity
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            await _context.Specifications.AddAsync(specification);

            try
            {
                await _context.SaveChangesAsync();

                return specification.Id;
            }
            catch (DbUpdateException ex) when (ex.IsUniqueCreateConstraintViolation("IX_Specifications_Name"))
            {
                throw new ConflictException($"Specification with name ${name} is already exists.");
            }
        }

        public async Task<List<SpecificationEntity>> GetSpecificationAllAsync()
        {
            return await _context.Specifications
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SpecificationEntity?> GetSpecificationByIdAsync(Guid specificationId)
        {
            return await _context.Specifications
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == specificationId);
        }

        public async Task<int> UpdateSpecificationByIdAsync(Guid specificationId, string name)
        {
            try
            {
                return await _context.Specifications
                    .Where(s => s.Id == specificationId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(s => s.Name, name));
            }
            catch (PostgresException ex) when (ex.IsUniqueUpdateKeyViolation("IX_Specifications_Name"))
            {
                throw new ConflictException($"Specification with name ${name} is already exists.");
            }
        }

        public async Task<int> DeleteSpecificationByIdAsync(Guid specificationId)
        {
            return await _context.Specifications
                .Where(s => s.Id == specificationId)
                .ExecuteDeleteAsync();
        }
    }
}
