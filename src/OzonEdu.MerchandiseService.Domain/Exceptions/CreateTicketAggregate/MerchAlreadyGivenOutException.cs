using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.CreateTicketAggregate
{
    public class MerchAlreadyGivenOutException : Exception
    {
        public MerchAlreadyGivenOutException(string message) : base(message)
        {
        }

        public MerchAlreadyGivenOutException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}