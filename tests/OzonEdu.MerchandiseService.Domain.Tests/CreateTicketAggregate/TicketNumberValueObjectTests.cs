using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.CreateTicketAggregate
{
    public class TicketNumberValueObjectTests
    {
        [Fact]
        public void CreateInstance_ValidParameters_Success()
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