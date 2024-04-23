using Microsoft.EntityFrameworkCore;
using ShopMeneger.Application.Interfaces;
using ShopMeneger.Data.Context;

namespace ShopMeneger.Data.Tests.Helpers
{
    public static class DbContextHelper
    {

        public static DbContextOptions<TContext> CreateInMemoryDbOption<TContext>() where TContext : ShopMenegerContext
        {
            return new DbContextOptionsBuilder<TContext>()
                .UseInMemoryDatabase("Temporary_Db")
                .Options;
        }
    }
}
