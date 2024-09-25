using AutoMapper;
using MediatR;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryHandler
        : IRequestHandler<DeleteCategoryCommand, IServiceResponse>
    {
        public DeleteCategoryHandler(
            IMapper mapper,
            ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public async Task<IServiceResponse> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _service
                .DeleteCategory(request.CategoryId, cancellationToken);

            return new ServiceResponseWrite(result, String.Empty);
        }
    }
}
