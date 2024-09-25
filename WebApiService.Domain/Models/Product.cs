using WebApiService.Domain.AbstractClass;

namespace WebApiService.Domain.Models
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
