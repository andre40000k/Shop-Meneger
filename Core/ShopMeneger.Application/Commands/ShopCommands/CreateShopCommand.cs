using MediatR;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Application.Commands.ShopCommands
{
    public class CreateShopCommand : IRequest<Unit>
    {
        public string ShopName { get; set; } = default!;
        public string ShopDescription { get; set; } = default!;

        //public Shop Upsert()
        //{
        //    return new Shop
        //    {
        //        ShopName = ShopName,
        //        ShopDescription = ShopDescription
        //    };
        //}
    }
}
