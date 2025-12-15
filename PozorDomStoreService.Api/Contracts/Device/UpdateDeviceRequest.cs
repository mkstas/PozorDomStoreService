using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Device
{
    public record UpdateDeviceRequest(
        [Required(ErrorMessage = "DeviceTypeId is required.")]
        [StringLength(36, ErrorMessage = "DeviceTypeId length must be 36 characters (GUID format).")]
        Guid DeviceTypeId,

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        string Name,

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be less than 0.")]
        double Price
    );
}
