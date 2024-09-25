using WebApiService.Application.Common.DTO.CategoryDto;

namespace WebApiService.Application.Common.DTO.ProductDto
{
    public class GetProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public GetCategoryDto Category { get; set; }
    }
}
