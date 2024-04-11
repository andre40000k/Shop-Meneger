using MediatR;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Application.Queries.ShopQueries
{
    public class GetByIdShopQuery : IRequest<Shop>
    {
        public Guid ShopId { get; set; }
    }
}
