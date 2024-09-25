using Microsoft.EntityFrameworkCore;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Domain.Models;
using WebApiService.Infrastructure.EntityTypeConfiguration;

namespace WebApiService.Infrastructure
{
    internal class WebApiServiceContext : DbContext, IWebApiServiceContext
    {
        public WebApiServiceContext(DbContextOptions<WebApiServiceContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
