using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX.OrderCalculator
{
    public class SurchargeCalculator : ISurchargeCalculator
    {
        private IList<Item> _menu;

        public SurchargeCalculator(IList<Item> menu)
        {
            _menu = menu;
        }

        public decimal Calculate(decimal net, string[] order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            if (_menu.Any(x => x.Category == ItemCategory.Food && order.Contains(x.Name)))
            {
                return Math.Ceiling((net * (decimal)0.1) * 100)/ 100.0M;
            }
            else
            {
                return 0;
            }
        }
    }
}
