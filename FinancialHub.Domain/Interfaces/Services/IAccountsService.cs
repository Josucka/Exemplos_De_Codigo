using FinancialHub.Domain.Models;
using FinancialHub.Domain.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialHub.Domain.Interfaces.Services
{
    public interface IAccountsService
    {
        Task<ServiceResult<ICollection<AccountModel>>> GetAllByUserAsync(Guid userId);
        Task<ServiceResult<AccountModel>> GetByIdAsync(Guid id);
        Task<ServiceResult<AccountModel>> CreateAsync(AccountModel account);
        Task<ServiceResult<AccountModel>> UpdateAsync(Guid id, AccountModel account);
        Task<ServiceResult<int>> DeleteAsync(Guid id);
    }
}
