using BasketCase.Api.Models;
using BasketCase.Application.Queries.Product;
using BasketCase.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BasketCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseViewModel<IEnumerable<ProductViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllProductQuery { });

            if (result is null)
                return NotFound();

            var responseModel = new BaseResponseViewModel<IEnumerable<ProductViewModel>>
            {
                Data = result
            };

            return Ok(responseModel);
        }
    }
}