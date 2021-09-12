using BasketCase.Api.Models;
using BasketCase.Application.Commands.AddProductToBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BasketCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(BaseResponseViewModel<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponseViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddProductToBasketCommand command)
        {
            var result = await mediator.Send(command);
            var returnModel = new BaseResponseViewModel<string>
            {
                Data = result
            };

            return Ok(returnModel);
        }
    }
}