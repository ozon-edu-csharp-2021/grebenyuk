using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.CreateTicketAggregate
{
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, int>
    {
        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}