namespace online_shop.Models.Account;

public class Buyer:Account
{
    public Double Credit { get; set; }
    
    public ICollection<Comment> PostedComments { get; set; }

    public List<CartItem> Cart { get; set; }

    public ICollection<Receipt> Receipts { get; set; }
}