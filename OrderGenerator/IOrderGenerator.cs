using OrderDeliveryLibrary;

namespace OrderGenerator;

public interface IOrderGenerator
{
    public IEnumerable<Order> Generate(int amount, List<string> districts, DateTime LeftBorder, DateTime RightBorder);
}
