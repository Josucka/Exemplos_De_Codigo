using FinancialHub.Data.Contexts;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace FinancialHub.Data.Repositories
{
    public class TransactionsRepository : BaseRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionsRepository(FinancialHubContext context) : base(context)
        {
        }

        public override async Task<TransactionEntity> CreateAsync(TransactionEntity obj)
        {
#warning This is not a good pratice, remove this later
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.Category = null;
            obj.Balance = null;

            return await base.CreateAsync(obj);
        }

        public override async Task<TransactionEntity> UpdateAsync(TransactionEntity obj)
        {
            obj.Category = null;
            obj.Balance = null;
            return await base.UpdateAsync(obj);
        }
    }
}
