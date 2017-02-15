using System;

namespace CafeX.OrderCalculator
{
    public class OrderCalculator
    {
        public decimal Calculate(string[] order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            return 0;
        }
    }
}
