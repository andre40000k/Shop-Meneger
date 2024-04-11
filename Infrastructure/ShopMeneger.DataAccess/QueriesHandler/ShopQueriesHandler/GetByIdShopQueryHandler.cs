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

        public async Task<Shop> Handle(GetByIdShopQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.ShopId);
        }
    }
}
