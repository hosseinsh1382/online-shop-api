using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Exceptions;
using online_shop.Interfaces;
using online_shop.Models;
using online_shop.Models.Account;

namespace online_shop.Repository;

public class BuyerRepository : IBuyerRepository
{
    private ApplicationDbContext _dbContext;

    public BuyerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Buyer> ReadAll()
    {
        return _dbContext.Buyers
            .Include(b => b.Receipts)
            .Include(b => b.Cart)
            .Include(b => b.Roll)
            .ToList();
    }

    public Buyer Read(int id)
    {
        var buyer = _dbContext.Buyers
            .Include(b=>b.Receipts)
            .Include(b=>b.Cart)
            .Include(b=>b.Roll)
            .SingleOrDefault(b => b.Id == id);
        if (buyer == null)
            throw new NotFoundException("Buyer not found");
        return buyer;
    }

    public Buyer Create(Buyer buyer)
    {
        _dbContext.Buyers.Add(buyer);
        _dbContext.SaveChanges();
        return buyer;
    }

    public void Update(int id, Buyer buyer)
    {
        var buyerInDb = Read(id);

        buyerInDb.Username = buyer.Username;
        buyerInDb.Password = buyer.Password;
        buyerInDb.Email = buyer.Email;
        buyerInDb.Firstname = buyer.Firstname;
        buyerInDb.Lastname = buyer.Lastname;
        buyerInDb.Credit = buyer.Credit;

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var buyer = _dbContext.Buyers.Single(b => b.Id == id);

        _dbContext.Buyers.Remove(buyer);
        _dbContext.SaveChanges();
    }

    public ICollection<Receipt> ReadAllReceipts(int id)
    {
        var receipts = Read(id).Receipts;
        if (receipts == null)
        {
            Console.WriteLine("null");
        }

        return receipts;
    }

    public Receipt ReadReceipt(int buyerId, int receiptId)
    {
        var buyer = Read(buyerId);
        var receipt = buyer.Receipts.Single(r => r.Id == receiptId);
        if (receipt == null)
        {
            throw new NotFoundException("Receipt not found");
        }

        return receipt;
    }

    public void CreateReceipt(int buyerId, ICollection<CartItem> products)
    {
        var buyer = Read(buyerId);
        var receipt = new Receipt
        {
            Products = products,
            Date = DateTime.Today
        };
        buyer.Receipts.Add(receipt);

        _dbContext.SaveChanges();
    }
}