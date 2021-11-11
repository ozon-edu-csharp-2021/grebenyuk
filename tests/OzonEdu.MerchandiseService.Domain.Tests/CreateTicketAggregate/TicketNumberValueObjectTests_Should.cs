using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeAggregate
{
    public class TicketNumberValueObjectTests_Should
    {
        [Fact]
        public void Ok_OnCreateTicketNumberInstance()
        {
            //Arrange
            var expectedTicketNumber = 10;

            //Act
            var actualTicketNumber = new TicketNumber(expectedTicketNumber);

            //Assert
            Assert.Equal(expectedTicketNumber, actualTicketNumber.Value);
        }
    }
}