using Microsoft.AspNetCore.Mvc;
using PozorDomAuthService.Infrastructure.Exceptions;
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
            try
            {
                var result = await _deviceService.CreateDeviceAsync(request.DeviceTypeId, request.Name, request.Price);

                return Results.Created($"/api/devices/{result}", result);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while creating the device.");
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllDevices()
        {
            try
            {
                var result = await _deviceService.GetAllDeviceAsync();

                List<DeviceResponse> response =
                    [.. result.Select(d => new DeviceResponse(d.Id, d.DeviceTypeId, d.Name, d.Price))];

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving devices.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetDeviceById([FromRoute] Guid id)
        {
            try
            {
                var result = await _deviceService.GetDeviceByIdAsync(id);

                DeviceResponse response = new(result.Id, result.DeviceTypeId, result.Name, result.Price);

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving the device.");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateDevice([FromRoute] Guid id, [FromBody] UpdateDeviceRequest request)
        {
            try
            {
                await _deviceService.UpdateDeviceAsync(id, request.DeviceTypeId, request.Name, request.Price);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while updating the device.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteDevice([FromRoute] Guid id)
        {
            try
            {
                await _deviceService.DeleteDeviceAsync(id);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while deleting the device.");
            }
        }
    }
}
