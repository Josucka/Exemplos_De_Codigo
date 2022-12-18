using FinancialHub.Data.Contexts;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Interfaces.Repositories;
using System.ComponentModel;

namespace FinancialHub.Data.Repositories
{
    [Category("Repositories")]
    public class AccountsRepository : BaseRepository<AccountEntity>, IAccountsRepository
    {
        public AccountsRepository(FinancialHubContext context) : base(context)
        {
        }
    }
}
