namespace online_shop.Models.Product.Vehicle;

public class Bicycle : Vehicle
{
    public int BicycleTypeId { get; set; }
    public BicycleType BicycleType { get; set; }
    public int Size { get; set; }
}