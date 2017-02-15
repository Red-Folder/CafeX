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

        [Theory]
        [InlineData(new string[] { }, 0)]
        [InlineData(new string[] { "Cola" }, 0.5)]
        [InlineData(new string[] { "Coffee" }, 1)]
        [InlineData(new string[] { "Cheese Sandwich" }, 2)]
        [InlineData(new string[] { "Steak Sandwich" }, 4.5)]
        [InlineData(new string[] { "Cola", "Coffee" }, 1.5)]
        [InlineData(new string[] { "Cola", "Coffee", "Cheese Sandwich" }, 3.5)]
        public void Order_Value_Is_Correct(string[] order, decimal expectedValue) 
        {
            var sut = new OrderCalculator();

            var result = sut.Calculate(order);

            Assert.Equal(expectedValue, result);
        }
    }
}
