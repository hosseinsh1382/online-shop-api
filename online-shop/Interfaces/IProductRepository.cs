using online_shop.Dtos;
using online_shop.Models;
using online_shop.Models.Product;

namespace online_shop.Interfaces;

public interface IProductRepository
{
    ICollection<Product> ReadAll();
    Product? Read(int id);
    void Create(Product product);
    bool Update(int id, Product product);
    bool Delete(int id);

}