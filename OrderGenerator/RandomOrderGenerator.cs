using OrderDeliveryLibrary;

namespace OrderGenerator;

public class RandomOrderGenerator: IOrderGenerator
{
    public IEnumerable<Order> Generate(int amount, List<string> districts, DateTime LeftBorder, DateTime RightBorder)
    {
        List<Order> orders = new List<Order>();
        var rand=new Random();
        var DateTimeRange = LeftBorder - RightBorder;
        for (uint i = 0;i<amount;i++)
        {
            var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * DateTimeRange.Ticks));
            orders.Add(new Order(i, rand.NextDouble() * 10, districts[rand.Next(districts.Count())], LeftBorder + randTimeSpan));
        }
        return orders;
    }
}
