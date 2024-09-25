using WebApiService.Application.Common.Interfaces;

namespace WebApiService.Application.Common.Response
{
    public class BaseServiceResponse : IServiceResponse
    {
        public BaseServiceResponse()
        {
            Success = true;
            Message = string.Empty;
        }

        public BaseServiceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}