using System;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseTicket
    {
        //todo сделать метод мапящий в response
        public MerchandiseTicket(int id, int employeeId, int itemId)
        {
            Id = id;
            EmployeeId = employeeId;
            ItemId = itemId;
            Status = TicketStatus.Backlog;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Id задачи на выдачу мерча
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Id сотрудника, которому выдается мерч
        /// </summary>
        public long EmployeeId { get; }
        
        /// <summary>
        /// Id предмета, который выдается в качестве мерча
        /// </summary>
        public int ItemId { get; }

        /// <summary>
        /// Статус задачи на выдачу
        /// </summary>
        public TicketStatus Status { get; }
        
        /// <summary>
        /// Дата создания задачи в UTC
        /// </summary>
        public DateTime CreatedAt { get; }
        
        /// <summary>
        /// Дата обновления задачи в UTC
        /// </summary>
        public DateTime? UpdatedAt { get; }
    }
}