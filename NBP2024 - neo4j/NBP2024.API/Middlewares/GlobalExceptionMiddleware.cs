using NBP2024.Domain.Exepctions;
using NBP2024.Domain.Models;
using System.Net;
using System.Text.Json;

namespace NBP2024.API.Middlewares
{
    // Implementiranje middleware-a
    public class GlobalExceptionMiddleware
    {
        private RequestDelegate _next;
        private ILogger<GlobalExceptionMiddleware> _logger;
        private IWebHostEnvironment _env;
        public GlobalExceptionMiddleware(RequestDelegate next, 
            ILogger<GlobalExceptionMiddleware> logger, 
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                HandleException(ex, context);
            }
        }

        private void HandleException(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string errorMessage = (_env.IsDevelopment()) ? ex.Message : "Internal server error";

            switch(ex)
            {
                case CourseEnrolmentException e:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                         SerializaError(context,e, errorMessage);
                        break;
                case EntityNullCustomException ee:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                         SerializaError(context,ee, errorMessage);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    SerializaError(context,ex, errorMessage);
                    break;
            }
        }

        private void SerializaError(HttpContext context, Exception e, string errorMessage)
        {
            Result<string> result = new Result<string>
            {
                IsSuccess = false,
                Errors = new List<string> { errorMessage }
            };
            _logger.LogError(e, errorMessage);
            var jsonString = JsonSerializer.Serialize(result);
            context.Response.WriteAsync(jsonString);
        }
    }
    // Extension metoda za registraciju middleware-a
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
