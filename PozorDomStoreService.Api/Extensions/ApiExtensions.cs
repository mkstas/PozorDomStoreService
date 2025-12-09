using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Persistence;

namespace PozorDomStoreService.Api.Extensions
{
    public static class ApiExtensions
    {
        public static void AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PozorDomStoreServiceDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(PozorDomStoreServiceDbContext)));
                });
        }
    }
}
