using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX.OrderCalculator
{
    public class OrderCalculator
    {
        private IItemCalculator _net;

        public OrderCalculator()
        {
            _net = new ItemCalculator(GetMenu());
        }

        public OrderCalculator(IItemCalculator net)
        {
            _net = net;
        }

        private IList<Item> GetMenu()
        {
            var menu = new List<Item>();

            menu.Add(new Item { Name ="Cola", Price = (decimal)0.5, Category = ItemCategory.Drink, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Coffee", Price = (decimal)1, Category = ItemCategory.Drink, Temperature = ItemTemperature.Hot} );
            menu.Add(new Item { Name ="Cheese Sandwich", Price = (decimal)2, Category = ItemCategory.Food, Temperature = ItemTemperature.Cold} );
            menu.Add(new Item { Name ="Steak Sandwich", Price = (decimal)4.5, Category = ItemCategory.Food, Temperature = ItemTemperature.Hot} );

            return menu;
        }

        public decimal Calculate(string[] order)
        {
            throw new NotImplementedException();
        }
    }
}
