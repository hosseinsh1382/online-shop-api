using System.ComponentModel.DataAnnotations;
using Online_Shop.Models;

namespace online_shop.Models;

public class Comment
{
    public int Id { get; set; }
    [Required] public string Text { get; set; }
    public bool IsBuyerBoughtProduct { get; set; }

    [Required] public int BuyerId { get; set; }

    [Required] public int ProductId { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public CommentStatus? Status { get; set; }
    public byte StatusId { get; set; } = 1;
}