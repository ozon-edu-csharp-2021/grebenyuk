using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class HealthCheckMiddleware
    {
        public HealthCheckMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("200 Ok");
        }
    }
}