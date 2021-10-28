using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services.Abstract
{
    public interface IMerchandiseTicketsService
    {
        Task<MerchandiseTicket> GetByIdAsync(long id, CancellationToken token);
        Task<MerchandiseTicket> AddAsync(MerchandiseTicketCreationModel ticket, CancellationToken token);
    }
}