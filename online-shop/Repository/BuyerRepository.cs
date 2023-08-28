﻿using System.Text.Json;
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
        var receipts = _dbContext.Receipt
            .Where(r=>r.BuyerId==id)
            .Include(r=>r.ReceiptCartItems)
            .ThenInclude(c=>c.Product)
            .ThenInclude(p=>p.Fields)
            .ToList();
        return receipts;
    }

    public Receipt ReadReceipt(int receiptId)
    {
        /*var buyer = Read(buyerId);
        return buyer.Receipts.Single(r => r.Id == receiptId);*/
        return _dbContext.Receipt.SingleOrDefault(r => r.Id == receiptId);
    }

    public void CreateReceipt(int buyerId, Receipt receipt)
    {
        var buyer = Read(buyerId);
        buyer.Receipts.Add(receipt);

        _dbContext.SaveChanges();
    }
}