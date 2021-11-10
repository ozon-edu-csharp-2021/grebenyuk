using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.CreateTicketAggregate
{
    public class InvalidTicketStatusException : Exception
    {
        public InvalidTicketStatusException(string message) : base(message)
        {
        }

        public InvalidTicketStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}