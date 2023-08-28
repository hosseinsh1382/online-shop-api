using online_shop.Models;
using online_shop.Models.Product;

namespace online_shop.Interfaces;

public interface IProductRepository
{
    ICollection<Product> ReadAll();
    Product Read(int id);
    void Create(Product product);
    void Update(int id, Product product);
    void Delete(int id);

    ICollection<Comment> ReadAllComments(int productId);
    Comment ReadComment(int commentId);
    void CreateComment(Comment comment);

    void UpdateComment(int commentId, Comment comment);
}