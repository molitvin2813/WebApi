using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQuery
        : MediatrQuery
    {
        public int ProductId { get; set; }
    }
}
