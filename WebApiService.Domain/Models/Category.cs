using WebApiService.Domain.AbstractClass;

namespace WebApiService.Domain.Models
{
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
