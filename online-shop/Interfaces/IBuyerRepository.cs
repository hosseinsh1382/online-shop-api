using online_shop.Models.Account;

namespace online_shop.Interfaces;

public interface IBuyerRepository
{
    ICollection<Buyer> ReadAll();
    Buyer? Read(int id);
    Buyer Create(Buyer buyer);
    bool Update(int id, Buyer buyer);
    bool Delete(int id);
}