using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;

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
            var cartId = GetOrCreateCart(userId);
            await _cartDeviceRepository.AddDeviceToCartAsync(await cartId, deviceId);
        }

        private async Task<Guid> GetOrCreateCart(Guid userId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);

            if (cart is null)
                return await _cartRepository.CreateAsync(userId);

            return cart.Id;
        }

        public async Task<List<CartDeviceEntity>> GetCartDevicesByUserIdAsync(Guid userId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);

            if (cart is null)
                return [];

            return await _cartDeviceRepository.GetDevicesByCartIdAsync(cart.Id);
        }

        public async Task UpdateDeviceQuantityInCartAsync(Guid cartDeviceId, int quantity)
        {
            await _cartDeviceRepository.UpdateDeviceQuantityAsync(cartDeviceId, quantity);
        }

        public async Task RemoveDeviceFromCartAsync(Guid cartDeviceId)
        {
            await _cartDeviceRepository.RemoveDeviceFromCartAsync(cartDeviceId);
        }
    }
}
