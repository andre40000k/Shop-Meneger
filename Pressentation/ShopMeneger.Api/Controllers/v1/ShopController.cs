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
            return Ok(await Mediator.Send(createShopCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid shopId)
        {
            var receivedShop = await Mediator.Send(new GetByIdShopQuery { ShopId = shopId });

            if (receivedShop != null) 
            { 
            return Ok(receivedShop);
            }

            return BadRequest($"The shop by id {shopId}, has been not founded");
        }
    }
}
