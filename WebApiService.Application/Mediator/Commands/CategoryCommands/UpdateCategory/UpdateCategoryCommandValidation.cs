using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandValidation
        : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
