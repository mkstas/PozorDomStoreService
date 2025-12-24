using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;
using PozorDomStoreService.Domain.Shared.Enums;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.UserId)
                   .IsRequired();

            builder.Property(o => o.Status)
                   .HasDefaultValue(OrderStatus.Pending)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasMany(o => o.OrderDevices)
                   .WithOne(od => od.Order)
                   .HasForeignKey(od => od.OrderId);

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
