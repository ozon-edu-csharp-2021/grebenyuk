using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeMerchAggregate
{
    public class EmployeeMerch : Entity
    {
        public IReadOnlyCollection<Item> Items { get; }
        
        public EmployeeMerch(IReadOnlyCollection<Item> items)
        {
            Items = items;
        }
    }
}