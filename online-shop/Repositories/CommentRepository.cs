using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Comment> ReadAll(int productId)
    {
        return _dbContext.Comments
            .Where(c => c.ProductId == productId)
            .Include(c => c.Status)
            .ToList();
    }

    public Comment Read(int id)
    {
        return _dbContext.Comments.SingleOrDefault(c => c.Id == id);
    }

    public Comment Create(int prouctId, CommentDto commentDto)
    {
        var comment = new Comment
        {
            Text = commentDto.Text,
            BuyerId = commentDto.BuyerId,
            ProductId = prouctId,
            IsBuyerBoughtProduct = commentDto.IsBuyerBoughtProduct,
            StatusId = 1,
            Date = DateTime.Now
        };
        _dbContext.Comments.Add(comment);
        _dbContext.SaveChanges();
        return comment;
    }

    public bool Update(int id, CommentDto comment)
    {
        var commentInDb = Read(id);

        if (commentInDb == null)
            return false;

        commentInDb.StatusId = commentInDb.StatusId;
        commentInDb.Text = commentInDb.Text;
        commentInDb.IsBuyerBoughtProduct = comment.IsBuyerBoughtProduct;

        _dbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var comment = Read(id);
        if (comment == null)
            return false;

        _dbContext.Remove(comment);
        _dbContext.SaveChanges();
        return true;
    }
}