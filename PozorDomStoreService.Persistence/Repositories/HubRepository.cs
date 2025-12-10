using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class HubRepository(PozorDomStoreServiceDbContext context) : IHubRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(string name, double price)
        {
            var hub = new HubEntity(
                Guid.NewGuid(), name, price);

            await _context.Hubs.AddAsync(hub);
            await _context.SaveChangesAsync();

            return hub.Id;
        }
        
        public async Task<List<HubEntity>> GetAllAsync()
        {
            return await _context.Hubs
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<HubEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Hubs
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<int> UpdateAsync(Guid id, string name, double price)
        {
            return await _context.Devices
                .Where(h => h.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(h => h.Name, name)
                    .SetProperty(h => h.Price, price));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.Hubs
                .Where(h => h.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
