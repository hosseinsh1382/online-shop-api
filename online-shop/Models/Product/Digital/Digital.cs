namespace online_shop.Models.Product.Digital;

public abstract class Digital : Product
{
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
}