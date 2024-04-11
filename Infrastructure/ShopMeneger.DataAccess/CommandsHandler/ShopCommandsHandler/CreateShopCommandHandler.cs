using MediatR;
using ShopMeneger.Application.Commands.ShopCommands;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.DataAccess.CommandsHandler.ShopCommandsHandler
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, Unit>
    {
        private readonly IShopRepositories _repository;

        public CreateShopCommandHandler(IShopRepositories repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddShopAsync( new Shop
            {
                ShopName = request.ShopName,
                ShopDescription = request.ShopDescription
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
