using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient.Abstract
{
    public interface IMerchandiseHttpClient
    {
        Task<EmployeeMerchResponse> GetAllMerchByEmployeeIdAsync(long employeeId, CancellationToken token);
        Task<long> AddAsync(MerchandiseTicketPostRequest ticket, CancellationToken token);
    }
}