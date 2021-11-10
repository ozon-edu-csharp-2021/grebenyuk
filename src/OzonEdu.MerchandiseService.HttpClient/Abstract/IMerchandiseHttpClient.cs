using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient.Abstract
{
    public interface IMerchandiseHttpClient
    {
        Task<EmployeeMerchResponse> GetByIdAsync(long id, CancellationToken token);
        Task<EmployeeMerchResponse> AddAsync(MerchandiseTicketPostRequest ticket, CancellationToken token);
    }
}