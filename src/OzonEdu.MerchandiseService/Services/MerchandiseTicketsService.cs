using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Abstract;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseTicketsService : IMerchandiseTicketsService
    {
        public MerchandiseTicketsService()
        {
        }

        public async Task<MerchandiseTicket> GetByIdAsync(long id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchandiseTicket> AddAsync(MerchandiseTicketCreationModel ticket, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}