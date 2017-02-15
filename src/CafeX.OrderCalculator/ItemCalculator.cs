using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX.OrderCalculator
{
    public class ItemCalculator : IItemCalculator
    {
        private IList<Item> _menu;

        public ItemCalculator(IList<Item> menu)
        {
            _menu = menu;
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
