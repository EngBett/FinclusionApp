using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AccManagement.Data.Entities;
using AccManagement.Data.Repositories.IRepositories;

namespace AccManagement.Helpers
{
    public static class AccountHelpers
    {
        public static async Task<Account> CreateAccount(this string userId, IAccountRepository accountRepo)
        {
            var account = new Account
            {
                UserId = userId,
                Balance = 0,
            };

            return await accountRepo.CreateAccountAsync(account);
        }

        public static string GetNextAccount(this string accNumber)
        {
            var intNum = Convert.ToInt32(accNumber);
            // ReSharper disable once HeapView.BoxingAllocation
            return $"{++intNum}";
        }

        public static Account Withdraw(Account account, decimal amount)
        {
            account.Balance -= amount;
            return account;
        }
        
        public static Account Deposit(Account account, decimal amount)
        {
            account.Balance += amount;
            return account;
        }
        
        public static Account Deduct(Account account, decimal amount)
        {
            account.Balance -= amount;
            return account;
        }

        public static string Sha256_hash(this string value)
        {
            var sb = new StringBuilder();

            using var hash = SHA256.Create();
            var enc = Encoding.UTF8;
            var result = hash.ComputeHash(enc.GetBytes(value));

            foreach (var b in result)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}