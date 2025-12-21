using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.DeviceSpecification
{
    public record CreateDeviceSpecificationRequest(
        [Required(ErrorMessage = "DeviceId is required.")]
        [StringLength(36, ErrorMessage = "DeviceId length must be 36 characters (GUID format).")]
        string DeviceId,

        [Required(ErrorMessage = "SpecificationId is required.")]
        [StringLength(36, ErrorMessage = "SpecificationId length must be 36 characters (GUID format).")]
        string SpecificationId
    );
}
