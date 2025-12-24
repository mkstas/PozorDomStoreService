using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Carts
{
    public record AddDeviceToCartRequest(
        [Required(ErrorMessage = "DeviceId is required.")]
        [StringLength(36, ErrorMessage = "DeviceId length must be 36 characters (GUID format).")]
        string DeviceId);
}
