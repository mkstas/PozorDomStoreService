using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Specification
{
    public record UpdateSpecificationRequest(
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(128, ErrorMessage = "Name cannot exceed 64 characters.")]
        string Name
    );
}
