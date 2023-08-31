using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models;
using online_shop.Models.Product;

namespace online_shop.Repositories;

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

    public Product? Read(int id)
    {
        return _dbContext.Products.SingleOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public bool Update(int id, Product product)
    {
        var productInDb = Read(id);
        if (productInDb == null)
            return false;


        productInDb.Name = product.Name;
        productInDb.Price = product.Price;
        productInDb.Fields = product.Fields;
        productInDb.CategoryId = product.CategoryId;

        _dbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var product =Read(id);

        if (product == null)
            return false;
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();

        return true;
    }
}