using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Devices;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController(
        IDeviceService deviceService) : ControllerBase
    {
        private readonly IDeviceService _deviceService = deviceService;

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceRequest request)
        {
            if (!Guid.TryParse(request.DeviceTypeId, out Guid deviceTypeId))
                return BadRequest("Invalid DeviceTypeId format.");

            var deviceId = await _deviceService.CreateDeviceAsync(
                deviceTypeId, request.Name, request.Description, request.Price);

            return CreatedAtAction(nameof(GetDeviceById), new { id = deviceId });
        }

        [HttpGet]
        public async Task<IActionResult> GetDeviceAll()
        {
            var devices = await _deviceService.GetDeviceAllAsync();
            List<DeviceResponse> response = [.. devices.Select(d => 
                new DeviceResponse(d.Id, d.DeviceTypeId, d.Name, d.Description, d.ImageUrl, d.Price))];

            return Ok(response);
        }

        [HttpGet("{deviceId:guid}")]
        public async Task<IActionResult> GetDeviceById([FromRoute] Guid deviceId)
        {
            var device = await _deviceService.GetDeviceByIdAsync(deviceId);
            DeviceResponse response =
                new(device.Id, device.DeviceTypeId, device.Name, device.Description, device.ImageUrl, device.Price);

            return Ok(response);
        }

        [HttpPut("{deviceId:guid}")]
        public async Task<IActionResult> UpdateDeviceById(
            [FromRoute] Guid deviceId,
            [FromBody] UpdateDeviceRequest request)
        {
            if (!Guid.TryParse(request.DeviceTypeId, out Guid deviceTypeId))
                return BadRequest("Invalid DeviceTypeId format.");

            await _deviceService.UpdateDeviceByIdAsync(
                deviceId, deviceTypeId, request.Name, request.Description, request.Price);

            return NoContent();
        }

        [HttpPatch("{deviceId:guid}/image")]
        public async Task<IActionResult> UpdateDeviceImageById(
            [FromRoute] Guid deviceId,
            IFormFile image)
        {
            await _deviceService.UpdateDeviceImageByIdAsync(deviceId, image);

            return NoContent();
        }

        [HttpDelete("{deviceId:guid}")]
        public async Task<IActionResult> DeleteDeviceById([FromRoute] Guid deviceId)
        {
            await _deviceService.DeleteDeviceByIdAsync(deviceId);

            return NoContent();
        }
    }
}
