using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        private const string Separator = "\n\t";

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request {context.TraceIdentifier} route:{Separator}{GetPath(context.Request)}");
            _logger.LogInformation($"Request {context.TraceIdentifier} headers:{Separator}{GetHeaders(context.Request.Headers)}");

            await _next(context);
            
            _logger.LogInformation($"Response {context.TraceIdentifier} headers:{Separator}{GetHeaders(context.Response.Headers)}");
        }
        
        private static string GetPath(HttpRequest request)
        {
            return $"'{request.Path.ToString()}' {request.Method} {request.Protocol}";
        }
        
        private static string GetHeaders(IHeaderDictionary headers)
        {
            return headers.ContentLength < 0 
                ? "empty headers" 
                : string.Join(Separator, headers.Select(pair => $"{pair.Key}-{pair.Value.ToString()}"));
        }
    }
}