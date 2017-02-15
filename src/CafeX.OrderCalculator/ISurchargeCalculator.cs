namespace CafeX.OrderCalculator
{
    public interface ISurchargeCalculator
    {
        decimal Calculate(decimal net, string[] order);
    }
}