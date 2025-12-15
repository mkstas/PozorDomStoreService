using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Device;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/devices")]
    public class DevicesController(
        IDeviceService deviceService) : ControllerBase
    {
        private readonly IDeviceService _deviceService = deviceService;

        [HttpPost]
        public async Task<IResult> CreateDevice([FromBody] CreateDeviceRequest request)
        {
            if (!Guid.TryParse(request.DeviceTypeId, out Guid deviceTypeId))
                return Results.BadRequest("Invalid DeviceTypeId format.");

            var result = await _deviceService.CreateDeviceAsync(deviceTypeId, request.Name, request.Price);

            return Results.Created($"/api/devices/{result}", result);
        }

        [HttpGet]
        public async Task<IResult> GetAllDevices()
        {
            var result = await _deviceService.GetAllDeviceAsync();
            List<DeviceResponse> response =
                [.. result.Select(d => new DeviceResponse(d.Id, d.DeviceTypeId, d.Name, d.Price))];

            return Results.Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetDeviceById([FromRoute] Guid id)
        {
                var result = await _deviceService.GetDeviceByIdAsync(id);
                DeviceResponse response = new(result.Id, result.DeviceTypeId, result.Name, result.Price);

                return Results.Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateDevice([FromRoute] Guid id, [FromBody] UpdateDeviceRequest request)
        {
            if (!Guid.TryParse(request.DeviceTypeId, out Guid deviceTypeId))
                return Results.BadRequest("Invalid DeviceTypeId format.");

            await _deviceService.UpdateDeviceAsync(id, deviceTypeId, request.Name, request.Price);

            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteDevice([FromRoute] Guid id)
        {
            await _deviceService.DeleteDeviceAsync(id);

            return Results.NoContent();
        }
    }
}
