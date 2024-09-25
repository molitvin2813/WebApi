using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand
        : MediatrCommand
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
