using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseService : OzonEdu.MerchandiseService.Grpc.MerchandiseService.MerchandiseServiceBase
    {
        private readonly IMediator _mediator;

        public MerchandiseService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<GetAllMerchByEmployeeIdResponse> GetAllMerchByEmployeeId(
            GetAllMerchByEmployeeIdRequest request, 
            ServerCallContext context)
        {
            var query = new GetEmployeeMerchQuery
            {
                EmployeeId = request.EmployeeId
            };
            
            var result = await _mediator.Send(query, context.CancellationToken);

            if (result is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "This employee has never received any merch."));
            }

            return new GetAllMerchByEmployeeIdResponse
            {
                Items =
                {
                    // todo ок или не ок?
                    result.Items.Select(i => new GetAllMerchByEmployeeIdResponse.Types.Item
                    {
                        Sku = i.Sku.Value,
                        Name = i.Name.Value,
                        ClothingSizeId = i.ClothingSize.Id,
                        ItemTypeId = i.ItemType.Id
                    })
                }
            };
        }
        
        public override async Task<AddTicketResponse> AddTicket(AddTicketRequest request, ServerCallContext context)
        {
            var command = new CreateTicketCommand
            {
                EmployeeId = request.EmployeeId,
                Sku = request.Sku
            };

            var createdTicketId = await _mediator.Send(command, context.CancellationToken);

            return new AddTicketResponse
            {
                TicketId = createdTicketId
            };
        }
    }
}