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

            builder.HasOne(d => d.DeviceType)
                   .WithMany(dt => dt.Devices)
                   .HasForeignKey(d => d.DeviceTypeId)
                   .IsRequired();

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(d => d.Description)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(1024);

            builder.Property(d => d.ImageUrl)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(256);

            builder.Property(d => d.Price)
                   .IsRequired();

            builder.Property(d => d.CreatedAt)
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(d => d.UpdatedAt)
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate()
                   .IsRequired();
        }
    }
}
