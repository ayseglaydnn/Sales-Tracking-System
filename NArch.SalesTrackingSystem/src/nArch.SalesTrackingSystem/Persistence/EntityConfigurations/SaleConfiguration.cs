using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CustomerId).HasColumnName("CustomerId");
        builder.Property(s => s.ProductId).HasColumnName("ProductId");
        builder.Property(s => s.Quantity).HasColumnName("Quantity");
        builder.Property(s => s.TotalAmount).HasColumnName("TotalAmount");
        builder.Property(s => s.SaleDate).HasColumnName("SaleDate");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        //relationship
        builder.HasOne(x => x.Product);
        builder.HasOne(x => x.Customer);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}