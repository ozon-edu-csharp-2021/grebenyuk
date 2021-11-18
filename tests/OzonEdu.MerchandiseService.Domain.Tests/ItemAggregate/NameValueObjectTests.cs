using OzonEdu.MerchandiseService.Domain.AggregationModels.ItemAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ItemAggregate
{
    public class NameValueObjectTests
    {
        [Fact]
        public void CreateInstance_ValidParameters_Success()
        {
            //Arrange
            var expectedName = "Кроссовки";

            //Act
            var actualName = new Name(expectedName);

            //Assert
            Assert.Equal(expectedName, actualName.Value);
        }
    }
}