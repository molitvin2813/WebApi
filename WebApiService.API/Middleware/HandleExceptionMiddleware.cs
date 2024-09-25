using FluentValidation;
using Newtonsoft.Json;
using System.Net;
using WebApiService.Application.Common.Exceptions;
using WebApiService.Application.Common.Response;

namespace WebApiService.API.Middleware
{
    public class HandleExceptionMiddleware
    {
        public HandleExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        private readonly RequestDelegate _requestDelegate;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string? message;
            HttpStatusCode code;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = JsonConvert.SerializeObject(validationException.Errors);
                    break;

                case RecordNotFoundException recordNotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = recordNotFoundException.Message;
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    message = JsonConvert.SerializeObject(new { Errors = exception.Message });
                    break;
            }

            var result = new BaseServiceResponse(false, message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
