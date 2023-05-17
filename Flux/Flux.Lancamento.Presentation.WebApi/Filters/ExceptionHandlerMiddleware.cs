using System.Net;

namespace Flux.Lancamento.Presentation.WebApi.Filters
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
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
                var stackTrace = ex.StackTrace;
                var message = ex.Message;

                //_logger.LogError($"{httpContext.Request.Path} -> {message}");

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    errors = message,
                    excepetions = stackTrace,
                });
            }
        }
    }
}
