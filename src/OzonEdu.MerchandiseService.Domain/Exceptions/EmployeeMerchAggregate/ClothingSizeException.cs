using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeMerchAggregate
{
    public class ClothingSizeException : Exception
    {
        public ClothingSizeException(string message) : base(message)
        {
        }

        public ClothingSizeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}