using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Exceptions;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IReceiptRepository _receiptRepository;

    public OrderRepository(ApplicationDbContext dbContext, IReceiptRepository receiptRepository)
    {
        _dbContext = dbContext;
      _receiptRepository = receiptRepository;
    }

    public Receipt FinalizeBuy(int buyerId)
    {
        var cart = _dbContext.CartItem
            .Where(c => c.BuyerId == buyerId)
            .Include(c => c.Product)
            .ToList();
        var totalPrice = cart.Sum(c => c.Product.Price * c.Count);
        var buyer = _dbContext.Buyers.Single(b => b.Id == buyerId);

        if (buyer.Credit < totalPrice)
        {
            throw new NotEnoughtCreditException();
        }

        buyer.Credit -= totalPrice;
        _dbContext.CartItem.RemoveRange(cart);
        foreach (var c in cart)
        {
            c.Product.NumberInStock -= c.Count;
        }

        var receipt = _receiptRepository.CreateReceipt(buyerId, cart);
        _dbContext.SaveChanges();
        return receipt;
        // return null;
    }
}