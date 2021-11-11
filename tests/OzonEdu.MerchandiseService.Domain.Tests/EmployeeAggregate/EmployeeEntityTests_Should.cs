using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class EmployeeEntityTests_Should
    {
        [Fact]
        public void Ok_OnCreateEmployeeInstance()
        {
            //Arrange
            var expectedEmployeeId = 10;
            var expectedEmail = "test@gmail.com";

            //Act
            var actualEmployee = new Employee(
                new EmployeeId(expectedEmployeeId),
                new Email(expectedEmail));

            //Assert
            Assert.Equal(expectedEmployeeId, actualEmployee.EmployeeId.Value);
            Assert.Equal(expectedEmail, actualEmployee.Email.Value);
        }
        
        [Theory]
        [InlineData("wrong_email")]
        [InlineData(null)]
        public void NotOk_OnCreateEmployeeInstanceWithInvalidEmail(string email)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<InvalidEmailException>(() =>
                new Employee(
                    new EmployeeId(10),
                    new Email(email))
            );
        }
    }
}