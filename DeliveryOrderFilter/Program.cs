using NLog;
using NLog.Config;
namespace DeliveryOrderFilter;

internal class Program
{
    static void Main(string[] args)
    {
        LogManager.Configuration=new XmlLoggingConfiguration("NLog.config");
        Console.WriteLine("Введите район города");
        string cityDistrict=Console.ReadLine();
        Console.WriteLine("Введите время доставки первого заказа в формате \"ДД/ММ/ГГ ЧЧ:ММ:СС\"");
        string FirstDeliveryDateTime=Console.ReadLine();
        OrderManager.GetInstance().FilterOrders(cityDistrict, DateTime.Parse(FirstDeliveryDateTime));
    }
}

