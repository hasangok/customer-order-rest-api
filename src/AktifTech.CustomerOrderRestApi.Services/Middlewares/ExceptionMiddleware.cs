using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Task = System.Threading.Tasks.Task;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ApiResult()
            {
                Success = false,
                Message = $"Internal server error: {exception?.Message}",
                Code = context.Response.StatusCode,
                Errors = new List<ApiError>() {
                    new ApiError() {
                        Message = exception.Message,
                        InternalMessage = exception?.InnerException?.Message
                    }
                }
            }.ToString());
        }
    }
}