﻿namespace WebApiService.Application.Common.DTO.ProductDto
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
