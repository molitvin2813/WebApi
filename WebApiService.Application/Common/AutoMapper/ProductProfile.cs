using AutoMapper;
using WebApiService.Application.Common.DTO.ProductDto;
using WebApiService.Application.Mediator.Commands.ProductCommands.CreateProduct;
using WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct;
using WebApiService.Domain.Models;

namespace WebApiService.Application.Common.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductDto, CreateProductCommand>();
            CreateMap<CreateProductCommand, Product>();

            CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForAllMembers(opts => opts.Condition((src, dst, srcMember) => srcMember != null));
            CreateMap<UpdateProductCommand, Product>()
                .ForAllMembers(opts => opts.Condition((src, dst, srcMember) => srcMember != null));
        }
    }
}
