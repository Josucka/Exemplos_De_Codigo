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
using System.Text;
using System.Threading.Tasks;

namespace FinancialHub.Service.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IMapperWrapper _mapperWrapper;
        private readonly ICategoriesRepository _repository;

        public CategoriesService(IMapperWrapper mapperWrapper, ICategoriesRepository repository)
        {
            _mapperWrapper = mapperWrapper;
            _repository = repository;
        }

        public async Task<ServiceResult<CategoryModel>> CreateAsync(CategoryModel category)
        {
            var entity = _mapperWrapper.Map<CategoryEntity>(category);
            entity = await _repository.CreateAsync(entity);
            return _mapperWrapper.Map<CategoryModel>(entity);
        }

        public async Task<ServiceResult<int>> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ServiceResult<ICollection<CategoryModel>>> GetAllByUserAsync(string userId)
        {
            var entities = await _repository.GetAllAsync();
            var list = _mapperWrapper.Map<ICollection<CategoryModel>>(entities);
            return list.ToArray();
        }

        public async Task<ServiceResult<CategoryModel>> UpdateAsync(Guid id, CategoryModel category)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new NotFoundError($"Not found category with id {id}");
            entity.Id = id;
            entity = _mapperWrapper.Map<CategoryEntity>(entity);
            entity = await _repository.UpdateAsync(entity);

            return _mapperWrapper.Map<CategoryModel>(entity);
        }
    }
}
