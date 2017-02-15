using System;
using Xunit;

namespace CafeX.OrderCalculator.Tests
{
    public class OrderCalculatorTests
    {
        [Fact]
        public void Exception_On_Calculate_With_Null()
        {
            var sut = new OrderCalculator();

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => sut.Calculate(null));

            Assert.Equal("order", ex.ParamName);
        }
    }
}
