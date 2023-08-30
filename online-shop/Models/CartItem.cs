namespace online_shop.Models;

public class CartItem
{
    public int Id { get; set; }
    public int Count { get; set; }

    public int ProductId { get; set; }
    public Product.Product? Product { get; set; }

    public int BuyerId { get; set; }
}