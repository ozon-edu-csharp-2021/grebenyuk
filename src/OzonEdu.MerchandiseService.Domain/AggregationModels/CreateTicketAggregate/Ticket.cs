using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions.CreateTicketAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate
{
    public class Ticket : Entity
    {
        /// <summary>
        /// Номер заявки на выдачу мерча
        /// </summary>
        public TicketNumber TicketNumber { get; }
        
        /// <summary>
        /// Сотрудник, которому выдается мерч
        /// </summary>
        public Employee Employee { get; }
        
        /// <summary>
        /// Товарная позиция, которая выдается в качестве мерча
        /// </summary>
        public Sku Sku { get; private set; }

        /// <summary>
        /// Статус задачи на выдачу
        /// </summary>
        public TicketStatus TicketStatus { get; private set; }
        
        /// <summary>
        /// Дата создания задачи в UTC
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        
        /// <summary>
        /// Дата обновления задачи в UTC
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        public Ticket(Employee employee)
        {
            Employee = employee;
            CreateNewTicket();
        }

        private void CreateNewTicket()
        {
            // todo как определять какой сейчас TicketNumber?
            TicketStatus = TicketStatus.Backlog;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        
        /// <summary>
        /// Берем заявку на мерч в работу
        /// </summary>
        public void StartWork(Sku sku)
        {
            if (!Equals(TicketStatus, TicketStatus.Backlog))
            {
                throw new InvalidTicketStatusException($"{nameof(TicketStatus)} should be in \"{nameof(TicketStatus.Backlog)}\" status.");
            }

            Sku = sku;
            TicketStatus = TicketStatus.InWork;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Завершить работу по заявке
        /// </summary>
        public void CompleteWork()
        {
            if (!Equals(TicketStatus, TicketStatus.InWork))
            {
                throw new InvalidTicketStatusException($"{nameof(TicketStatus)} should be in \"{nameof(TicketStatus.InWork)}\" status.");
            }

            TicketStatus = TicketStatus.Done;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}