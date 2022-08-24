using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Interfaces.Mappers;
using FinancialHub.Domain.Interfaces.Repositories;
using FinancialHub.Domain.Interfaces.Services;
using FinancialHub.Domain.Models;
using FinancialHub.Domain.Results;
using FinancialHub.Domain.Results.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialHub.Service.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IMapperWrapper _mapperWrapper;
        private readonly IAccountsRepository _accountsRepository;

        public AccountsService(IMapperWrapper mapperWrapper, IAccountsRepository accountsRepository)
        {
            _mapperWrapper = mapperWrapper;
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult<AccountModel>> CreateAsync(AccountModel account)
        {
            var entity = _mapperWrapper.Map<AccountEntity>(account);
            entity = await _accountsRepository.CreateAsync(entity);
            return _mapperWrapper.Map<AccountModel>(entity);
        }

        public async Task<ServiceResult<int>> DeleteAsync(Guid id)
        {
            var count = await _accountsRepository.DeleteAsync(id);
            return new ServiceResult<int>(count);
        }

        public async Task<ServiceResult<ICollection<AccountModel>>> GetAllByUserAsync(Guid userId)
        {
            var entity = await _accountsRepository.GetAllAsync();
            var list = _mapperWrapper.Map<ICollection<AccountModel>>(entity);
            return list.ToArray();
        }

        public async Task<ServiceResult<AccountModel>> GetByIdAsync(Guid id)
        {
            var entity = await _accountsRepository.GetByIdAsync(id);
            return _mapperWrapper.Map<AccountModel>(entity);
        }

        public async Task<ServiceResult<AccountModel>> UpdateAsync(Guid id, AccountModel account)
        {
            var entity = await _accountsRepository.GetByIdAsync(id);
            if (entity == null)
                return new NotFoundError($"Not found account with id {id}");

            entity = _mapperWrapper.Map<AccountEntity>(account);
            entity = await _accountsRepository.UpdateAsync(entity);
            return _mapperWrapper.Map<AccountModel>(entity);
        }
    }
}
