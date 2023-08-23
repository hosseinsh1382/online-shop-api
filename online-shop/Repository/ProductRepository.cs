using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Interfaces;
using Online_Shop.Models;
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
        return _applicationDbContext.Products
            .Include(p=>p.Comments)
            .Include(p=>p.Fields)
            .Include(p=>p.Category)
            .ToList();
    }

    public Product GetProduct(int id)
    {
        return _applicationDbContext.Products.Single(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _applicationDbContext.Products.Add(product);
        _applicationDbContext.SaveChanges();
    }

    public void UpdateProduct(int id, Product product)
    {
        var productInDb = _applicationDbContext.Products.Single(p => p.Id == id);

        productInDb.Name = product.Name;
        productInDb.Price = product.Price;
        productInDb.Fields = product.Fields;
        productInDb.CategoryId = product.CategoryId;

        _applicationDbContext.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _applicationDbContext.Products.Single(p => p.Id == id);
        _applicationDbContext.Products.Remove(product);
        _applicationDbContext.SaveChanges();
    }
}