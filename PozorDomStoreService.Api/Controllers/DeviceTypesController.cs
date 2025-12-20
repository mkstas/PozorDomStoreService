using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.DeviceType;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/device_types")]
    public class DeviceTypesController(
        IDeviceTypeService deviceTypeService) : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService = deviceTypeService;

        [HttpPost]
        public async Task<IResult> CreateDeviceType([FromBody] CreateDeviceTypeRequest request)
        {
            var result = await _deviceTypeService.CreateDeviceTypeAsync(request.Name);

            return Results.Created($"/device_types/{result}", result);
        }

        [HttpGet]
        public async Task<IResult> GetAllDeviceTypes()
        {
            var result = await _deviceTypeService.GetAllDeviceTypeAsync();
            List<DeviceTypeResponse> response =
                [.. result.Select(dt => new DeviceTypeResponse(dt.Id, dt.Name))];

            return Results.Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetDeviceTypeById([FromRoute] Guid id)
        {
            var result = await _deviceTypeService.GetDeviceTypeByIdAsync(id);
            DeviceTypeResponse response = new(result.Id, result.Name);

            return Results.Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateDeviceType([FromRoute] Guid id, [FromBody] UpdateDeviceTypeRequest request)
        {
            await _deviceTypeService.UpdateDeviceTypeAsync(id, request.Name);

            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteDeviceType([FromRoute] Guid id)
        {
            await _deviceTypeService.DeleteDeviceTypeAsync(id);

            return Results.NoContent();
        }
    }
}
