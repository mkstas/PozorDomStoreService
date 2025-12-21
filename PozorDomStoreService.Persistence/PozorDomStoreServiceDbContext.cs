using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Persistence.Configuratoins;

namespace PozorDomStoreService.Persistence
{
    public class PozorDomStoreServiceDbContext(
        DbContextOptions<PozorDomStoreServiceDbContext> options) : DbContext(options)
    {
        public DbSet<HubEntity> Hubs { get; set; }
        public DbSet<DeviceTypeEntity> DeviceTypes { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<SpecificationEntity> Specifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HubConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
