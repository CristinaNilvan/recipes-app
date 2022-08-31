namespace RecipesApp.Presentation.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Entering request logging middleware...");

            await _next(httpContext);

            _logger.LogInformation(
                "Request : {method} {url} => {statusCode}",
                httpContext.Request?.Method,
                httpContext.Request?.Path.Value,
                httpContext.Response?.StatusCode);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
