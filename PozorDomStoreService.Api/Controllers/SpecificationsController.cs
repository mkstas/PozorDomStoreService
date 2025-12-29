using Microsoft.AspNetCore.Mvc;
using PozorDomStoreService.Api.Contracts.Specifications;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecificationsController(
        ISpecificationService specificationService) : ControllerBase
    {
        private readonly ISpecificationService _specificationService = specificationService;

        [HttpPost]
        public async Task<IActionResult> CreateSpecification([FromBody] CreateSpecificationRequest request)
        {
            var specificationId = await _specificationService.CreateSpecificationAsync(request.Name);

            return CreatedAtAction(nameof(GetSpecificationById), new { id = specificationId });
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecificationAll()
        {
            var specifications = await _specificationService.GetSpecificationAllAsync();
            List<SpecificationResponse> response =
                [.. specifications.Select(s => new SpecificationResponse(s.Id, s.Name))];

            return Ok(response);
        }

        [HttpGet("{specificationId:guid}")]
        public async Task<IActionResult> GetSpecificationById([FromRoute] Guid specificationId)
        {
            var specification = await _specificationService.GetSpecificationByIdAsync(specificationId);
            SpecificationResponse response = new(specification.Id, specification.Name);

            return Ok(response);
        }

        [HttpPut("{specificationId:guid}")]
        public async Task<IActionResult> UpdateSpecificationById(
            [FromRoute] Guid specificationId,
            [FromBody] UpdateSpecificationRequest request)
        {
            await _specificationService.UpdateSpecificationByIdAsync(specificationId, request.Name);

            return NoContent();
        }

        [HttpDelete("{specificationId:guid}")]
        public async Task<IActionResult> DeleteSpecificationById([FromRoute] Guid specificationId)
        {
            await _specificationService.DeleteSpecificationByIdAsync(specificationId);

            return NoContent();
        }
    }
}
