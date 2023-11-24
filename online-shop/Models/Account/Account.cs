namespace online_shop.Models.Account;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public double? Credit { get; set; } = 0;

    public ICollection<Comment>? PostedComments { get; set; }

    public List<CartItem>? Cart { get; set; }

    public ICollection<Receipt>? Receipts { get; set; }

    public byte RollId { get; set; } = 1;
    public AccountRoll? Roll { get; set; }
}