using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX.OrderCalculator
{
    public class OrderCalculator
    {
        private IList<Item> _menu = new List<Item>();

        public OrderCalculator()
        {
            _menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            _menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            _menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            _menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );
        }

        public decimal Calculate(string[] order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            decimal result = 0;

            foreach (var item in order)
            {
                if (_menu.Any(x => x.Name == item))
                {
                    result += _menu.Where(x => x.Name == item).Single().Price;
                }
            }

            return result;
        }
    }
}
