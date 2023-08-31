using online_shop.Models;

namespace online_shop.Interfaces;

public interface ICartRepository
{
    ICollection<CartItem> ReadAll(int buyerId);
    CartItem? Read(int cartItemId);
    ICollection<CartItem> AddToCart(CartItem cartItem);

    void DeleteAll(int buyerId);

    bool Delete(int cartItemId);
}