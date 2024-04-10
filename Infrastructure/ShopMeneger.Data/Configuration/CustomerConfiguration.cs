using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(k => k.CustonerId);
            builder.Property(p => p.CustonerId).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.BirthDay);

            builder.ToTable("Customer");
        }
    }
}
