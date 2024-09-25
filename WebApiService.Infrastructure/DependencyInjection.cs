using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Infrastructure.Repository;

namespace WebApiService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<WebApiServiceContext>(options =>
                options.UseInMemoryDatabase(databaseName: "WebApiDB"));

            services.AddScoped<IWebApiServiceContext>(provider => provider.GetService<WebApiServiceContext>());

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
