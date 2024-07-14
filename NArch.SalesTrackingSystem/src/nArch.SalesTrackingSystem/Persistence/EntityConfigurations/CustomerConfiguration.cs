using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CompanyName).HasColumnName("CompanyName");

        //relationship
        builder.HasMany(x => x.Sales);

    }
}