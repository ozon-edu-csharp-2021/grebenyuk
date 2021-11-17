using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class EmailValueObjectTests
    {
        [Fact]
        public void CreateInstance_ValidParameters_Success()
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