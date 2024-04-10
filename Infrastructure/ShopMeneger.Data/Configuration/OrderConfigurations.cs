using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Configuration
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.OrderId);
            builder.Property(p => p.OrderId).ValueGeneratedOnAdd();
            builder.Property(p => p.CreateAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Order");
        }
    }
}
