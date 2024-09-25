using AutoMapper;
using MediatR;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryHandler
        : IRequestHandler<UpdateCategoryCommand, IServiceResponse>
    {
        public UpdateCategoryHandler(
            IMapper mapper,
            ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public async Task<IServiceResponse> Handle(
            UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _service.UpdateCategory(request, cancellationToken);
            return new ServiceResponseWrite(result, String.Empty);
        }
    }
}
