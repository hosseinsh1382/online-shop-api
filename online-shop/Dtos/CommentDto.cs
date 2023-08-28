namespace online_shop.Dtos;

public class CommentDto
{
    public string Text { get; set; }
    public bool IsBuyerBoughtProduct { get; set; }
    public int BuyerId { get; set; }
    
}