using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class CartDeviceConfiguration : IEntityTypeConfiguration<CartDeviceEntity>
    {
        public void Configure(EntityTypeBuilder<CartDeviceEntity> builder)
        {
            builder.HasKey(cd => cd.Id);

            builder.Property(cd => cd.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(cd => cd.CartId)
                   .IsRequired();

            builder.Property(cd => cd.DeviceId)
                   .IsRequired();

            builder.Property(cd => cd.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);

            builder.HasOne(cd => cd.Cart)
                   .WithMany(c => c.CartDevices)
                   .HasForeignKey(cd => cd.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cd => cd.Device)
                   .WithMany(d => d.CartDevices)
                   .HasForeignKey(cd => cd.DeviceId);
        }
    }
}
