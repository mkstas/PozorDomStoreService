using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Carts;
using PozorDomStoreService.Api.Extensions;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController(
        ICartService cartService) : ControllerBase
    {
        private readonly ICartService _cartService = cartService;

        [HttpPost]
        public async Task<IActionResult> AddDeviceToCart([FromBody] AddDeviceToCartRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out var deviceId))
                return BadRequest("Invalid DeviceId format.");

            await _cartService.AddDeviceToCartAsync(User.GetUserId(), deviceId);

            return NoContent();
        }

        [HttpPatch("{cartDeviceId:guid}/quantity")]
        public async Task<IActionResult> UpdateCartDeviceQuantity(
            [FromRoute] Guid cartDeviceId,
            [FromBody] UpdateDeviceQuantityRequest request)
        {
            await _cartService.UpdateCartDeviceQuantityAsync(cartDeviceId, request.Quantity);

            return NoContent();
        }

        [HttpDelete("{cartDeviceId:guid}")]
        public async Task<IActionResult> RemoveCartDeviceFromCart([FromRoute] Guid cartDeviceId)
        {
            await _cartService.RemoveCartDeviceFromCartAsync(cartDeviceId);

            return NoContent();
        }
    }
}
