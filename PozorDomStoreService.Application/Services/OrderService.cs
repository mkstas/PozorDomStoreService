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

        public async Task<Guid> AddDevicesToOrderAsync(Guid userId, List<CartDeviceEntity> cartDevices)
        {
            var orderId = await _orderRepository.AddOrderAsync(userId);

            foreach (var cartDevice in cartDevices)
            {
                var device = await _deviceRepository.GetByIdAsync(cartDevice.Id);

                if (device is not null)
                    await _orderDeviceRepository.AddOrderDeviceAsync(
                        orderId, device.Id, cartDevice.Quantity, device.Price);
            }

            return orderId;
        }

        public async Task<List<OrderEntity>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

            if (orders.Count == 0)
                throw new NotFoundException("Orders not found.");

            return orders;
        }

        public async Task<OrderEntity> GetOrderByOrderIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrderByOrderIdAsync(orderId)
                ?? throw new NotFoundException("Order not found.");
        }
    }
}
