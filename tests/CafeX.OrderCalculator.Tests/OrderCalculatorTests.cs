using System;
using Moq;
using Xunit;

namespace CafeX.OrderCalculator.Tests
{
    public class OrderCalculatorTests
    {
        [Fact]
        public void Returns_Value_From_ItemCalc()
        {
            Mock<IItemCalculator> moq = new Mock<IItemCalculator>();
            moq.Setup(m => m.Calculate(It.IsAny<string[]>())).Returns((decimal)123.45);

            var sut = new OrderCalculator(moq.Object);

            var result = sut.Calculate(new string[] { "Test", "Test" });

            Assert.Equal((decimal)123.45, result);
        }
    }
}
