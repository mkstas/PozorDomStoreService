using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Domain.Interfaces.Services
{
    public interface IHubService
    {
        Task<Guid> CreateHubAsync(string name, double price);
        Task<List<HubEntity>> GetAllHubAsync();
        Task<HubEntity> GetHubByIdAsync(Guid id);
        Task UpdateHubAsync(Guid id, string name, double price);
        Task DeleteHubAsync(Guid id);
    }
}
