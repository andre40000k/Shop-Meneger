using Microsoft.EntityFrameworkCore;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Shop> Shops { get; set; }
        DbSet<ShopCategory> ShopCategories { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
