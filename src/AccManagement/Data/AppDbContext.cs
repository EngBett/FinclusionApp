using AccManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransaction>()
                .Property(c => c.TranStatus)
                .HasConversion<string>();

            modelBuilder.Entity<AccountTransaction>()
                .Property(c => c.TranType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}