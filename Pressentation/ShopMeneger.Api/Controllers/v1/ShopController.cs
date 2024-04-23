using Microsoft.AspNetCore.Mvc;
using ShopMeneger.Application.Commands.ShopCommands;
using ShopMeneger.Application.Queries.ShopQueries;

namespace ShopMeneger.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    //[ApiController]
    public class ShopController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShopCommand createShopCommand)
        {
            if (createShopCommand == null)
                return BadRequest("Sorry"); 

            return Ok(await Mediator.Send(createShopCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromBody] GetByIdShopQuery shopIdQuery)
        {
            Console.WriteLine("Get {0}", shopIdQuery);
            var receivedShop = await Mediator.Send(shopIdQuery);
            Console.WriteLine("Get {0}", receivedShop);
            if (receivedShop != null) 
            { 
            return Ok(receivedShop);
            }

            return BadRequest($"The shop by id {shopIdQuery.ShopId}, has been not founded");
        }
    }
}
