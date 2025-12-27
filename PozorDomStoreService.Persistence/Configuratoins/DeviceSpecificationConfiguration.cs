using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class DeviceSpecificationConfiguration : IEntityTypeConfiguration<DeviceSpecificationEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceSpecificationEntity> builder)
        {
            builder.HasKey(ds => ds.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.DeviceId)
                   .IsRequired();

            builder.Property(s => s.SpecificationId)
                   .IsRequired();

            builder.HasOne(ds => ds.Device)
                   .WithMany(d => d.DeviceSpecifications)
                   .HasForeignKey(ds => ds.DeviceId);

            builder.HasOne(ds => ds.Specification)
                   .WithMany(s => s.DeviceSpecifications)
                   .HasForeignKey(ds => ds.SpecificationId);
        }
    }
}
