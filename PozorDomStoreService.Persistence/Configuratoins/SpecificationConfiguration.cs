using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class SpecificationConfiguration : IEntityTypeConfiguration<SpecificationEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.HasIndex(s => s.Name)
                   .IsUnique();

            builder.HasMany(s => s.DeviceSpecifications)
                   .WithOne(ds => ds.Specification)
                   .HasForeignKey(ds => ds.SpecificationId);
        }
    }
}
