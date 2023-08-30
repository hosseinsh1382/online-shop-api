using online_shop.Models;

namespace online_shop.Interfaces;

public interface IOrderRepository
{
    Receipt FinalizeBuy(int buyerId);
}