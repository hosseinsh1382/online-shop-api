using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models;

public class CommentStatus
{
    public byte Id { get; set; }
    [Required] public string Status { get; set; }
}