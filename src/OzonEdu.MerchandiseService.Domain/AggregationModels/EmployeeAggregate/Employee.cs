using System.Text.RegularExpressions;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public EmployeeId EmployeeId { get; }
        public Email Email { get; private set; }

        public Employee(
            EmployeeId employeeId,
            Email email)
        {
            EmployeeId = employeeId;
            InternalSetEmail(email);
        }
        
        public Employee(EmployeeId employeeId)
        {
            EmployeeId = employeeId;
        }

        public void SetEmail(Email email)
        {
            InternalSetEmail(email);
        }
        
        private void InternalSetEmail(Email email)
        {
            if (email is null
                || string.IsNullOrEmpty(email.Value))
            {
                throw new InvalidEmailException($"{nameof(email)} is null.");
            }

            if (!IsValidEmail(email.Value))
            {
                throw new InvalidEmailException($"Email is invalid: {email.Value}.");
            }
            
            Email = email;
        }
        
        private static bool IsValidEmail(string email)
            => Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}