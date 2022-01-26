using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccManagement.Data.Entities;
using AccManagement.Data.Repositories.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccManagement.Data.Repositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountTransactionRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsAsync(string accountId = null)
            => await _dbContext.AccountTransactions
                .Where(t => (t.AccountId == accountId || accountId == null))
                
                //Bad thing to do on a big system
                .Include(t=>t.Account)
                
                .OrderByDescending(c=>c.InitiatedAt)
                .ToArrayAsync();

        public async Task<IEnumerable<AccountTransaction>> GetTopTransactionsAsync(int limit, string accountId = null)
            => await _dbContext.AccountTransactions
                .Where(t => (t.AccountId == accountId || accountId == null))
                
                //Bad thing to do on a big system
                .Include(t=>t.Account)
                
                .OrderByDescending(t => t.InitiatedAt)
                .Take(limit)
                .ToArrayAsync();

        public async Task CreateTransactionAsync(AccountTransaction transaction)
        {
            await _dbContext.AccountTransactions.AddAsync(transaction);
            await SaveChangesAsync();
        }

        public async Task<AccountTransaction> GetTransactionAsync(string transactionId) =>
            await _dbContext.AccountTransactions.FirstOrDefaultAsync(t => t.AccountId == transactionId);

        public async Task<AccountTransaction> UpdateTransactionAsync(AccountTransaction transaction,
            string transactionId)
        {
            var newTransaction = await GetTransactionAsync(transactionId);
            var updatedTransaction = _mapper.Map(transaction, newTransaction);
            await SaveChangesAsync();
            return updatedTransaction;
        }

        public async Task DeleteTransactionAsync(string transactionId)
        {
            var newTransaction = await GetTransactionAsync(transactionId);
            _dbContext.AccountTransactions.Remove(newTransaction);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;
    }
}