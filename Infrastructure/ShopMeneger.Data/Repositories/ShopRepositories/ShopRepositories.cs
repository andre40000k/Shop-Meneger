using Microsoft.EntityFrameworkCore;
using ShopMeneger.Application.Interfaces;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Repositories.ShopRepositories
{
    public class ShopRepositories : IShopRepositories
    {
        private readonly IApplicationDbContext _context;

        public ShopRepositories(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddShopAsync(Shop shop, CancellationToken cancellationToken = default)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Shop?> GetByIdAsync(Guid shopId, CancellationToken cancellationToken = default)
        {

            Console.WriteLine();

            var shop = await _context.Shops.AsNoTracking()
                .FirstOrDefaultAsync(s => s.ShopId == shopId);

            Console.WriteLine();

            return shop; 
        }
    }
}
