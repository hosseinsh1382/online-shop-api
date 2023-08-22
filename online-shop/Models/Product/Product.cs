namespace online_shop.Models.Product;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int NumberInStock { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
}