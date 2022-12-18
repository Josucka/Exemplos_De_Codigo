using FinancialHub.Domain.Models;
using FinancialHub.Domain.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialHub.Domain.Interfaces.Services
{
    public interface IAccountBalanceService
    {
        Task<ServiceResult<ICollection<BalanceModel>>> GetBalancesByAccountAsync(Guid accountId);
        Task<ServiceResult<AccountModel>> CreateAsync(AccountModel account);
        Task<ServiceResult<int>> DeleteAsync(Guid accountId);
    }
}
