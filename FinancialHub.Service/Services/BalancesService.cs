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
    public class BalancesService : IBalancesService
    {
        private readonly IMapperWrapper _mapper;
        private readonly IBalancesRepository _repository;
        private readonly IAccountsRepository _accountsRepository;

        public BalancesService(IMapperWrapper mapper, IBalancesRepository repository, IAccountsRepository accountsRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult<BalanceModel>> CreateAsync(BalanceModel balance)
        {
            var entity = _mapper.Map<BalanceEntity>(balance);
            entity.Amount = 0;

            var validateResult = await ValidateAccountAsync(entity);
            if (validateResult.HasError)
                return validateResult.Error;

            entity = await _repository.CreateAsync(entity);
            return _mapper.Map<BalanceModel>(entity);
        }

        public async Task<ServiceResult<int>> DeleteAsync(Guid id)
        {
            var count = await _repository.DeleteAsync(id);
            return new ServiceResult<int>(count);
        }

        public async Task<ServiceResult<ICollection<BalanceModel>>> GetAllByAccountAsync(Guid accountId)
        {
            var entities = await _repository.GetAsync(x => x.AccountId == accountId);
            var list = _mapper.Map<ICollection<BalanceModel>>(entities);
            return list.ToArray();
        }

        public async Task<ServiceResult<BalanceModel>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new NotFoundError($"Not found Balance with id {id}");

            return _mapper.Map<BalanceModel>(entity);
        }

        public async Task<ServiceResult<BalanceModel>> UpdateAsync(Guid id, BalanceModel balance)
        {
            var entityResult = await GetByIdAsync(id);
            if(entityResult.HasError)
                return entityResult.Error;

            var entity = _mapper.Map<BalanceEntity>(balance);
            entity.Id = id;

            var validadeResult = await ValidateAccountAsync(entity);
            if (validadeResult.HasError)
                return validadeResult.Error;

            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<BalanceModel>(entity);

        }

        private async Task<ServiceResult> ValidateAccountAsync(BalanceEntity balance)
        {
            var accountResult = await _accountsRepository.GetByIdAsync(balance.AccountId);
            if (accountResult == null)
                return new NotFoundError($"Not foun Account with id {balance.AccountId}");
            return new ServiceResult();
        }
    }
}
