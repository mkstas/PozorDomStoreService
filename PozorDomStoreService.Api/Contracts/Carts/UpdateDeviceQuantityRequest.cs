using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Carts
{
    public record UpdateDeviceQuantityRequest(
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity cannot be less than 1.")]
        int Quantity);
}
