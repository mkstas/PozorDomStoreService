using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.DeviceType
{
    public record CreateDeviceTypeRequest(
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(128, ErrorMessage = "Name cannot exceed 64 characters.")]
        string Name
    );
}
