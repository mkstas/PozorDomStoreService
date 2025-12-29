using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Devices.DeviceSpecifications;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceSpecificationsControllers(
        IDeviceSpecificationService deviceSpecificationService) : ControllerBase
    {
        private readonly IDeviceSpecificationService _deviceSpecificationService = deviceSpecificationService;

        [HttpPost]
        public async Task<IActionResult> CreateDeviceSpecification([FromBody] CreateDeviceSpecificationRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out Guid deviceId))
                return BadRequest("Invalid deviceId format.");

            if (!Guid.TryParse(request.SpecificationId, out Guid specificationId))
                return BadRequest("Invalid specificationId format.");

            var deviceSpecificationId = await _deviceSpecificationService.CreateDeviceSpecificationAsync(deviceId, specificationId);

            return CreatedAtAction(nameof(GetDeviceSpecificationById), new { id = deviceSpecificationId });
        }

        [HttpGet("{deviceId:guid}/device")]
        public async Task<IActionResult> GetDeviceSpecificationAll([FromRoute] Guid deviceId)
        {
            var deviceSpecifications = await _deviceSpecificationService.GetDeviceSpecificationAllAsync(deviceId);
            List<DeviceSpecificationResponse> response = [.. deviceSpecifications.Select(ds =>
                new DeviceSpecificationResponse(ds.Id, ds.DeviceId, ds.SpecificationId))];

            return Ok(response);
        }

        [HttpGet("{deviceSpecificationId:guid}")]
        public async Task<IActionResult> GetDeviceSpecificationById([FromRoute] Guid deviceSpecificationId)
        {
            var deviceSpecification = await _deviceSpecificationService.GetDeviceSpecificationByIdAsync(deviceSpecificationId);
            DeviceSpecificationResponse response =
                new(deviceSpecification.Id, deviceSpecification.DeviceId, deviceSpecification.SpecificationId);

            return Ok(response);
        }

        [HttpPut("{deviceSpecificationId:guid}")]
        public async Task<IActionResult> UpdateDeviceSpecificationById(
            [FromRoute] Guid deviceSpecificationId,
            [FromBody] UpdateDeviceSpecificationRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out Guid deviceId))
                return BadRequest("Invalid deviceId format.");

            if (!Guid.TryParse(request.SpecificationId, out Guid specificationId))
                return BadRequest("Invalid specificationId format.");

            await _deviceSpecificationService.UpdateDeviceSpecificationByIdAsync(deviceSpecificationId, deviceId, specificationId);

            return NoContent();
        }

        [HttpDelete("{deviceSpecificationId:guid}")]
        public async Task<IActionResult> DeleteDeviceSpecificationById([FromRoute] Guid deviceSpecificationId)
        {
            await _deviceSpecificationService.DeleteDeviceSpecificationByIdAsync(deviceSpecificationId);

            return NoContent();
        }
    }
}
