using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductDescription).HasMaxLength(250);
            builder.Property(p => p.ProductCount).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Product");
        }
    }
}
