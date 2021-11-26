using MediatR;
using Microsoft.Extensions.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.Repositories;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Abstract;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTicketCommand).Assembly);
            
            return services;
        }
        
        public static IServiceCollection AddDatabaseComponents(this IServiceCollection services)
        {
            services.ConfigureOptions<DatabaseConnectionOptions>();
            //services.Configure<DatabaseConnectionOptions>(configuration.GetSection(nameof(DatabaseConnectionOptions)));
            services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddScoped<ITicketRepository, TicketRepository>();
            
            return services;
        }
    }
}