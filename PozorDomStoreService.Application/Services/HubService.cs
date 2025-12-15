using PozorDomStoreService.Infrastructure.Exceptions;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;

namespace PozorDomStoreService.Application.Services
{
    public class HubService(
        IHubRepository hubRepository) : IHubService
    {
        private readonly IHubRepository _hubRepository = hubRepository;

        public Task<Guid> CreateHubAsync(string name, double price)
        {
            return _hubRepository.CreateAsync(name, price);
        }

        public async Task<List<HubEntity>> GetAllHubAsync()
        {
            var hubs = await _hubRepository.GetAllAsync();

            if (hubs.Count == 0)
                throw new NotFoundException("Hubs not found.");

            return hubs;
        }

        public async Task<HubEntity> GetHubByIdAsync(Guid id)
        {
            return await _hubRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Hub not found.");
        }

        public async Task UpdateHubAsync(Guid id, string name, double price)
        {
            var rows = await _hubRepository.UpdateAsync(id, name, price);

            if (rows == 0)
                throw new NotFoundException("Hub not found.");
        }

        public async Task DeleteHubAsync(Guid id)
        {
            var rows = await _hubRepository.DeleteAsync(id);

            if (rows == 0)
                throw new NotFoundException("Hub not found.");
        }
    }
}
