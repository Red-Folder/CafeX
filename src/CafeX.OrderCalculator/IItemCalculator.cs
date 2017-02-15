namespace CafeX.OrderCalculator
{
    public interface IItemCalculator
    {
        decimal Calculate(string[] order);
    }
}