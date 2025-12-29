using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Devices.DeviceTypes;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceTypesController(
        IDeviceTypeService deviceTypeService) : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService = deviceTypeService;

        [HttpPost]
        public async Task<IActionResult> CreateDeviceType([FromBody] CreateDeviceTypeRequest request)
        {
            var deviceTypeId = await _deviceTypeService.CreateDeviceTypeAsync(request.Name);

            return CreatedAtAction(nameof(GetDeviceTypeById), new { id = deviceTypeId });
        }

        [HttpGet]
        public async Task<IActionResult> GetDeviceTypeAll()
        {
            var deviceTypes = await _deviceTypeService.GetDeviceTypeAllAsync();
            List<DeviceTypeResponse> response =
                [.. deviceTypes.Select(dt => new DeviceTypeResponse(dt.Id, dt.Name))];

            return Ok(response);
        }

        [HttpGet("{deviceTypeId:guid}")]
        public async Task<IActionResult> GetDeviceTypeById([FromRoute] Guid deviceTypeId)
        {
            var deviceType = await _deviceTypeService.GetDeviceTypeByIdAsync(deviceTypeId);
            DeviceTypeResponse response = new(deviceType.Id, deviceType.Name);

            return Ok(response);
        }

        [HttpPut("{deviceTypeId:guid}")]
        public async Task<IActionResult> UpdateDeviceTypeById(
            [FromRoute] Guid deviceTypeId,
            [FromBody] UpdateDeviceTypeRequest request)
        {
            await _deviceTypeService.UpdateDeviceTypeByIdAsync(deviceTypeId, request.Name);

            return NoContent();
        }

        [HttpDelete("{deviceTypeId:guid}")]
        public async Task<IActionResult> DeleteDeviceTypeById([FromRoute] Guid deviceTypeId)
        {
            await _deviceTypeService.DeleteDeviceTypeByIdAsync(deviceTypeId);

            return NoContent();
        }
    }
}
