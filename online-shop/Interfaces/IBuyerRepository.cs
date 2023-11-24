using online_shop.Models.Account;

namespace online_shop.Interfaces;

public interface IBuyerRepository
{
    ICollection<Account> ReadAll();
    Account? Read(int id);
    Account Create(Account buyer);
    bool Update(int id, Account buyer);
    bool Delete(int id);
}