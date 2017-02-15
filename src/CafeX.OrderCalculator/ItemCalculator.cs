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
        }

        public decimal Calculate(string[] order)
        {
            return 0;
        }
    }
}
