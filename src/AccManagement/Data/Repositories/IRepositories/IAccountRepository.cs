using System.Collections.Generic;
using System.Threading.Tasks;
using AccManagement.Data.Entities;

namespace AccManagement.Data.Repositories.IRepositories
{
    public interface IAccountRepository
    {

        public Task<IEnumerable<Account>> GetAccountsAsync();
        public Task<Account> CreateAccountAsync(Account acc);
        public Task<Account> GetAccountAsync(string accId);
        public Task<Account> GetAccountByUserIdAsync(string userId);
        public Task<Account> UpdateAccountAsync(Account acc, string accId, AccountTransaction transaction=null);
        public Task DeleteAccountAsync(string accId);
        
    }
}