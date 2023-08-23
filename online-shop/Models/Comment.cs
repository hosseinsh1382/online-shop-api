using System.ComponentModel.DataAnnotations;
using Online_Shop.Models;

namespace online_shop.Models;

public class Comment
{
    public int Id { get; set; }
    [Required] public string Text { get; set; }
    public bool IsBuyerBoughtProduct { get; set; }

    //[Required] public Buyer Buyer { get; set; }

    public int ProductId { get; set; }

    public CommentStatus? Status { get; set; }
    public byte StatusId { get; set; }
}