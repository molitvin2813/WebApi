using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand
        : MediatrCommand
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
