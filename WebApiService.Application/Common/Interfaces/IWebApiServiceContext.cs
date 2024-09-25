using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiService.Domain.Models;

namespace WebApiService.Application.Common.Interfaces
{
    public interface IWebApiServiceContext
    {
        ChangeTracker ChangeTracker { get; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
