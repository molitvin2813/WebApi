using WebApiService.Application.Common.Mediatr;

namespace WebApiService.Application.Mediator.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommand
        : MediatrCommand
    {
        public int CategoryId { get; set; }
    }
}
