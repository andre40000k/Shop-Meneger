using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Application.Interfaces.IRepositories
{
    public interface IShopRepositories 
    {
        Task AddShopAsync(Shop shop, CancellationToken cancellationToken = default);

        Task<Shop> GetByIdAsync(Guid shopId, CancellationToken cancellationToken = default);
    }
}
