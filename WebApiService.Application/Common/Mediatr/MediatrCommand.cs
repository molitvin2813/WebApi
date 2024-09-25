using MediatR;
using WebApiService.Application.Common.Interfaces;

namespace WebApiService.Application.Common.Mediatr
{
    public abstract class MediatrCommand : IRequest<IServiceResponse>
    {
    }
}
