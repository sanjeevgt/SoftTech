using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfiguration :  IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
         builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProdName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProdDescription).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(x => x.ProductCategory).WithMany()
                .HasForeignKey(p => p.ProdCatId);
        }
            
    }
}