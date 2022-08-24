using FinancialHub.Data.Contexts;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Enums;
using FinancialHub.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace FinancialHub.Data.Repositories
{
    public class BalancesRepository : BaseRepository<BalanceEntity>, IBalancesRepository
    {
        public BalancesRepository(FinancialHubContext context) : base(context)
        {
        }

        public override async Task<BalanceEntity> UpdateAsync(BalanceEntity obj)
        {
            obj.UpdateTime = DateTimeOffset.Now;

            var result = this._context.Update(obj);
            this._context.Entry(result.Entity).Property(x => x.Amount).IsModified = false;
            this._context.Entry(result.Entity).Property(x => x.CreationTime).IsModified = false;

            await _context.SaveChangesAsync();
            await result.ReloadAsync();

            return result.Entity;
        }

        public override async Task<BalanceEntity> CreateAsync(BalanceEntity obj)
        {
            obj.Amount = 0;
            return await base.CreateAsync(obj);
        }

        public async Task<BalanceEntity> ChangeAmountAsync(Guid balanceId, decimal value, TransactionType transactionType, bool removed = false)
        {
            var balance = await GetByIdAsync(balanceId);
            if(transactionType == TransactionType.Earn)
                balance.Amount = !removed ? balance.Amount + value : balance.Amount - value;
            else
                balance.Amount = removed ? balance.Amount + value : balance.Amount - value;

            balance.UpdateTime = DateTimeOffset.Now;
            _context.Update(balance);
            await _context.SaveChangesAsync();
            //_context.ChangeTracker.Clear();
            return balance;
        }
    }
}
