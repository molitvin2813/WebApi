using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommand
        : MediatrCommand
    {
        public string Name { get; set; }
    }
}
