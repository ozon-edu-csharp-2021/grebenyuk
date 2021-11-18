using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Infrastructure.Repositories;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTicketCommand).Assembly);
            
            return services;
        }
        
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ITicketRepository, TicketRepository>();
            
            return services;
        }
    }
}