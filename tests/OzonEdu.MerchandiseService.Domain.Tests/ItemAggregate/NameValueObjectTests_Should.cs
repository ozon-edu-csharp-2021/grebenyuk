using OzonEdu.MerchandiseService.Domain.AggregationModels.ItemAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ItemAggregate
{
    public class NameValueObjectTests_Should
    {
        [Fact]
        public void Ok_OnCreateNameInstance()
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