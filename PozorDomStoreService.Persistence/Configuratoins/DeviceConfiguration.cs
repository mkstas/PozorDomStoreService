using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class DeviceConfiguration : IEntityTypeConfiguration<DeviceEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(d => d.DeviceTypeId)
                   .IsRequired();

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.HasIndex(d => d.Name)
                   .IsUnique();

            builder.Property(d => d.Description)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(1024);

            builder.Property(d => d.ImageUrl)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(256);

            builder.Property(d => d.Price)
                   .IsRequired();

            builder.HasOne(d => d.DeviceType)
                   .WithMany(dt => dt.Devices)
                   .HasForeignKey(d => d.DeviceTypeId);

            builder.HasMany(d => d.DeviceSpecifications)
                   .WithOne(ds => ds.Device)
                   .HasForeignKey(ds => ds.DeviceId);

            builder.HasMany(d => d.CartDevices)
                   .WithOne(cd => cd.Device)
                   .HasForeignKey(cd => cd.DeviceId);

            builder.HasMany(d => d.OrderDevices)
                   .WithOne(od => od.Device)
                   .HasForeignKey(od => od.DeviceId);
        }
    }
}
