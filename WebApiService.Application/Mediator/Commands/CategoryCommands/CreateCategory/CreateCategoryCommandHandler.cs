using AutoMapper;
using MediatR;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, IServiceResponse>
    {
        public CreateCategoryCommandHandler(
            IMapper mapper,
            ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public async Task<IServiceResponse> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {

            var result = await _service
                .CreateCategory(request, cancellationToken);

            return new ServiceResponseWrite(result, String.Empty);
        }
    }
}
