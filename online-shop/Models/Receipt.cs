namespace online_shop.Models;

public class Receipt
{
    public int Id { get; set; }
    public ICollection<CartItem> Products { get; set; }
    public DateTime Date { get; set; }
    private double _totalPrice;

    public double TotalPrice
    {
        get { return _totalPrice; }
        set
        {
            foreach (var product in Products)
            {
                _totalPrice += product.Product.Price * product.Count;
            }
        }
    }
}