using online_shop.Models.Product;

namespace online_shop.Interfaces;

public interface IProductRepository
{
    ICollection<Product> GetProducts();
    Product GetProduct(int id);
    void AddProduct(Product product);
    void UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
}