using FinancialHub.Domain.Interfaces.Services;
using FinancialHub.Domain.Models;
using FinancialHub.Domain.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialHub.Service.Services
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private readonly IBalancesService _balancesService;
        private readonly IAccountsService _accountsService;

        public AccountBalanceService(IBalancesService balancesService, IAccountsService accountsService)
        {
            _balancesService = balancesService;
            _accountsService = accountsService;
        }

        public async Task<ServiceResult<AccountModel>> CreateAsync(AccountModel account)
        {
            var createdAccount = await _accountsService.CreateAsync(account);
            if (createdAccount.HasError)
                return createdAccount.Error;

            var balance = new BalanceModel()
            {
                Name = $"{createdAccount.Data.Name} Default Balance",
                AccountId = createdAccount.Data.Id.GetValueOrDefault(),
                IsActive = createdAccount.Data.IsActive
            };

            var createdBalance = await _balancesService.CreateAsync(balance);
            if (createdBalance.HasError)
                return createdBalance.Error;

            return createdAccount;
        }

        public async Task<ServiceResult<int>> DeleteAsync(Guid accountId)
        {
            int removedLines = 0;
            var balances = await _balancesService.GetAllByAccountAsync(accountId);
            foreach(var balance in balances.Data)
            {
                var balanceResult = await _balancesService.DeleteAsync(balance.Id.GetValueOrDefault());
                if(balanceResult.HasError)
                    return balanceResult.Error;

                removedLines += balanceResult.Data;
            }

            var accountResult = await _accountsService.DeleteAsync(accountId);
            if (accountResult.HasError)
                return accountResult.Error;

            removedLines += accountResult.Data;

            return removedLines;
        }

        public Task<ServiceResult<ICollection<BalanceModel>>> GetBalancesByAccountAsync(Guid accountId)
        {
            return _balancesService.GetAllByAccountAsync(accountId);
        }
    }
}
