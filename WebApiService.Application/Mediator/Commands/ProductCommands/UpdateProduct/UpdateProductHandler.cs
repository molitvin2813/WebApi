using AutoMapper;
using MediatR;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductHandler
        : IRequestHandler<UpdateProductCommand, IServiceResponse>
    {
        public UpdateProductHandler(
            IMapper mapper,
            IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public async Task<IServiceResponse> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _service
                .UpdateProduct(request, cancellationToken);

            return new ServiceResponseWrite(result, String.Empty);
        }
    }
}
