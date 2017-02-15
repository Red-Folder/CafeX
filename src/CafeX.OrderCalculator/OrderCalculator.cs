using System;
using System.Collections.Generic;

namespace CafeX.OrderCalculator
{
    public class OrderCalculator
    {
        private Dictionary<string, decimal> _menu = new Dictionary<string, decimal>();

        public OrderCalculator()
        {
            _menu.Add("Cola", (decimal).5);
            _menu.Add("Coffee", (decimal)1);
            _menu.Add("Cheese Sandwich", (decimal)2);
            _menu.Add("Steak Sandwich", (decimal)4.5);
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
                if (_menu.ContainsKey(item))
                {
                    result += _menu[item];
                }
            }

            return result;
        }
    }
}
