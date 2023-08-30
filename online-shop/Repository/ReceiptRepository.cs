using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Exceptions;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Repository;

public class ReceiptRepository : IReceiptRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ReceiptRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Receipt> ReadAllReceipts(int id)
    {
        var receipts = _dbContext.Receipt
            .Where(r => r.BuyerId == id)
            .Include(r => r.ReceiptCartItems)
            .ThenInclude(c => c.Product)
            .ThenInclude(p => p.Fields)
            .ToList();
        return receipts;
    }

    public Receipt ReadReceipt(int receiptId)
    {
        var receipt = _dbContext.Receipt.SingleOrDefault(r => r.Id == receiptId);
        if (receipt == null)
            throw new NotFoundException("Receipt not found");
        return receipt;
    }

    public Receipt CreateReceipt(int buyerId, ICollection<CartItem> cart)
    {
        var receipt = new Receipt
        {
            BuyerId = buyerId,
            Date = DateTime.Now,
            ReceiptCartItems = cart.Select(c => new ReceiptCartItem
            {
                ProductId = c.ProductId,
                Count = c.Count
            }).ToList()
        };
        _dbContext.Receipt.Add(receipt);
        _dbContext.SaveChanges();

        return receipt;
    }
}