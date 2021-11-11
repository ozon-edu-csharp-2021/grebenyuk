using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.SkuAggregate
{
    public class SkuValueObjectTests_Should
    {
        [Fact]
        public void Ok_CreateSkuInstance()
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