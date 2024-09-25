using AutoMapper;
using MediatR;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductHandler
        : IRequestHandler<DeleteProductCommand, IServiceResponse>
    {
        public DeleteProductHandler(
            IMapper mapper,
            IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public async Task<IServiceResponse> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _service.DeleteProduct(request.ProductId, cancellationToken);

            return new ServiceResponseWrite(result, String.Empty);
        }
    }
}
