using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
           builder.Property(p=>p.Description).IsRequired();
           builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
           builder.Property(p=>p.PictureUrl).IsRequired();
           builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);  // The specification here is basically saying that each Product has one ProductBrand, but a ProductBrand can have many products. This is already taken care of by EF but we can specify the relationships here too.
           builder.HasOne(t=>t.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);

        }
    }
}