using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Infrastructure.Exceptions;

namespace PozorDomStoreService.Application.Services
{
    public class OrderService(
        IOrderRepository orderRepository,
        IOrderDeviceRepository orderDeviceRepository,
        IDeviceRepository deviceRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IOrderDeviceRepository _orderDeviceRepository = orderDeviceRepository;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public async Task<Guid> CreateOrderAsync(Guid userId, List<CartDeviceEntity> cartDevices, string address)
        {
            var orderId = await _orderRepository.CreateOrderAsync(userId, address);

            foreach (var cartDevice in cartDevices)
            {
                var device = await _deviceRepository.GetDeviceByIdAsync(cartDevice.Id);

                if (device is not null)
                {
                    await _orderDeviceRepository
                        .AddDeviceToOrderAsync(orderId, device.Id, cartDevice.Quantity, device.Price);
                }

            }

            return orderId;
        }

        public async Task<List<OrderEntity>> GetOrderAllByUserIdAsync(Guid userId)
        {
            var orders = await _orderRepository.GetOrderAllByUserIdAsync(userId);

            if (orders.Count == 0)
                throw new NotFoundException($"Orders for user {userId} do not exist.");

            return orders;
        }

        public async Task<OrderEntity> GetOrderByOrderIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId)
                ?? throw new NotFoundException($"Order with id {orderId} does not exist.");
        }
    }
}
