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

            builder.HasOne(ds => ds.Device)
                   .WithMany(d => d.DeviceSpecifications)
                   .HasForeignKey(ds => ds.DeviceId)
                   .IsRequired();

            builder.HasOne(ds => ds.Specification)
                   .WithMany(s => s.DeviceSpecifications)
                   .HasForeignKey(ds => ds.SpecificationId)
                   .IsRequired();
        }
    }
}
