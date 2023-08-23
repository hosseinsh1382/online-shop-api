using online_shop.Data;
using online_shop.Interfaces;
using online_shop.Models.Product;

namespace online_shop.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ICollection<Product> GetProducts()
    {
        var products = _applicationDbContext.Products.ToList();
        return products;
    }

    public void AddProduct(Product product)
    {
        _applicationDbContext.Products.Add(product);
        _applicationDbContext.SaveChanges();
    }
}