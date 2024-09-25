using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommand
        : MediatrCommand
    {
        public int ProductId { get; set; }
    }
}
