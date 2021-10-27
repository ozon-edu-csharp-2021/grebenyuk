using Microsoft.Extensions.DependencyInjection;

namespace OzonEdu.MerchandiseService.Infrastructure.Filters.Extensions.DependencyInjection
{
    public static class GlobalExceptionFilterExtensions
    {
        public static IServiceCollection AddGlobalExceptionFilter(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            
            return services;
        }
    }
}