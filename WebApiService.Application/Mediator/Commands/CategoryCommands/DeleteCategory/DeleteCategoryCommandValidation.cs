using FluentValidation;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandValidation
        : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidation()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
