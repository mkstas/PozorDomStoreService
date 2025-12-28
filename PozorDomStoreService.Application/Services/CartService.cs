using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Infrastructure.Exceptions;

namespace PozorDomStoreService.Application.Services
{
    public class CartService(
        ICartRepository cartRepository,
        ICartDeviceRepository cartDeviceRepository) : ICartService
    {
        private readonly ICartRepository _cartRepository = cartRepository;
        private readonly ICartDeviceRepository _cartDeviceRepository = cartDeviceRepository;

        public async Task AddDeviceToCartAsync(Guid userId, Guid deviceId)
        {
            var cartId = await GetOrCreateCartAsync(userId);

            await _cartDeviceRepository.AddDeviceToCartAsync(cartId, deviceId);
        }

        private async Task<Guid> GetOrCreateCartAsync(Guid userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cart is null)
                return await _cartRepository.CreateCartAsync(userId);

            return cart.Id;
        }

        public async Task<List<CartDeviceEntity>> GetCartDeviceAllByUserIdAsync(Guid userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId)
                ?? throw new NotFoundException($"Cart devices for user with id {userId} do not exist.");

            return await _cartDeviceRepository.GetCartDeviceAllByCartIdAsync(cart.Id);
        }

        public async Task UpdateCartDeviceQuantityAsync(Guid cartDeviceId, int quantity)
        {
            await _cartDeviceRepository.UpdateCartDeviceQuantityByIdAsync(cartDeviceId, quantity);
        }

        public async Task RemoveCartDeviceFromCartAsync(Guid cartDeviceId)
        {
            await _cartDeviceRepository.RemoveCartDeviceFromCartByIdAsync(cartDeviceId);
        }
    }
}
