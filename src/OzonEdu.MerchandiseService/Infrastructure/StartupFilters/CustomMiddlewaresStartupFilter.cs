using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
    public class CustomMiddlewaresStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<LoggingMiddleware>();
            
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());

                app.Map("/ready", builder => builder.UseMiddleware<HealthCheckMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<HealthCheckMiddleware>());

                next(app);
            };
        }

    }
}