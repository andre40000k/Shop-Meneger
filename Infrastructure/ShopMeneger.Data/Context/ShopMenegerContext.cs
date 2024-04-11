using Microsoft.EntityFrameworkCore;
using ShopMeneger.Application.Interfaces;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Context
{
    public class ShopMenegerContext : DbContext, IApplicationDbContext
    {
        public ShopMenegerContext(DbContextOptions<ShopMenegerContext> options) : base(options) { }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopMenegerContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

