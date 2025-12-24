using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class OrderDeviceConfiguration : IEntityTypeConfiguration<OrderDeviceEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDeviceEntity> builder)
        {
            builder.HasKey(od => od.Id);

            builder.Property(od => od.OrderId)
                   .IsRequired();

            builder.Property(od => od.DeviceId)
                   .IsRequired();

            builder.Property(od => od.Quantity)
                   .IsRequired();

            builder.Property(od => od.Price)
                   .IsRequired();

            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDevices)
                   .HasForeignKey(od => od.OrderId);

            builder.HasOne(od => od.Device)
                   .WithMany(d => d.OrderDevices)
                   .HasForeignKey(od => od.DeviceId);

            builder.Property(dt => dt.CreatedAt)
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(dt => dt.UpdatedAt)
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate()
                   .IsRequired();
        }
    }
}
