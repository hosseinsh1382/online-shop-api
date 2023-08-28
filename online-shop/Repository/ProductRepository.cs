using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models;
using online_shop.Models.Product;

namespace online_shop.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Product> ReadAll()
    {
        return _dbContext.Products
            .Include(p => p.Comments)
            .Include(p => p.Fields)
            .Include(p => p.Category)
            .ToList();
    }

    public Product Read(int id)
    {
        return _dbContext.Products.Single(p => p.Id == id);
    }

    public void Create(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void Update(int id, Product product)
    {
        var productInDb = _dbContext.Products.Single(p => p.Id == id);

        productInDb.Name = product.Name;
        productInDb.Price = product.Price;
        productInDb.Fields = product.Fields;
        productInDb.CategoryId = product.CategoryId;

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _dbContext.Products.Single(p => p.Id == id);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
    }

    public ICollection<Comment> ReadAllComments(int productId)
    {
        return _dbContext.Comments
            .Where(c => c.ProductId == productId)
            .Include(c=>c.Status)
            .ToList();
    }

    public Comment ReadComment(int commentId)
    {
        return _dbContext.Comments.SingleOrDefault(c => c.Id == commentId);
    }

    public Comment CreateComment(int prouctId, CommentDto commentDto)
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

    public void UpdateComment(int commentId, CommentDto comment)
    {
        var commentInDb = ReadComment(commentId);

        commentInDb.StatusId = commentInDb.StatusId;
        commentInDb.Text = commentInDb.Text;
        commentInDb.IsBuyerBoughtProduct = comment.IsBuyerBoughtProduct;

        _dbContext.SaveChanges();
    }
}