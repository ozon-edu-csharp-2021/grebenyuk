using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Commands;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.CreateTicketAggregate
{
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, long>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        
        public async Task<long> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // todo реализовать запрос к сервису сотрудников, для получения емейла
            // todo и валидации, что request.EmployeeId существует
            var employeeEmail = "mock@gmail.com";
            var employee = new Employee(
                new EmployeeId(request.EmployeeId),
                new Email(employeeEmail)
            );

            // Получаем все тикеты заведенные на этого сотрудника.
            var existTickets = await _ticketRepository.GetAllTicketsByEmployeeIdAsync(employee.EmployeeId, cancellationToken);

            // Проверяем: если такой мерч сотруднику уже выдавался, то кидаем исключение.
            if (existTickets.FirstOrDefault(t => t.Sku.Value == request.Sku) is not null)
            {
                throw new Exception();
            }

            // Если все валидации пройдены, то создаем новый тикет и берем его в работу.
            var newTicket = new Ticket(employee);
            newTicket.StartWork(new Sku(request.Sku));
            
            // Так же фиксируем в БД.
            var createdTicket = await _ticketRepository.CreateAsync(newTicket, cancellationToken);
            await _ticketRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            // todo нужно запросить выдачу мерча у StockApi
            
            return createdTicket.TicketNumber.Value;
        }
    }
}