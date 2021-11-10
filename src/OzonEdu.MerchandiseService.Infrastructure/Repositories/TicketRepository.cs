using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<Ticket> CreateAsync(Ticket itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Ticket> UpdateAsync(Ticket itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketsByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}