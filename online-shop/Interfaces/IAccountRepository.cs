using online_shop.Models.Account;

namespace online_shop.Interfaces;

public interface IAccountRepository
{
    ICollection<Account> ReadAll();
    Account? Read(int id);
    bool Update(int id, Account buyer);
    bool Delete(int id);
}