using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand
        : MediatrCommand
    {
        public int CategoryId { get; set; }

        public required string Name { get; set; }
    }
}
