using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Carts;
using PozorDomStoreService.Api.Extensions;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/carts")]
    public class CartsController(
        ICartService cartService) : ControllerBase
    {
        private readonly ICartService _cartService = cartService;

        [HttpPost]
        public async Task<IResult> AddDeviceToCartAsync([FromBody] AddDeviceToCartRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out Guid deviceId))
                return Results.BadRequest("Invalid DeviceId format.");
            await _cartService.AddDeviceToCartAsync(User.GetUserId(), deviceId);

            return Results.NoContent();
        }

        [HttpGet]
        public async Task<IResult> GetCartDevicesAsync()
        {
            var cartDevices = await _cartService.GetCartDevicesByUserIdAsync(User.GetUserId());
            List<CartDeviceResponse> response = [.. cartDevices.Select(cd => new CartDeviceResponse(
                cd.Id, cd.CartId, cd.DeviceId, cd.Quantity))];

            return Results.Ok(response);
        }

        [HttpPatch("{cartDeviceId:guid}/quantity")]
        public async Task<IResult> UpdateDeviceQuantityInCartAsync(
            [FromRoute] Guid cartDeviceId,
            [FromBody] UpdateDeviceQuantityRequest request)
        {
            await _cartService.UpdateDeviceQuantityInCartAsync(cartDeviceId, request.Quantity);

            return Results.NoContent();
        }

        [HttpDelete("{cartDeviceId:guid}")]
        public async Task<IResult> RemoveDeviceFromCartAsync([FromRoute] Guid cartDeviceId)
        {
            await _cartService.RemoveDeviceFromCartAsync(cartDeviceId);

            return Results.NoContent();
        }
    }
}
