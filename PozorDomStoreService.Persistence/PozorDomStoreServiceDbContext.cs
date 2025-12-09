using Microsoft.EntityFrameworkCore;

namespace PozorDomStoreService.Persistence
{
    public class PozorDomStoreServiceDbContext(
        DbContextOptions<PozorDomStoreServiceDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
