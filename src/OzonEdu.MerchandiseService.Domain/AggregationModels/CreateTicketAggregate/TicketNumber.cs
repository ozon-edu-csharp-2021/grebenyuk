using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate
{
    public class TicketNumber : ValueObject
    {
        public ulong Value { get; }

        public TicketNumber(ulong value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}