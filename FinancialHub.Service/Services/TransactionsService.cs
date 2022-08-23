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
    public class TransactionsService : IAccountsService
    {
        private readonly IMapperWrapper _mapperWrapper;
        private readonly IAccountsRepository _repository;

        public TransactionsService(IMapperWrapper mapperWrapper, IAccountsRepository repository)
        {
            _mapperWrapper = mapperWrapper;
            _repository = repository;
        }

        public async Task<ServiceResult<AccountModel>> CreateAsync(AccountModel account)
        {
            var entity = _mapperWrapper.Map<AccountEntity>(account);
            entity = await _repository.CreateAsync(entity);
            return _mapperWrapper.Map<AccountModel>(entity);
        }

        public async Task<ServiceResult<int>> DeleteAsync(Guid id)
        {
            var count = await _repository.DeleteAsync(id);
            return new ServiceResult<int>(count);
        }

        public async Task<ServiceResult<ICollection<AccountModel>>> GetAllByUserAsync(Guid userId)
        {
            var entities = await _repository.GetAllAsync();
            var list = _mapperWrapper.Map<ICollection<AccountModel>>(entities);
            return list.ToArray();
        }

        public async Task<ServiceResult<AccountModel>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapperWrapper.Map<AccountModel>(entity);
        }

        public async Task<ServiceResult<AccountModel>> UpdateAsync(Guid id, AccountModel account)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new NotFoundError($"Not found account with id {id}");

            entity = _mapperWrapper.Map<AccountEntity>(account);
            entity = await _repository.UpdateAsync(entity);
            return _mapperWrapper.Map<AccountModel>(entity);
        }
    }
}
