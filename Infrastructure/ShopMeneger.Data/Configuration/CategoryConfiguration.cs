using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(k => k.CategoryId);
            builder.Property(p => p.CategoryId).ValueGeneratedNever();
            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CategoryDescription).HasMaxLength(250);

            builder.ToTable("Category");
        }
    }
}
