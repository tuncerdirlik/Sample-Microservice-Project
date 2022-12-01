using CustomerMicroService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMicroService.Persistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(k => k.FirstName).IsRequired(false).HasMaxLength(150);
            builder.Property(k => k.LastName).IsRequired(false).HasMaxLength(150);
            builder.Property(k => k.Email).IsRequired(false).HasMaxLength(150);
        }
    }
}
