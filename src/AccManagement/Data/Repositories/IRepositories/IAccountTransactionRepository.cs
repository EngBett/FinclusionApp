using System.Collections.Generic;
using System.Threading.Tasks;
using AccManagement.Data.Entities;

namespace AccManagement.Data.Repositories.IRepositories
{
    public interface IAccountTransactionRepository
    {
        public Task<IEnumerable<AccountTransaction>> GetTransactionsAsync(string accountId = null);
        public Task<IEnumerable<AccountTransaction>> GetTopTransactionsAsync(int limit, string accountId = null);
        public Task CreateTransactionAsync(AccountTransaction transaction);
        public Task<AccountTransaction> GetTransactionAsync(string transactionId);
        public Task<AccountTransaction> UpdateTransactionAsync(AccountTransaction acc, string transactionId);
        public Task DeleteTransactionAsync(string transactionId);
    }
}