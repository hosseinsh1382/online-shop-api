using System.ComponentModel;

namespace online_shop.Models.Account;

public class Buyer : Account
{
    [DefaultValue(0)] public double? Credit { get; set; }

    public ICollection<Comment>? PostedComments { get; set; }

    public List<CartItem>? Cart { get; set; }

    public ICollection<Receipt>? Receipts { get; set; }
}