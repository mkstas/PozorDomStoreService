using Microsoft.AspNetCore.Mvc;
using PozorDomAuthService.Infrastructure.Exceptions;
using PozorDomStoreService.Api.Contracts.Hub;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/hubs")]
    public class HubsController(
        IHubService hubService) : ControllerBase
    {
        private readonly IHubService _hubService = hubService;

        [HttpPost]
        public async Task<IResult> CreateHub([FromBody] CreateHubRequest request)
        {
            try
            {
                var result = await _hubService.CreateHubAsync(request.Name, request.Price);

                return Results.Created($"/api/hubs/{result}", result);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while creating the device.");
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllHubs()
        {
            try
            {
                var result = await _hubService.GetAllHubAsync();

                List<HubResponse> response =
                    [.. result.Select(h => new HubResponse(h.Id, h.Name, h.Price))];

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving hubs.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetHubById([FromRoute] Guid id)
        {
            try
            {
                var result = await _hubService.GetHubByIdAsync(id);

                HubResponse response = new(result.Id, result.Name, result.Price);

                return Results.Ok(response);
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while retrieving the hub.");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateHub([FromRoute] Guid id, [FromBody] UpdateHubRequest request)
        {
            try
            {
                await _hubService.UpdateHubAsync(id, request.Name, request.Price);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while updating the hub.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteHub([FromRoute] Guid id)
        {
            try
            {
                await _hubService.DeleteHubAsync(id);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.InternalServerError("An error occurred while deleting the hub.");
            }
        }
    }
}
