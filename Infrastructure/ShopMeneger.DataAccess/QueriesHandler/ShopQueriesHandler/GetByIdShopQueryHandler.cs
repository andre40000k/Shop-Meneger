using MediatR;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.Application.Queries.ShopQueries;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.DataAccess.QueriesHandler.ShopQueriesHandler
{
    public class GetByIdShopQueryHandler : IRequestHandler<GetByIdShopQuery, Shop>
    {
        private readonly IShopRepositories _repository;

        public GetByIdShopQueryHandler(IShopRepositories repository)
        {
            _repository = repository;
        }

        public async Task<Shop?> Handle(GetByIdShopQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Get {0}", request);
            var currentShop = await _repository.GetByIdAsync(request.ShopId, cancellationToken);
            Console.WriteLine("Get {0}", currentShop);

            if (currentShop == null)
            {
                return null;
            }

            return currentShop;
        }
    }
}
