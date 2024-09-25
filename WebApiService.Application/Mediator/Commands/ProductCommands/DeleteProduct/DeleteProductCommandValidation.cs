using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandValidation
        : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidation()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
        }
    }
}
