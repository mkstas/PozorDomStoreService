using Microsoft.AspNetCore.Mvc;
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
            var result = await _hubService.CreateHubAsync(
                request.Name, request.Description, string.Empty, request.Price);

            return Results.Created($"/api/hubs/{result}", result);
        }

        [HttpGet]
        public async Task<IResult> GetAllHubs()
        {
            var result = await _hubService.GetAllHubAsync();
            List<HubResponse> response =
                [.. result.Select(h => new HubResponse(h.Id, h.Name, h.Description, h.ImageUrl, h.Price))];

            return Results.Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetHubById([FromRoute] Guid id)
        {
            var result = await _hubService.GetHubByIdAsync(id);
            HubResponse response = 
                new(result.Id, result.Name, result.Description, result.ImageUrl, result.Price);

            return Results.Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateHub([FromRoute] Guid id, [FromBody] UpdateHubRequest request)
        {
            await _hubService.UpdateHubAsync(id, request.Name, request.Description, string.Empty, request.Price);

            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteHub([FromRoute] Guid id)
        {
            await _hubService.DeleteHubAsync(id);

            return Results.NoContent();
        }
    }
}
