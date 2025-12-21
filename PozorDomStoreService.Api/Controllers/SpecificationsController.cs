using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Specification;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/store/specifications")]
    public class SpecificationsController(
        ISpecificationService specificationService) : ControllerBase
    {
        private readonly ISpecificationService _specificationService = specificationService;

        [HttpPost]
        public async Task<IResult> CreateSpecification([FromBody] CreateSpecificationRequest request)
        {
            var result = await _specificationService.CreateSpecificationAsync(request.Name);

            return Results.Created($"/api/v1/store/specifications{result}", result);
        }

        [HttpGet]
        public async Task<IResult> GetAllSpecifications()
        {
            var result = await _specificationService.GetSpecificationAllAsync();
            List<SpecificationResponse> response =
                [.. result.Select(s => new SpecificationResponse(s.Id, s.Name))];

            return Results.Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetSpecificationById([FromRoute] Guid id)
        {
            var result = await _specificationService.GetSpecificationByIdAsync(id);
            SpecificationResponse response = new(result.Id, result.Name);

            return Results.Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateSpecification([FromRoute] Guid id, [FromBody] UpdateSpecificationRequest request)
        {
            await _specificationService.UpdateSpecificationAsync(id, request.Name);

            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteSpecification([FromRoute] Guid id)
        {
            await _specificationService.DeleteSpecificationAsync(id);

            return Results.NoContent();
        }
    }
}
