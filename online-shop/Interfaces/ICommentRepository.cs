using online_shop.Dtos;
using online_shop.Models;

namespace online_shop.Interfaces;

public interface ICommentRepository
{
    ICollection<Comment> ReadAll(int productId);
    
    Comment Read(int id);

    Comment Create(int productId, CommentDto comment);

    bool Update(int id, CommentDto comment);
    
    bool Delete(int id);
}