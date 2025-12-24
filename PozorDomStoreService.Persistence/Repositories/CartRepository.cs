using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class CartRepository(PozorDomStoreServiceDbContext context) : ICartRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateAsync(Guid userId)
        {
            var cart = new CartEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart.Id;
        }

        public async Task<CartEntity?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Carts
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return _context.Carts
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
