using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Abstract;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseService : OzonEdu.MerchandiseService.Grpc.MerchandiseService.MerchandiseServiceBase
    {
        private readonly IMerchandiseTicketsService _merchandiseTicketsService;

        public MerchandiseService(IMerchandiseTicketsService merchandiseTicketsService)
        {
            _merchandiseTicketsService = merchandiseTicketsService;
        }
        
        public override async Task<GetTicketByEmployeeIdReply> GetTicketByEmployeeId(
            GetTicketByEmployeeIdRequest request, 
            ServerCallContext context)
        {
            var ticket = await _merchandiseTicketsService.GetByIdAsync(request.EmployeeId, context.CancellationToken);
            
            return new GetTicketByEmployeeIdReply
            {
                Ticket = new Ticket
                {
                    Id = ticket.Id,
                    EmployeeId = ticket.EmployeeId,
                    ItemId = ticket.ItemId
                }
            };
        }
        
        public override async Task<AddTicketReply> AddTicket(AddTicketRequest request, ServerCallContext context)
        {
            var ticket = await _merchandiseTicketsService.AddAsync(
                new MerchandiseTicketCreationModel(request.EmployeeId, request.ItemId), 
                context.CancellationToken);

            return new AddTicketReply
            {
                Ticket = new Ticket
                {
                    Id = ticket.Id,
                    EmployeeId = ticket.EmployeeId,
                    ItemId = ticket.ItemId
                }
            };
        }
    }
}