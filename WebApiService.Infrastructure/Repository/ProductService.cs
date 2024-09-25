using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Common.DTO.ProductDto;
using WebApiService.Application.Common.Exceptions;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Mediator.Commands.ProductCommands.CreateProduct;
using WebApiService.Application.Mediator.Commands.ProductCommands.UpdateProduct;
using WebApiService.Domain.Models;

namespace WebApiService.Infrastructure.Repository
{
    public class ProductService : IProductService
    {
        public ProductService(IWebApiServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly IWebApiServiceContext _context;
        private readonly IMapper _mapper;

        public async Task<List<GetProductDto>> GetAllProduct(CancellationToken cancellationToken)
        {
            var data = await _context.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Select(x => new GetProductDto()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    Category = new GetCategoryDto()
                    {
                        CategoryId = x.Category.CategoryId,
                        Name = x.Category.Name,
                    }
                })
                .ToListAsync(cancellationToken);

            return data;
        }

        public async Task<GetProductDto> GetProductById(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Select(x => new GetProductDto()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    Category = new GetCategoryDto()
                    {
                        CategoryId = x.Category.CategoryId,
                        Name = x.Category.Name,
                    }
                })
                .FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken);

            if (data == null)
            {
                throw new RecordNotFoundException(nameof(Product), id);
            }

            return data;
        }

        public async Task<bool> CreateProduct(CreateProductCommand product, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.CategoryId == product.CategoryId, cancellationToken);

            if (category == null)
            {
                throw new RecordNotFoundException(nameof(Category), product.CategoryId);
            }

            var data = _mapper.Map<Product>(product);

            await _context.Products.AddAsync(data, cancellationToken);

            return true;
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Products
              .FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken);

            if (data == null)
            {
                throw new RecordNotFoundException(nameof(Product), id);
            }

            _context.Products.Remove(data);

            return true;
        }

        public async Task<bool> UpdateProduct(UpdateProductCommand product, CancellationToken cancellationToken)
        {
            var data = await _context.Products
                .FirstOrDefaultAsync(x => x.ProductId == product.ProductId, cancellationToken);

            if (data == null)
            {
                throw new RecordNotFoundException(nameof(Product), product.ProductId);
            }

            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CategoryId == product.CategoryId);

            if (category == null)
            {
                throw new RecordNotFoundException(nameof(Category), product.CategoryId);
            }

            _mapper.Map(product, data);

            return true;
        }
    }
}
