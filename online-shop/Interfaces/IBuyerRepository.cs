﻿using online_shop.Models;
using online_shop.Models.Account;

namespace online_shop.Interfaces;

public interface IBuyerRepository
{
    ICollection<Buyer> ReadAll();
    Buyer Read(int id);
    Buyer Create(Buyer buyer);
    void Update(int id, Buyer buyer);
    void Delete(int id);

    ICollection<Receipt> ReadAllReceipts(int id);
    Receipt ReadReceipt(int buyerId, int receiptId);
    void CreateReceipt(int buyerId, ICollection<CartItem> products);
}