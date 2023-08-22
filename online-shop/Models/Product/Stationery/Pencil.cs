namespace online_shop.Models.Product.Stationery;

public class Pencil : Stationery
{
    public int ColorId { get; set; }
    public PenColor Color { get; set; }
    public int PencileTypeId { get; set; }
    public PencilType PencilType { get; set; }
}