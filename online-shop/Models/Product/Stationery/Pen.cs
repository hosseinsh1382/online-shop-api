namespace online_shop.Models.Product.Stationery;

public class Pen:Stationery
{
    public int ColorId { get; set; }
    public PenColor Color { get; set; }
}