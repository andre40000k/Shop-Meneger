using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMeneger.Application.Commands.ShopCommands;
using ShopMeneger.Application.Queries.ShopQueries;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopMeneger.Api.Controllers.v1
{
    //[ApiVersion("1.0")]
    //[ApiController]
    public class ShopController : BaseApiController
    {
        [HttpPost]
        [Route("/createShop")]
        public async Task<IActionResult> CreateShop([FromBody] CreateShopCommand createShopCommand)
        {
            //var shop = JsonConvert.SerializeObject(createShopCommand);

            if (createShopCommand == null)
                return BadRequest("Sorry");

            await Mediator.Send(createShopCommand);

            string mes = JsonConvert.SerializeObject("Successful");

            return Ok(mes);
        }

        [HttpGet]
        [Route("/getByIdShop")]
        public async Task<IActionResult> GetByIdShop([FromBody] GetByIdShopQuery shopIdQuery)
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
