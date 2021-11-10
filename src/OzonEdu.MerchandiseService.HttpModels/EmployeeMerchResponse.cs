using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class EmployeeMerchResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}