using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Hub
{
    public record CreateHubRequest(
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        string Name,

        [MaxLength(1024, ErrorMessage = "Name cannot exceed 1024 characters.")]
        string Description,

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be less than 0.")]
        double Price
    );
}
