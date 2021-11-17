using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.SkuAggregate
{
    public class SkuValueObjectTests
    {
        [Fact]
        public void CreateInstance_ValidParameters_Success()
        {
            //Arrange
            var expectedSku = 10;

            //Act
            var actualSku = new Sku(expectedSku);

            //Assert
            Assert.Equal(expectedSku, actualSku.Value);
        }
    }
}