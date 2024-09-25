using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandValidation
        : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
