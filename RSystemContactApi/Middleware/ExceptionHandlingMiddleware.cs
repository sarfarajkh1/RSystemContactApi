using Microsoft.AspNetCore.Mvc;
using RSystem.Contact.Model;

namespace RSystemContactApi.Middleware
{
    public class ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception, "Exception occurred: {Message}", exception.Message);

                var response = new GenericExceptionResponse
                {
                    ErrorCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = exception.Message
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
