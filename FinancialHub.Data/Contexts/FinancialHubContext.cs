using FinancialHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FinancialHub.Data.Contexts
{
    public class FinancialHubContext : DbContext
    {
        public FinancialHubContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<TransactionEntity>(table =>
            {
                table.HasKey(t => t.Id);
                table.HasIndex(t => t.Id).IsUnique(true);

                table.HasOne(x => x.Balance).WithMany(x => x.Transactions).HasForeignKey(x => x.BalanceId).HasPrincipalKey(x => x.Id).IsRequired(true);
                //table.Navigation(t => t.Balance).AutoInclude();

                table.HasOne(x => x.Category).WithMany(x => x.Transactions).HasForeignKey(x => x.CategoryId).HasPrincipalKey(x => x.Id).IsRequired(true);
                //table.Navigation(t => t.Category).AutoInclude();
            });

            model.Entity<BalanceEntity>(table =>
            {
                table.HasKey(t => t.Id);
                table.HasIndex(t => t.Id).IsUnique(true);

                table.HasOne(x => x.Account).WithMany(x => x.Balances).HasForeignKey(x => x.AccountId).HasPrincipalKey(x => x.Id).IsRequired(true);
                //table.Navigation(t => t.Account).AutoInclude();
            });

            base.OnModelCreating(model);
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BalanceEntity> Balances { get; set; }
    }
}
