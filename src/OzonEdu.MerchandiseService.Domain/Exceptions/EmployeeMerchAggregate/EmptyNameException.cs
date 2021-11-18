using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeMerchAggregate
{
    public class EmptyNameException : Exception
    {
        public EmptyNameException(string message) : base(message)
        {
        }

        public EmptyNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}