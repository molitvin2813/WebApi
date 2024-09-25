using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Queries.CategoryQueries.GetCategoryById
{
    public class GetCategoryByIdQuery : MediatrQuery
    {
        public int CategoryId { get; set; }
    }
}
