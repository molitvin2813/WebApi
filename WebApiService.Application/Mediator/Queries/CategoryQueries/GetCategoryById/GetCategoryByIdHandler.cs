using AutoMapper;
using MediatR;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Queries.CategoryQueries.GetCategoryById
{
    public class GetCategoryByIdHandler
        : IRequestHandler<GetCategoryByIdQuery, IServiceResponse>
    {
        public GetCategoryByIdHandler(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public async Task<IServiceResponse> Handle(
            GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _service
                .GetCategoryById(request.CategoryId, cancellationToken);

            return new ServiceResponseRead<GetCategoryDto>()
            {
                Data = result
            };
        }
    }
}
