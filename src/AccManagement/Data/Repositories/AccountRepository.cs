using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccManagement.Data.Entities;
using AccManagement.Data.Repositories.IRepositories;
using AccManagement.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccManagement.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AccountRepository(AppDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync() => await _dbContext.Accounts.ToArrayAsync();

        public async Task<Account> CreateAccountAsync(Account acc)
        {
            var getPrev = await _dbContext.Accounts.OrderBy(c=>c.CreatedAt).LastOrDefaultAsync();
            var accountNumber = getPrev != null
                ? getPrev.AccountNumber.GetNextAccount()
                : _config.GetSection("AccNoStart").Value;
            acc.AccountNumber = accountNumber;

            //Calculate Checksum
            var stringData = acc.ToString() + _config.GetSection("ChecksumKey").Value;
            acc.CheckSum = stringData.Sha256_hash();

            await _dbContext.Accounts.AddAsync(acc);
            await SaveChangesAsync();

            return acc;
        }

        public async Task<Account> GetAccountAsync(string accId) =>
            await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accId);

        public async Task<Account> GetAccountByUserIdAsync(string userId) =>
            await _dbContext.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);

        public async Task<Account> UpdateAccountAsync(Account acc, string accId, AccountTransaction transaction = null)
        {
            var account = await GetAccountAsync(accId);

            acc.UpdatedAt = DateTime.Now;

            //Calculate Checksum
            var stringData = acc.ToString() + _config.GetSection("ChecksumKey").Value;
            acc.CheckSum = stringData.Sha256_hash();

            var newAcc = _mapper.Map(acc, account);
            if (transaction != null)
            {
                transaction.Checksum = acc.CheckSum;
                await _dbContext.AccountTransactions.AddAsync(transaction);
            }
            
            
            await SaveChangesAsync();

            return newAcc;
        }

        public async Task DeleteAccountAsync(string accId)
        {
            var account = await GetAccountAsync(accId);
            _dbContext.Accounts.Remove(account);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;
    }
}