using System;
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
            SetEmail(email);
        }

        private void SetEmail(Email email)
        {
            if (email is null) throw new ArgumentNullException($"{nameof(email)} is null.");
            
            if (!IsValidEmail(email.Value)) throw new InvalidEmailException($"Email is invalid: {email.Value}.");
            
            Email = email;
        }
        
        private static bool IsValidEmail(string email)
            => Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}