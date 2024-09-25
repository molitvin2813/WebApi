using AutoMapper;
using MediatR;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Response;

namespace WebApiService.Application.Mediator.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryHandler
        : IRequestHandler<GetAllCategoryQuery, IServiceResponse>
    {

        public GetAllCategoryHandler(
            IMapper mapper,
            ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public async Task<IServiceResponse> Handle(
            GetAllCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _service.GetAllCategory(cancellationToken);

            return new ServiceResponseRead<List<GetCategoryDto>>()
            {
                Data = result,
            };
        }
    }
}
