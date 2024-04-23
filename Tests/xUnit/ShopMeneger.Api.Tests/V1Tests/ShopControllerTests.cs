using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ShopMeneger.Api.Controllers.v1;
using ShopMeneger.Application.Commands.ShopCommands;
using ShopMeneger.Application.Queries.ShopQueries;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Api.Tests.V1Tests
{
    public class ShopControllerTests
    {
        private readonly Mock<IMediator> _moqMediator;
        private readonly ShopController _controller;
        protected readonly CancellationTokenSource _cts = new();

        public ShopControllerTests()
        {
            _moqMediator = new Mock<IMediator>();
            _controller = new ShopController();
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            _controller.ControllerContext.HttpContext.RequestServices = new ServiceCollection()
                .AddScoped<IMediator>(_ => _moqMediator.Object)
                .BuildServiceProvider();

        }

        [Fact]
        public void Create_Shop_Return_BedRequest()
        {
            //Arreng 

            // Act

            var createRespons = _controller.Create(null).Result as ObjectResult;
            var item = createRespons.Value;

            // Assert
            Assert.NotNull(item);
            Assert.True(item.ToString() == "Sorry");
        }

        [Fact]
        public void Create_Shop_Return_Ok()
        {
            //Arreng 

            var fixture = new Fixture();

            var newShop = fixture.Build<CreateShopCommand>()
                .With(x => x.ShopName, "Shop")
                .Create();

            // Act

            var createRespons = _controller.Create(newShop).Result as ObjectResult;
            var item = createRespons.Value;

            // Assert
            Assert.NotNull(item);
            Assert.True(item.ToString() == Unit.Value.ToString());
        }

        [Fact]
        public async void GetById_Shop_Return_Ok_Shop()
        {

            //Arreng 
            var fixture = new Fixture();

            Guid testGuid = Guid.Parse("9201C983-1067-4A08-AABE-FFB5D339E976");

            var expectedShop = fixture.Build<Shop>()
                .With(x => x.ShopId, testGuid)
                .With(x => x.ShopName, "Shop")
                .Without(x => x.ShopCategorys)
                .Create();

            var shopId = new GetByIdShopQuery { ShopId = testGuid };

            _moqMediator.Setup(mediator => mediator.Send(shopId, default)).ReturnsAsync(expectedShop);

            // Act

            var createRespons = await _controller.GetById(shopId) as ObjectResult;
            var result = createRespons.Value as Shop;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result, expectedShop);
        }

        [Fact]
        public async void GetById_Shop_Return_BedRequest()
        {

            //Arreng 
            var fixture = new Fixture();

            Guid testGuid = Guid.Parse("9201C983-1067-4A08-AABE-FFB5D339E976");

            var shopId = new GetByIdShopQuery { ShopId = testGuid };

            _moqMediator.Setup(mediator => mediator.Send(shopId, default)).ReturnsAsync((Shop)null);

            string errorMesseng = $"The shop by id {testGuid}, has been not founded".ToLower();

            // Act

            var createRespons = await _controller.GetById(shopId) as ObjectResult;
            var result = createRespons.Value.ToString().ToLower();


            // Assert
            Assert.NotNull(result);
            Assert.True(errorMesseng == result);
        }

    }
}