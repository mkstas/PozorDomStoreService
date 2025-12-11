using Microsoft.AspNetCore.Mvc;
using PozorDomAuthService.Infrastructure.Exceptions;
using PozorDomStoreService.Api.Contracts.DeviceType;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/device-types")]
    public class DeviceTypesController(
        IDeviceTypeService deviceTypeService) : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService = deviceTypeService;

        [HttpPost]
        public async Task<IResult> CreateDeviceType([FromBody] CreateDeviceTypeRequest request)
        {
            try
            {
                var result = await _deviceTypeService.CreateDeviceTypeAsync(request.Name);

                return Results.Created($"/device-types/{result}", result);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while creating the device type.");
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllDeviceTypes()
        {
            try
            {
                var result = await _deviceTypeService.GetAllDeviceTypeAsync();

                List<DeviceTypeResponse> response =
                    [.. result.Select(dt => new DeviceTypeResponse(dt.Id, dt.Name))];

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving device types.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetDeviceTypeById([FromRoute] Guid id)
        {
            try
            {
                var result = await _deviceTypeService.GetDeviceTypeByIdAsync(id);

                DeviceTypeResponse response = new(result.Id, result.Name);

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving the device type.");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateDeviceType([FromRoute] Guid id, [FromBody] UpdateDeviceTypeRequest request)
        {
            try
            {
                await _deviceTypeService.UpdateDeviceTypeAsync(id, request.Name);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while updating the device type.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteDeviceType([FromRoute] Guid id)
        {
            try
            {
                await _deviceTypeService.DeleteDeviceTypeAsync(id);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while deleting the device type.");
            }
        }
    }
}
