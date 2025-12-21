using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.DeviceSpecification;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/device_specifications")]
    public class DeviceSpecificationsControllers(
        IDeviceSpecificationService deviceSpecificationService) : ControllerBase
    {
        private readonly IDeviceSpecificationService _deviceSpecificationService = deviceSpecificationService;

        [HttpPost]
        public async Task<IResult> CreateSpecification([FromBody] CreateDeviceSpecificationRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out Guid deviceId))
                return Results.BadRequest("Invalid deviceId format.");

            if (!Guid.TryParse(request.SpecificationId, out Guid specificationId))
                return Results.BadRequest("Invalid specificationId format.");

            var result = await _deviceSpecificationService.CreateDeviceSpecificationAsync(deviceId, specificationId);

            return Results.Created($"/api/v1/store/device_specifications{result}", result);
        }

        [HttpGet]
        public async Task<IResult> GetAllSpecifications()
        {
            var result = await _deviceSpecificationService.GetDeviceSpecificationAllAsync();
            List<DeviceSpecificationResponse> response =
                [.. result.Select(ds => new DeviceSpecificationResponse(ds.Id, ds.DeviceId, ds.SpecificationId))];

            return Results.Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetSpecificationById([FromRoute] Guid id)
        {
            var result = await _deviceSpecificationService.GetDeviceSpecificationByIdAsync(id);
            DeviceSpecificationResponse response = new(result.Id, result.DeviceId, result.SpecificationId);

            return Results.Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateSpecification([FromRoute] Guid id, [FromBody] UpdateDeviceSpecificationRequest request)
        {
            if (!Guid.TryParse(request.DeviceId, out Guid deviceId))
                return Results.BadRequest("Invalid deviceId format.");

            if (!Guid.TryParse(request.SpecificationId, out Guid specificationId))
                return Results.BadRequest("Invalid specificationId format.");

            await _deviceSpecificationService.UpdateDeviceSpecificationAsync(id, deviceId, specificationId);

            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteSpecification([FromRoute] Guid id)
        {
            await _deviceSpecificationService.DeleteDeviceSpecificationAsync(id);

            return Results.NoContent();
        }
    }
}
