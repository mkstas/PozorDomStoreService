using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Orders;
using PozorDomStoreService.Api.Extensions;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController(
        IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var orderId = await _orderService.CreateOrderAsync(User.GetUserId(), request.CartDevices, request.Address);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId });
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAllByUserId()
        {
            var orders = await _orderService.GetOrderAllByUserIdAsync(User.GetUserId());
            List<OrderResponse> response = [.. orders.Select(o =>
                new OrderResponse(o.Id, o.UserId, o.Address, o.Status.ToString(), o.OrderDevices))];

            return Ok(response);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid orderId)
        {
            var order = await _orderService.GetOrderByOrderIdAsync(orderId);
            OrderResponse response = new(order.Id, order.UserId, order.Address, order.Status.ToString(), order.OrderDevices);

            return Ok(response);
        }
    }
}
