using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    public class Ticket
    {
        public ulong Id { get; set;  }
        public long EmployeeId { get; set; }
        public long Sku { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}