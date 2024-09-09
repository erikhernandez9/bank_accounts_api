using System.Collections.Generic;

namespace MyApi.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int id);
        Account AddAccount(Account account);
        Account UpdateAccount(int id, Account updatedAccount);
        void DeleteAccount(int id);
    }
}