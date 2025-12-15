using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Api.Middlewares;
using PozorDomStoreService.Persistence;

namespace PozorDomStoreService.Api.Extensions
{
    public static class ApiExtensions
    {
        public static void UseGlobalExceptionHandler(
            this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();
        }

        public static void AddCorsConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var origins = configuration.GetSection("AllowedOrigins").Get<string[]>()
                ?? throw new InvalidOperationException("AllowedOrigins not configured.");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(origins)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        public static void AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString(nameof(PozorDomStoreServiceDbContext))
                ?? throw new InvalidOperationException("Database connection string not configured.");

            services.AddDbContext<PozorDomStoreServiceDbContext>(
                options =>
                {
                    options.UseNpgsql(connection);
                });
        }
    }
}
