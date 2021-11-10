using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate
{
    public class GetEmployeeMerch : IRequest<EmployeeMerch>
    {
        /// <summary>
        /// Id сотрудника
        /// </summary>
        public long EmployeeId { get; set; }
    }
}