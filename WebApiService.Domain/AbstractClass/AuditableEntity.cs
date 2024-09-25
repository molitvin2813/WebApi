namespace WebApiService.Domain.AbstractClass
{
    public abstract class AuditableEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? ChangedById { get; set; }
    }
}
