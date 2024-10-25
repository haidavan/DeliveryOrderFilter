using NLog;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DeliveryOrderFilter;

public class OrderManager
{
    private static OrderManager _instance;
    private  Logger _logger;
    private  List<Order> _orders;
    
    private OrderManager() {
        _logger = NLog.LogManager.GetCurrentClassLogger();
        _orders = new List<Order>();
        using(var FileReader=new StreamReader("Orders.txt"))
        {
            _logger.Info("Reading Orders");
            var s=FileReader.ReadToEnd();
            foreach(Order order in JsonSerializer.Deserialize<List<Order>>(s))
            {
                var context=new ValidationContext(order);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(order, context, results, true))
                    _orders.Add(order);
                else
                    _logger.Error($"order {order.Id} could not be validated");
            }
        }
    }
    public void FilterOrders(string CityDistrict,DateTime FirstDeliveryDateTime)
    {
        _logger.Info($"Filtering Orders in {CityDistrict} less than 30 min after {FirstDeliveryDateTime}");
        List<Order> resultOrders=new List<Order>();
        foreach(var order in _orders)
        {
            if(order.CityDistrict == CityDistrict && order.DeliveryDateTime.Date==FirstDeliveryDateTime.Date &&
                order.DeliveryDateTime.TimeOfDay-FirstDeliveryDateTime.TimeOfDay<=new TimeSpan(0,30,0))
                resultOrders.Add(order);
        }
        using(var FileWriter=new StreamWriter("results.txt"))
        {
            FileWriter.Write(JsonSerializer.Serialize(resultOrders));
        }
    }
    public static OrderManager GetInstance()
    {
        if(_instance == null) 
            _instance = new OrderManager();
        return _instance;
    }

}
