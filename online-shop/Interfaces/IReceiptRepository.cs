using online_shop.Models;

namespace online_shop.Interfaces;

public interface IReceiptRepository
{
    ICollection<Receipt> ReadAllReceipts(int id);
    Receipt? ReadReceipt(int receiptId);
    Receipt CreateReceipt(int buyerId, ICollection<CartItem> cart);
}