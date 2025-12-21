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

        public async Task<Guid> CreateAsync(string name)
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
                throw new ConflictException("Specification already exists.");
            }
        }

        public async Task<List<SpecificationEntity>> GetAllAsync()
        {
            return await _context.Specifications
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SpecificationEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Specifications
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<int> UpdateAsync(Guid id, string name)
        {
            try
            {
                return await _context.Specifications
                    .Where(s => s.Id == id)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(s => s.Name, name));
            }
            catch (PostgresException ex) when (ex.IsUniqueUpdateKeyViolation("IX_Specifications_Name"))
            {
                throw new ConflictException("Specification already exists.");
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.Specifications
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
