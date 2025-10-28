using Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace e_commerceAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}", ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                ValidationException => HttpStatusCode.BadRequest,          
                NotFoundException => HttpStatusCode.NotFound,              
                ConflictException => HttpStatusCode.Conflict,              
                UnauthorizedException => HttpStatusCode.Unauthorized,      
                BusinessRuleException => HttpStatusCode.UnprocessableEntity, 
                _ => HttpStatusCode.InternalServerError                   
            };

            var problemDetails = new
            {
                status = (int)statusCode,
                title = ex.GetType().Name,
                message = ex.Message,
                traceId = context.TraceIdentifier
            };

            context.Response.StatusCode = (int)statusCode;

            var json = JsonSerializer.Serialize(problemDetails, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}
