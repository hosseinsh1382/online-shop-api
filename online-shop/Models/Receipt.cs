namespace online_shop.Models;

public class Receipt
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int BuyerId { get; set; }
    public ICollection<ReceiptCartItem> ReceiptCartItems { get; set; }
}