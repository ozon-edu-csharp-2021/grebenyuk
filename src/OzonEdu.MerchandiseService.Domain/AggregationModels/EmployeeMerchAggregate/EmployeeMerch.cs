using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeMerchAggregate
{
    public class EmployeeMerch : Entity
    {
        public IEnumerable<Item> Items { get; private set; }
        
        public EmployeeMerch(IEnumerable<Item> items)
        {
            
        }
    }
}