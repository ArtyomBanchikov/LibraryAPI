using System.Text.Json;

namespace Library.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var message = JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = ex.Message
                });

                await context.Response.WriteAsync(message);
            }
        }
    }
}
