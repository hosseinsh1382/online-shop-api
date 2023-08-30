using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Exceptions;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CartRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<CartItem> ReadAll(int buyerId)
    {
        return _dbContext.CartItem
            .Where(c => c.BuyerId == buyerId)
            .Include(c => c.Product)
            .ThenInclude(p => p.Fields)
            .Include(c => c.Product)
            .ThenInclude(p => p.Category)
            .ToList();
    }

    public CartItem Read(int cartItemId)
    {
        var cartItem = _dbContext.CartItem.SingleOrDefault(c => c.Id == cartItemId);

        if (cartItem == null)
            throw new NotFoundException("Item not found");

        return cartItem;
    }

    public ICollection<CartItem> AddToCart(CartItem cartItem)
    {
        var product = _dbContext.Products.SingleOrDefault(p => p.Id == cartItem.ProductId);
        if (product == null)
            throw new NotFoundException("Product not found");

        if (cartItem.Count > product.NumberInStock)
            throw new OutOfStocksException();

        var cart = _dbContext.CartItem.SingleOrDefault(c => c.ProductId == cartItem.ProductId);

        if (cart != null)
            cart.Count += cartItem.Count;
        else
            _dbContext.CartItem.Add(cartItem);


        _dbContext.SaveChanges();

        return _dbContext.CartItem
            .Where(c => c.BuyerId == cartItem.BuyerId)
            .Include(c => c.Product)
            .ToList();
    }

    public void DeleteAll(int buyerId)
    {
        _dbContext.CartItem.RemoveRange(_dbContext.CartItem.Where(c => c.BuyerId == buyerId));
        _dbContext.SaveChanges();
    }

    public void Delete(int cartItemId)
    {
        var cartItem = _dbContext.CartItem.SingleOrDefault(c => c.Id == cartItemId);
        if (cartItem == null)
            throw new NotFoundException("Item not found");

        _dbContext.CartItem.Remove(cartItem);
        _dbContext.SaveChanges();
    }
    

}