using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.UserId)
                   .IsRequired();

            builder.HasIndex(c => c.UserId)
                   .IsUnique();

            builder.HasMany(c => c.CartDevices)
                   .WithOne(cd => cd.Cart)
                   .HasForeignKey(cd => cd.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

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
