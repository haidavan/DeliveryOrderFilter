using OrderDeliveryLibrary;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace OrderGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> districts = new List<string>();
        using (var reader = new StreamReader("Districts.txt"))
        {
            string s = reader.ReadLine();
            while (s is not null)
            {
                districts.Add(s);
                s = reader.ReadLine();
            }
        }
        List<Order> orders = new RandomOrderGenerator().Generate(15000, districts, DateTime.Parse("25/10/2024 09:35:00"),
            DateTime.Parse("25/10/2024 15:30:00")).ToList();
        using (var writer = new StreamWriter("Orders.txt"))
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            writer.Write(JsonSerializer.Serialize(orders,options));
        }
    }
}
