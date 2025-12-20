using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PozorDomStoreService.Domain.Entities;

namespace PozorDomStoreService.Persistence.Configuratoins
{
    public class HubConfiguration : IEntityTypeConfiguration<HubEntity>
    {
        public void Configure(EntityTypeBuilder<HubEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(h => h.Description)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(1024);

            builder.Property(h => h.ImageUrl)
                   .HasDefaultValue(string.Empty)
                   .HasMaxLength(256);

            builder.Property(h => h.Price)
                   .IsRequired();

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
