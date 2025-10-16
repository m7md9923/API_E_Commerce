using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configrations;

internal class ProductConfigrations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.productBrand)
            .WithMany()
            .HasForeignKey(p => p.BrandId);

        builder.HasOne(p => p.productType)
            .WithMany()
            .HasForeignKey(p => p.TypeId);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(15,2)");
    }
}