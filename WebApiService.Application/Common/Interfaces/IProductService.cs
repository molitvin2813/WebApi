using WebApiService.Application.Common.DTO.ProductDto;
using WebApiService.Application.Mediator.Commands.ProductCommands.CreateProduct;
using WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct;

namespace WebApiService.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetAllProduct(CancellationToken cancellationToken);
        Task<GetProductDto> GetProductById(int id, CancellationToken cancellationToken);

        Task<bool> CreateProduct(CreateProductCommand Product, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int id, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(UpdateProductCommand Product, CancellationToken cancellationToken);
    }
}
