using AutoFixture;
using ShopMeneger.Data.Context;
using ShopMeneger.Data.Repositories.ShopRepositories;
using ShopMeneger.Data.Tests.Helpers;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Tests.RepositoriesTests.ShopRepositoriesTests
{
    public class ShopRepositoriesTests : IDisposable
    {
        private readonly DbContextDecorator<ShopMenegerContext> _context;
        protected readonly CancellationTokenSource _cts = new();

        public ShopRepositoriesTests()
        {
            var options = DbContextHelper.CreateInMemoryDbOption<ShopMenegerContext>();

            _context = new DbContextDecorator<ShopMenegerContext>(options);
        }

        public void Dispose()
        {
            _context.Clear();
        }

        [Fact]
        public void GetShopByIdAsync_Get_Correct_Shop() 
        {
            // Arrange
            var fixture = new Fixture();

            var expectedShop1 = fixture.Build<Shop>()
                .With(x => x.ShopId, Guid.Parse("DAA2A192-9135-4511-997B-669F18F56660"))
                .With(x => x.ShopName, "Jast_Shop_V1")
                .Without(x => x.ShopCategorys)
                .Create();

            var expectedShop2 = fixture.Build<Shop>()
                .With(x => x.ShopId, Guid.Parse("B49CD59B-69BF-4AF0-9D25-2775CA1B6820"))
                .With(x => x.ShopName, "Jast_Shop_V2")
                .Without(x => x.ShopCategorys)
                .Create();

            _context.AddRangeAndSaveShop(new List<Shop> { expectedShop1, expectedShop2 }, default);

            _context.Assert( context =>
            {
                var sut = CreateSut(context);

                // Act
                
                var resultShop1 = sut.GetByIdAsync(Guid.Parse("DAA2A192-9135-4511-997B-669F18F56660"), default).Result;

                //Assert

                AssertMovieResult(expectedShop1, resultShop1);
            });
        }

        private static void AssertMovieResult(Shop expected, Shop result)
        {
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.True(expected.ShopId == result.ShopId);
            });
        }

        private static ShopRepositories CreateSut(ShopMenegerContext context) => new ShopRepositories(context);
    }
}
