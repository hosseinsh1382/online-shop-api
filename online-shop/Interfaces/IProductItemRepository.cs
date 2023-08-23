using online_shop.Models.Product;

namespace online_shop.Interfaces;

public interface IProductItemRepository
{
    void AddItems(ProductItem items);
}