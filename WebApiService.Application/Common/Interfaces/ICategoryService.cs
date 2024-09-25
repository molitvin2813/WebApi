using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory;
using WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory;

namespace WebApiService.Application.Common.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<GetCategoryDto> GetCategoryById(int id, CancellationToken cancellationToken);

        Task<bool> CreateCategory(CreateCategoryCommand category, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(int id, CancellationToken cancellationToken);
        Task<bool> UpdateCategory(UpdateCategoryCommand category, CancellationToken cancellationToken);
    }
}
