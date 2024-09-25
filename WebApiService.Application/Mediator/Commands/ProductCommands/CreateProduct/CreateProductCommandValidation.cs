using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidation
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
