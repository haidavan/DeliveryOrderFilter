using System.ComponentModel.DataAnnotations;
namespace DeliveryOrderFilter;

public class Order
{
    [Required]
    public uint Id { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    [MaxLength(50)]
    public string CityDistrict {  get; set; }
    [Required]
    public DateTime DeliveryDateTime { get; set; }

    public Order(uint id,double weight,string cityDistrict,DateTime deliveryDateTime) {
        Id = id;
        Weight = weight;
        CityDistrict = cityDistrict;
        DeliveryDateTime = deliveryDateTime;
    }
}
