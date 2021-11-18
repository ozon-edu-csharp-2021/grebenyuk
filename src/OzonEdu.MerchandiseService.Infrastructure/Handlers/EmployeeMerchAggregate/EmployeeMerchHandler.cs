using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.EmployeeMerchAggregate
{
    public class EmployeeMerchHandler : IRequestHandler<GetEmployeeMerchQuery, EmployeeMerch>
    {
        private readonly ITicketRepository _ticketRepository;

        public EmployeeMerchHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        
        public async Task<EmployeeMerch> Handle(GetEmployeeMerchQuery request, CancellationToken cancellationToken)
        {
            // todo реализовать запрос к сервису сотрудников, для получения емейла
            // todo и валидации, что request.EmployeeId существует
            var employeeEmail = "mock@gmail.com";
            var employee = new Employee(
                new EmployeeId(request.EmployeeId),
                new Email(employeeEmail)
            );

            var existTickets = (await _ticketRepository.GetAllTicketsByEmployeeIdAsync(employee.EmployeeId, cancellationToken)).ToList();

            // Если тикетов по юзеру нет, то возвращаем пустоту т.к мерч ему ни разу не выдавался.
            if (!existTickets.Any())
            {
                return null;
            }
            
            // todo из тикетов взять Sku и по этим Sku спросить у StockApi наименование предметов?
            // todo или у какого-то другого сервиса?
            var allEmployeeMerch = new EmployeeMerch(
                existTickets.Select(t => new Item(t.Sku, null, null, null)).ToList().AsReadOnly()
            );
            
            return allEmployeeMerch;
        }
    }
}