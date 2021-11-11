using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class EmployeeIdValueObjectTests_Should
    {
        [Fact]
        public void Ok_OnCreateEmployeeIdInstance()
        {
            //Arrange
            var expectedEmployeeId = 10;

            //Act
            var actualEmployeeId = new EmployeeId(expectedEmployeeId);

            //Assert
            Assert.Equal(expectedEmployeeId, actualEmployeeId.Value);
        }
    }
}