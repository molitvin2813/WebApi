using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Common.Mediatr;
using WebApiService.Domain.AbstractClass;

namespace WebApiService.Application.Behaviors
{
    public class PostProcessor<TRequest, TResponse> :
         IRequestPostProcessor<TRequest, TResponse>
         where TRequest : MediatrCommand
         where TResponse : IServiceResponse
    {

        public PostProcessor(
            IWebApiServiceContext context)
        {
            _context = context;
        }

        private readonly IWebApiServiceContext _context;

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _context.ChangeTracker.Entries<AuditableEntity>().ToList()
                .ForEach(x =>
                {
                    switch (x.State)
                    {
                        case EntityState.Added:
                            var date = DateTime.Now;
                            x.Entity.CreatedDate = date;
                            x.Entity.UpdatedDate = date;
                            x.Entity.ChangedById = Guid.Empty;
                            break;

                        case EntityState.Modified:
                            x.Entity.UpdatedDate = DateTime.Now;
                            x.Entity.ChangedById = Guid.Empty;
                            break;
                    }
                });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
