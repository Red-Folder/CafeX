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

        [Fact]
        public void Order_Value_Is_Correct() 
        {
            var sut = new OrderCalculator();

            var result = sut.Calculate(new string[] { "Cola", "Coffee", "Cheese Sandwich" });

            Assert.Equal((decimal)3.5, result);
        }
    }
}
