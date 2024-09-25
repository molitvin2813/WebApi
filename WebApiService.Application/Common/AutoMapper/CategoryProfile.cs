using AutoMapper;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory;
using WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory;
using WebApiService.Domain.Models;

namespace WebApiService.Application.Common.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryDto, CreateCategoryCommand>();
            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<UpdateCategoryDto, UpdateCategoryCommand>()
                .ForAllMembers(opts => opts.Condition((src, dst, srcMember) => srcMember != null));
            CreateMap<UpdateCategoryCommand, Category>()
                .ForAllMembers(opts => opts.Condition((src, dst, srcMember) => srcMember != null));
        }
    }
}
