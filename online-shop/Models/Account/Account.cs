namespace online_shop.Models.Account;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }

    public byte RollId { get; set; } = 1;
    public AccountRoll? Roll { get; set; }
}