using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.MerchandiseService.Infrastructure.Filters.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Infrastructure.StartupFilters;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions.DependencyInjection
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, CustomMiddlewaresStartupFilter>()
                    .AddSingleton<IStartupFilter, SwaggerStartupFilter>()
                    .AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = Assembly.GetExecutingAssembly().GetName().Name ?? "no name",
                            Version = "v1"
                        });

                        options.CustomSchemaIds(t => t.FullName);

                        var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                        options.IncludeXmlComments(xmlFilePath);
                    })
                    .AddGlobalExceptionFilter();
            });

            return builder;
        }
    }
}