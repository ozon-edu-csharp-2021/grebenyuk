using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class EmailValueObjectTests_Should
    {
        [Fact]
        public void Ok_OnCreateEmailInstance()
        {
            //Arrange
            var expectedEmail = "test@gmail.com";

            //Act
            var actualEmail = new Email(expectedEmail);

            //Assert
            Assert.Equal(expectedEmail, actualEmail.Value);
        }
    }
}