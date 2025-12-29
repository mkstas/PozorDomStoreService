using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Specifications
{
    public record CreateSpecificationRequest(
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(64, ErrorMessage = "Name cannot exceed 64 characters.")]
        string Name);
}
