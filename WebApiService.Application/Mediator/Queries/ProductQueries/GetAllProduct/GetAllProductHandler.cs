using AutoMapper;
using MediatR;
using WebApiService.Application.Common.DTO.ProductDto;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Queries.ProductQueries.GetAllProduct
{
    public class GetAllProductHandler
        : IRequestHandler<GetAllProductQuery, IServiceResponse>
    {
        public GetAllProductHandler(
            IMapper mapper,
            IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public async Task<IServiceResponse> Handle(
            GetAllProductQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _service.GetAllProduct(cancellationToken);

            return new ServiceResponseRead<List<GetProductDto>>()
            {
                Data = data
            };
        }
    }
}
