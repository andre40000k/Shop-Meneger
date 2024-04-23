using AutoFixture;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.DataAccess.CommandsHandler.ShopCommandsHandler;
using ShopMeneger.Application.Commands.ShopCommands;
using MediatR;

namespace ShopMeneger.DataAccess.Tests.CommandsTests
{
    public class CreateShopCommandHandlerTests
    {
        private readonly Mock<IShopRepositories> _mockRepo;
        private readonly CreateShopCommandHandler _command;
        protected readonly CancellationTokenSource _cts = new();

        public CreateShopCommandHandlerTests()
        {
            _mockRepo = new Mock<IShopRepositories>();
            _command = new CreateShopCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async void CreateShop_ShopNameIsNull_ReturnUnitValue() 
        {
            var fixture = new Fixture();
            
            var newShop1 = fixture.Build<CreateShopCommand>()
                .With(x => x.ShopName, "")
                .Create();

            var result = await _command.Handle(newShop1, _cts.Token);

            Assert.Equal(result, Unit.Value);
        }
    }
}
