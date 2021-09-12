using BasketCase.Application.Services.Interfaces;
using BasketCase.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BasketCase.Application.Queries.Product
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductViewModel>>
    {

    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductService productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken) =>
            await productService.GetAll();
    }
}