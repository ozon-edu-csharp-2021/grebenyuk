using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate
{
    public class TicketStatus : Enumeration
    {
        public static TicketStatus Backlog = new(1, "Backlog");
        public static TicketStatus InWork = new(2, "InWork");
        public static TicketStatus Done = new(3, "Done");

        public TicketStatus(int id, string name) : base(id, name)
        {
        }
    }
}