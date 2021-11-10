using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpClient.Abstract;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        private const string BaseRoute = "v1/api/merchandise";

        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<EmployeeMerchResponse> GetByIdAsync(long employeeId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"{BaseRoute}/{employeeId}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<EmployeeMerchResponse>(body);
        }
        
        public async Task<EmployeeMerchResponse> AddAsync(MerchandiseTicketPostRequest request, 
            CancellationToken token)
        {
            using var response = await _httpClient.PostAsync($"{BaseRoute}", new StringContent(string.Empty), token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<EmployeeMerchResponse>(body);
        }
    }
}