using FinancialHub.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FinancialHub.Domain.Interfaces.Repositories
{
    public interface IBalancesRepository : IBaseRepository<BalanceEntity>
    {
        Task<BalanceEntity> ChangeAmountAsync(Guid balanceId, decimal value, TransactionEntity transactionType, bool removed = false);
    }
}
