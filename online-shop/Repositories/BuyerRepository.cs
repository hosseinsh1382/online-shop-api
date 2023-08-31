﻿using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Exceptions;
using online_shop.Interfaces;
using online_shop.Models.Account;

namespace online_shop.Repositories;

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
            .Include(b => b.Roll)
            .Include(b => b.Receipts)!
            .ThenInclude(r => r.ReceiptCartItems)
            .ThenInclude(r => r.Product)
            .Include(b => b.Cart)!
            .ThenInclude(c => c.Product)
            .ThenInclude(c => c.Category)
            .Include(b => b.Cart)!
            .ThenInclude(c => c.Product)
            .ThenInclude(p => p.Fields)
            .ToList();
    }

    public Buyer? Read(int id)
    {
        return _dbContext.Buyers
            .Include(b => b.Roll)
            .Include(b => b.Receipts)!
            .ThenInclude(r => r.ReceiptCartItems)
            .ThenInclude(r => r.Product)
            .ThenInclude(p => p.Fields)
            .Include(b => b.Receipts)!
            .ThenInclude(r => r.ReceiptCartItems)
            .ThenInclude(r => r.Product)
            .ThenInclude(p => p.Category)
            .Include(b => b.Cart)!
            .ThenInclude(c => c.Product)
            .ThenInclude(c => c.Category)
            .Include(b => b.Cart)
            .ThenInclude(c => c.Product)
            .ThenInclude(p => p.Fields)
            .SingleOrDefault(b => b.Id == id);
    }

    public Buyer Create(Buyer buyer)
    {
        _dbContext.Buyers.Add(buyer);
        _dbContext.SaveChanges();
        return buyer;
    }

    public bool Update(int id, Buyer buyer)
    {
        var buyerInDb = Read(id);

        if (buyerInDb==null)
        {
            return false;
        }
        buyerInDb.Username = buyer.Username;
        buyerInDb.Password = buyer.Password;
        buyerInDb.Email = buyer.Email;
        buyerInDb.Firstname = buyer.Firstname;
        buyerInDb.Lastname = buyer.Lastname;
        buyerInDb.Credit = buyer.Credit;

        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var buyer = Read(id);

        if (buyer==null)
        {
            return false;
        }

        _dbContext.Buyers.Remove(buyer);
        _dbContext.SaveChanges();

        return true;
    }
}