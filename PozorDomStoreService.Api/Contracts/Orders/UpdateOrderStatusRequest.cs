using System.ComponentModel.DataAnnotations;

namespace PozorDomStoreService.Api.Contracts.Orders
{
    public record UpdateOrderStatusRequest(
        [Required(ErrorMessage = "Status is required.")]
        string Status);
}
