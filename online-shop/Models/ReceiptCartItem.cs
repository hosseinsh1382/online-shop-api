namespace online_shop.Models;

public class ReceiptCartItem
{
    public int Id { get; set; }
    public int ReceiptId { get; set; }
    public int ProductId { get; set; }
    public Product.Product? Product { get; set; }
}