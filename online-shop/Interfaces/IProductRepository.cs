using online_shop.Models.Product;

namespace online_shop.Interfaces;

public interface IProductRepository
{
    ICollection<Product> GetProducts();
    void AddProduct(Product product);
}