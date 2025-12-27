using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Persistence.Extensions;

namespace PozorDomStoreService.Persistence.Repositories
{
    public class CartRepository(PozorDomStoreServiceDbContext context) : ICartRepository
    {
        private readonly PozorDomStoreServiceDbContext _context = context;

        public async Task<Guid> CreateCartAsync(Guid userId)
        {
            var cart = new CartEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
            };

            await _context.Carts.AddAsync(cart);

            try
            {
                await _context.SaveChangesAsync();

                return cart.Id;
            }
            catch (DbUpdateException ex) when (ex.IsUniqueCreateConstraintViolation("IX_Carts_UserId"))
            {
                throw new ConflictException($"Cart with user ${userId} is already exists.");
            }
        }

        public async Task<CartEntity?> GetCartByUserIdAsync(Guid userId)
        {
            return await _context.Carts
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public Task<int> DeleteCartByIdAsync(Guid cartId)
        {
            return _context.Carts
                .Where(c => c.Id == cartId)
                .ExecuteDeleteAsync();
        }
    }
}
