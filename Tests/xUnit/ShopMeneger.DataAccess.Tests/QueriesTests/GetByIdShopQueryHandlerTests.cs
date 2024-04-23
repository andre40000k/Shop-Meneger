using AutoFixture;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.Application.Queries.ShopQueries;
using ShopMeneger.DataAccess.QueriesHandler.ShopQueriesHandler;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.DataAccess.Tests.QueriesTests
{
    public class GetByIdShopQueryHandlerTests
    {
        private readonly Mock<IShopRepositories> _mockRepo;
        private readonly GetByIdShopQueryHandler _command;
        protected readonly CancellationTokenSource _cts = new();

        public GetByIdShopQueryHandlerTests()
        {
            _mockRepo = new Mock<IShopRepositories>();
            _command = new GetByIdShopQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async void GetShopById_GetNullShop_ReturnNull()
        {
            // Arrange
            var fixture = new Fixture();

            var shopIdCommand = new GetByIdShopQuery { ShopId = Guid.NewGuid() };

            _mockRepo.Setup(x => x.GetByIdAsync(shopIdCommand.ShopId, _cts.Token)).ReturnsAsync((Shop)null);

            //Act
            var result = await _command.Handle(shopIdCommand, _cts.Token);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async void GetShopById_GetNullShop_ReturnShop()
        {
            // Arrange

            var fixture = new Fixture();

            var shopIdCommand = new GetByIdShopQuery { ShopId = Guid.Parse("5E4454BA-37AD-4826-B06A-F37720163DDB") };

            var justShop = fixture.Build<Shop>()
                .With(x => x.ShopId, Guid.Parse("5E4454BA-37AD-4826-B06A-F37720163DDB"))
                .With(x => x.ShopName, "dplpsdvps")
                .Without(x => x.ShopCategorys)
                .Create();

            _mockRepo.Setup(x => x.GetByIdAsync(shopIdCommand.ShopId, _cts.Token)).ReturnsAsync(justShop);

            //Act

            var result = await _command.Handle(shopIdCommand, _cts.Token);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(justShop, result);
            Assert.True(justShop.ShopId == result.ShopId);
        }

    }
}
