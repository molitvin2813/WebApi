using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidation
        : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
