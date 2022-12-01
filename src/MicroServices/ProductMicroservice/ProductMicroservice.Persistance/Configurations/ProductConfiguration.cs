using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMicroservice.Domain;

namespace ProductMicroservice.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(k => k.Title).IsRequired(false).HasMaxLength(50);
            builder.Property(k => k.Description).IsRequired(false);
            builder.Property(k => k.Price).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.Property(k => k.StockCount).IsRequired(true);
            builder.Property(k => k.CreatedDate).IsRequired(true);
            builder.Property(k => k.Status).IsRequired(true);
        }
    }
}
