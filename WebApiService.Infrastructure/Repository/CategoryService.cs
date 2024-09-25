using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Common.Exceptions;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory;
using WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory;
using WebApiService.Domain.Models;

namespace WebApiService.Infrastructure.Repository
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(IWebApiServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly IWebApiServiceContext _context;
        private readonly IMapper _mapper;

        public async Task<List<GetCategoryDto>> GetAllCategory(CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .AsNoTracking()
                .Select(x => new GetCategoryDto()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<GetCategoryDto> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
              .AsNoTracking()
              .Select(x => new GetCategoryDto()
              {
                  CategoryId = x.CategoryId,
                  Name = x.Name,
              })
              .FirstOrDefaultAsync(x => x.CategoryId == id, cancellationToken);

            if (result == null)
            {
                throw new RecordNotFoundException(nameof(Category), id);
            }
            return result;
        }

        public async Task<bool> CreateCategory(CreateCategoryCommand category, CancellationToken cancellationToken)
        {
            await _context.Categories.AddAsync(_mapper.Map<Category>(category), cancellationToken);
            return true;
        }

        public async Task<bool> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Categories
               .FirstOrDefaultAsync(x => x.CategoryId == id);

            if (data == null)
            {
                throw new RecordNotFoundException(nameof(Category), id);
            }

            _context.Categories.Remove(data);

            return true;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryCommand category, CancellationToken cancellationToken)
        {
            var data = await _context.Categories
             .FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId, cancellationToken);

            if (data == null)
            {
                throw new RecordNotFoundException(nameof(Category), category.CategoryId);
            }

            _mapper.Map(category, data);
            return true;
        }
    }
}
