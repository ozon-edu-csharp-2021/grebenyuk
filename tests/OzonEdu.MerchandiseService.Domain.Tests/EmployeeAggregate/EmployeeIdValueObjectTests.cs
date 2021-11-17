using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class EmployeeIdValueObjectTests
    {
        [Fact]
        public void CreateInstance_ValidParameters_Success()
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