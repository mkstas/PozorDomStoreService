using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class DeviceTypeConfiguration : IEntityTypeConfiguration<DeviceTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceTypeEntity> builder)
        {
            builder.HasKey(dt => dt.Id);

            builder.Property(dt => dt.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(dt => dt.Name)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.HasIndex(dt => dt.Name)
                   .IsUnique();

            builder.HasMany(dt => dt.Devices)
                   .WithOne(d => d.DeviceType)
                   .HasForeignKey(d => d.DeviceTypeId);
        }
    }
}
