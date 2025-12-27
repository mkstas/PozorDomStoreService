using Microsoft.EntityFrameworkCore;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Persistence.Configuratoins;

namespace PozorDomStoreService.Persistence
{
    public class PozorDomStoreServiceDbContext(
        DbContextOptions<PozorDomStoreServiceDbContext> options) : DbContext(options)
    {
        public DbSet<DeviceTypeEntity> DeviceTypes { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<SpecificationEntity> Specifications { get; set; }
        public DbSet<DeviceSpecificationEntity> DeviceSpecifications { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartDeviceEntity> CartDevices { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDeviceEntity> OrderDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceSpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDeviceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
