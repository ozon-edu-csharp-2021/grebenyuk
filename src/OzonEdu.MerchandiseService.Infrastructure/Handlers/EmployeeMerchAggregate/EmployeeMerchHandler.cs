using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.EmployeeMerchAggregate
{
    public class EmployeeMerchHandler : IRequestHandler<GetEmployeeMerch, EmployeeMerch>
    {
        public async Task<EmployeeMerch> Handle(GetEmployeeMerch request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}