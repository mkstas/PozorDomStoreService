using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PozorDomStoreService.Api.Middlewares;
using PozorDomStoreService.Infrastructure.Providers;
using PozorDomStoreService.Infrastructure.Providers.Images;
using PozorDomStoreService.Persistence;
using System.Security.Claims;

namespace PozorDomStoreService.Api.Extensions
{
    public static class ApiExtensions
    {
        public static void UseGlobalExceptionHandler(
            this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();
        }

        public static void UseUserAuthHeadersHandler(
            this IApplicationBuilder builder)
        {
            builder.UseMiddleware<UserAuthHeadersHandler>();
        }

        public static void AddStorageConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var storageOptions = configuration.GetSection(nameof(ImageOptions))
                ?? throw new InvalidOperationException("ImageOptions not configured.");

            services.Configure<ImageOptions>(storageOptions);
        }

        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)
                ?? throw new InvalidOperationException("User ID claim not found.");

            return Guid.Parse(userIdClaim.Value);
        }

        public static void AddCorsConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>()
                ?? throw new InvalidOperationException("AllowedOrigins not configured.");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins)
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
            var connectionString = configuration.GetConnectionString(nameof(PozorDomStoreServiceDbContext))
                ?? throw new InvalidOperationException("Database connection string not configured.");

            services.AddDbContext<PozorDomStoreServiceDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                });
        }
    }
}
