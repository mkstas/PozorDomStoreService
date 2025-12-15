using PozorDomStoreService.Infrastructure.Exceptions;
using System.Net;

namespace PozorDomStoreService.Api.Middlewares
{
    public class GlobalExceptionHandler(RequestDelegate next)
    {
        private class ErrorResponse(int statusCode, string message)
        {
            public int StatusCode { get; set; } = statusCode;
            public string Message { get; set; } = message;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in GlobalExceptionHandler: {ex}");
                var response = new ErrorResponse(
                    (int)HttpStatusCode.InternalServerError, ex.Message);

                context.Response.StatusCode = ex switch
                {
                    NotFoundException _ => (int)HttpStatusCode.NotFound,
                    UnauthorizedAccessException _ => (int)HttpStatusCode.Unauthorized,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                response.StatusCode = context.Response.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
