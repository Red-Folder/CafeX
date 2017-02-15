namespace CafeX.OrderCalculator
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ItemCategory Category { get; set; }
        public ItemTemperature Temperature { get; set; }
    }

    public enum ItemCategory
    {
        Drink,
        Food
    }

    public enum ItemTemperature
    {
        Hot,
        Cold
    }
}