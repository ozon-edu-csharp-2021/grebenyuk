using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient.Abstract
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchandiseTicketResponse> GetByIdAsync(long id, CancellationToken token);
        Task<MerchandiseTicketResponse> AddAsync(MerchandiseTicketPostRequest ticket, CancellationToken token);
    }
}