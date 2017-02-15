using System;
using System.Collections.Generic;
using Xunit;

namespace CafeX.OrderCalculator.Tests
{
    public class SurchargeCalculatorTests
    {
        [Fact]
        public void Exception_On_Calculate_With_Null()
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => sut.Calculate(0, null));

            Assert.Equal("order", ex.ParamName);
        }

        [Theory]
        [InlineData(new string[] { }, 0)]
        [InlineData(new string[] { "Cola" }, 0)]
        [InlineData(new string[] { "Coffee" }, 0)]
        public void Order_Zero_If_Drinks(string[] order, decimal expectedValue) 
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            var result = sut.Calculate(0, order);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(new string[] { "Cheese Sandwich" }, 1)]
        public void Order_Cold_Food(string[] order, decimal expectedValue) 
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            var result = sut.Calculate(10, order);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(new string[] { "Cheese Sandwich" }, 1.01)]
        public void Order_Cold_Food_With_Roundup(string[] order, decimal expectedValue) 
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            var result = sut.Calculate((decimal)10.01, order);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(new string[] { "Steak Sandwich" }, 2)]
        public void Order_Hot_Food(string[] order, decimal expectedValue) 
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            var result = sut.Calculate((decimal)10, order);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(new string[] { "Steak Sandwich" }, 20)]
        public void Order_Hot_Food_Over_Ceiling(string[] order, decimal expectedValue) 
        {
            var menu = new List<Item>();
            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            var sut = new SurchargeCalculator(menu);

            var result = sut.Calculate((decimal)200, order);

            Assert.Equal(expectedValue, result);
        }
    }
}
