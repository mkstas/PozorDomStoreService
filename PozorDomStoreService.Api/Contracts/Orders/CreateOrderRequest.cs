using PozorDomStoreService.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Orders
{
    public record CreateOrderRequest(
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(256, ErrorMessage = "Address cannot exceed 256 characters.")]
        string Address,

        [Required]
        List<CartDeviceEntity> CartDevices);
}
