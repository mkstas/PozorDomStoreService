using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Orders;
using PozorDomStoreService.Api.Extensions;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/orders")]
    public class OrdersController(
        IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost]
        public async Task<IResult> CreateOrderAsync([FromBody] CreateOrderRequest request)
        {
            var order = await _orderService.AddDevicesToOrderAsync(User.GetUserId(), request.CartDevices);

            return Results.NoContent();
        }

        [HttpGet]
        public async Task<IResult> GetOrdersByUserId()
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(User.GetUserId());
            List<OrderResponse> reponse = [.. orders.Select(
                o => new OrderResponse(o.Id, o.UserId, o.Status))];

            return Results.Ok(reponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetOrderByOrderIdAsync([FromRoute] Guid orderId)
        {
            var order = await _orderService.GetOrderByOrderIdAsync(orderId);
            OrderResponse response = new(order.Id, order.UserId, order.Status);

            return Results.Ok(response);
        }
    }
}
