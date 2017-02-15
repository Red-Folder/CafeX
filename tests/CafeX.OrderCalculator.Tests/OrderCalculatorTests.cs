using System;
using Moq;
using Xunit;

namespace CafeX.OrderCalculator.Tests
{
    public class OrderCalculatorTests
    {
        [Fact]
        public void Returns_Correct_Value()
        {
            Mock<IItemCalculator> netMoq = new Mock<IItemCalculator>();
            netMoq.Setup(m => m.Calculate(It.IsAny<string[]>())).Returns((decimal)123.45);

            Mock<ISurchargeCalculator> surchargeMoq = new Mock<ISurchargeCalculator>();
            surchargeMoq.Setup(m => m.Calculate(It.IsAny<decimal>(), It.IsAny<string[]>())).Returns((decimal)10);

            var sut = new OrderCalculator(netMoq.Object, surchargeMoq.Object);

            var result = sut.Calculate(new string[] { "Test", "Test" });

            Assert.Equal((decimal)133.45, result);
        }
    }
}
